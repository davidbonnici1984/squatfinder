using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SquatFinder.Core.Http;
using SquatFinder.Core.Services;
using SquatFinder.Core.Services.Domain;
using SquatFinder.Core.Services.Renders;

namespace SquatFinder.WebApi
{
	public class Startup
	{
		public IConfigurationRoot Configuration { get; }

		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", false, true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Add framework services.
			services.AddMvc();
			services.AddAutoMapper();

			services.AddTransient<ITwisterHttpClient, DnsTwisterHttpClient>();
			services.AddTransient<ITwisterService, TwisterService>();
			services.AddTransient<IImageRenderService, UrlToPngService>();
			services.AddTransient<IDnsResolver, DefaultDnsResolver>();

			JsonConvert.DefaultSettings = () =>
			{
				var settings = new JsonSerializerSettings();
				settings.Converters.Add(new StringEnumConverter {CamelCaseText = false});
				return settings;
			};
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			app.UseMvc();
		}
	}
}