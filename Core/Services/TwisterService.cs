using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using DnsTwisterMonitor.Core.Http;
using DnsTwisterMonitor.Core.Models;
using DnsTwisterMonitor.Core.Services.Renders;

namespace DnsTwisterMonitor.Core.Services
{
	public class TwisterService : ITwisterService
	{
		private readonly IImageRenderService _imageRenderService;
		public TwisterService()
		{
			//_imageRenderService = new PageToImageService();
			_imageRenderService = new UrlToPngService();
		}

		public async Task<FuzzyResponseWrapper> GetFuzzyDomains(string domain)
		{
			var dnsClient = new DnsTwisterHttpClient();

		    Debug.WriteLine($"{DateTime.UtcNow} - Starting Monitor on {domain}");
			var domains = dnsClient.GetFuzzyDomains(domain);

			foreach (var fuzzyDomain in domains.FuzzyDomainList)
			{
			    Debug.WriteLine($"{DateTime.UtcNow} - Starting Fuzzy on {fuzzyDomain.FullDomainUrl}");
			    fuzzyDomain.IsDomainValid = await GetHostEntry(fuzzyDomain.Domain);
				if (fuzzyDomain.IsDomainValid)
				{
				    fuzzyDomain.RenderedImageUrl = _imageRenderService.GenerateImageUrl(domain);
				}
			}

			var d = "123";

			//var domainViewComponentList = MapToDomainViewComponent(domains);

			// var domainTestResultViewModel = new MonitorTestResultViewModel
			// {
			// 	MonitorTestViewList = domainViewComponentList,
			// 	DomainMonitored = domainViewRequest.Domain
			// };

			
			//domainViewComponentList = await LookupHostEntries(domainViewComponentList);

			//Group results by fuzzer types
			/*var results = domainViewComponentList.GroupBy(
				p => p.AlgorithmType, (type, grouped) =>
				new DomainFuzzerType
				{
					FuzzerType = type,
					Count = grouped.Count(),
					Percentage = Convert.ToInt16((Convert.ToDecimal(grouped.Count()) / Convert.ToDecimal(domainViewComponentList.Count())) * 100m)
				}).ToList();

			domainTestResultViewModel.DomainFuzzerTypesList = results;
			*/

			//return domainTestResultViewModel;

			return null;
		}

	    private static async Task<bool> GetHostEntry(string hostname)
	    {
	        try
	        {
	            if (string.IsNullOrWhiteSpace(hostname) || hostname.Length > 255) return false;

	            var host =  await Dns.GetHostEntryAsync(hostname);

	            return host.Aliases.Length > 0 || host.AddressList.Length > 0;
	        }
	        catch (Exception ex)
	        {
	            return false;
	        }
	    }
	}
}