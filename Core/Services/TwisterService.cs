using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DnsTwisterMonitor.Core.Http;
using DnsTwisterMonitor.Core.Models;
using DnsTwisterMonitor.Core.Services.Renders;

namespace DnsTwisterMonitor.Core.Services
{
	public class TwisterService : ITwisterService
	{
		private readonly ITwisterHttpClient _twisterHttpClient;
		private readonly IImageRenderService _imageRenderService;

		public TwisterService(ITwisterHttpClient twisterHttpClient,
			IImageRenderService imageRenderService)
		{
			_twisterHttpClient = twisterHttpClient;
			_imageRenderService = imageRenderService;
		}

		public FuzzyResponseWrapper GetFuzzyDomains(string domain)
		{
			Debug.WriteLine($"{DateTime.UtcNow} - Starting Monitor on {domain}");
			var domains = _twisterHttpClient.GetFuzzyDomains(domain);

			var tasks = new Dictionary<FuzzyDomain, Task<bool>>();

			foreach (var fuzzyDomain in domains.FuzzyDomainList)
				tasks[fuzzyDomain] = GetHostEntry(fuzzyDomain.Domain);

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

		private static async Task<bool> GetHostEntry(string hostname)
		{
			try
			{
				Debug.WriteLine($"Dns Resolving for {hostname}");

				if (string.IsNullOrWhiteSpace(hostname) || hostname.Length > 255) return false;

				var host = await Dns.GetHostEntryAsync(hostname);

				Debug.WriteLine($"Dns Resolving completd for {hostname}");

				return host.Aliases.Length > 0 || host.AddressList.Length > 0;
			}
			catch
			{
				return false;
			}
		}
	}
}