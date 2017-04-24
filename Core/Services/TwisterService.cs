using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DnsTwisterMonitor.Core.Http;
using DnsTwisterMonitor.Core.Models;
using DnsTwisterMonitor.Core.Services.Domain;
using DnsTwisterMonitor.Core.Services.Renders;

namespace DnsTwisterMonitor.Core.Services
{
	public class TwisterService : ITwisterService
	{
		private readonly ITwisterHttpClient _twisterHttpClient;
		private readonly IImageRenderService _imageRenderService;
		private readonly IDnsResolver _dnsResolver;

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