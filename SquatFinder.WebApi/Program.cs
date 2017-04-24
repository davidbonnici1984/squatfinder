using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace SquatFinder.WebApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = new WebHostBuilder()
				.UseKestrel()
				.UseContentRoot(Directory.GetCurrentDirectory())
				.UseStartup<Startup>()
				.UseApplicationInsights()
				.Build();

			host.Run();
		}
	}
}