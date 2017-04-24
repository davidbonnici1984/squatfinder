using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SquatFinder.Core.Http;
using SquatFinder.Core.Models;
using SquatFinder.Core.Services.Domain;
using SquatFinder.Core.Services.Renders;

namespace SquatFinder.Core.Services
{
	public class TwisterService : ITwisterService
	{
		private readonly IDnsResolver _dnsResolver;
		private readonly IImageRenderService _imageRenderService;
		private readonly ITwisterHttpClient _twisterHttpClient;

		public TwisterService(ITwisterHttpClient twisterHttpClient,
			IImageRenderService imageRenderService, IDnsResolver dnsResolver)
		{
			_twisterHttpClient = twisterHttpClient;
			_imageRenderService = imageRenderService;
			_dnsResolver = dnsResolver;
		}

		public FuzzyResponseWrapper GetFuzzyDomains(string domain)
		{
			Debug.WriteLine($"{DateTime.UtcNow} - Starting Monitor on {domain}");
			var domains = _twisterHttpClient.GetFuzzyDomains(domain);

			var tasks = new Dictionary<FuzzyDomain, Task<bool>>();

			foreach (var fuzzyDomain in domains.FuzzyDomainList)
				tasks[fuzzyDomain] = _dnsResolver.GetHostEntry(fuzzyDomain.Domain);

			Task.WaitAll(tasks.Values.ToArray());

			foreach (var task in tasks)
			{
				var resultDomain = task.Key;
				resultDomain.IsDomainValid = task.Value.Result;

				if (resultDomain.IsDomainValid)
					resultDomain.RenderedImageUrl = _imageRenderService.GenerateImageUrl(resultDomain.Domain);
			}
			return domains;
		}
	}
}