using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SquatFinder.Web.Core.Http;
using SquatFinder.Web.Core.Models;
using SquatFinder.Web.Core.Services.Domain;
using SquatFinder.Web.Core.Services.Renders;

namespace SquatFinder.Web.Core.Services
{
	public class TwisterService : ITwisterService
	{
		private readonly IDnsResolver _dnsResolver;
		private readonly IImageRenderService _imageRenderService;
		private readonly ITwisterHttpClient _twisterHttpClient;
		private readonly IMapper _mapper;

		public TwisterService(ITwisterHttpClient twisterHttpClient,
			IImageRenderService imageRenderService, 
			IDnsResolver dnsResolver,
			IMapper mapper)
		{
			_twisterHttpClient = twisterHttpClient;
			_imageRenderService = imageRenderService;
			_dnsResolver = dnsResolver;
			_mapper = mapper;
		}

		public IList<FinderDomain> GetFuzzyDomains(string domain)
		{
			Debug.WriteLine($"{DateTime.UtcNow} - Starting Monitor on {domain}");
			var domains = _twisterHttpClient.GetFuzzyDomains(domain);

			var finderDomains = Map(domains.FuzzyDomainList);
			
			var tasks = new Dictionary<FinderDomain, Task<bool>>();

			foreach (var finderDomain in finderDomains)
				tasks[finderDomain] = _dnsResolver.GetHostEntry(finderDomain.Domain);

			Task.WaitAll(tasks.Values.ToArray());

			foreach (var task in tasks)
			{
				var resultDomain = task.Key;
				resultDomain.IsValidDomain = task.Value.Result;

				if (resultDomain.IsValidDomain)
					resultDomain.ScreenshotImageUrl = _imageRenderService.GenerateImageUrl(resultDomain.Domain);
			}
			return finderDomains;
		}

		private IList<FinderDomain> Map(IList<DnsTwisterDomain> dnsTwisterDomainList)
		{
			return _mapper.Map<IList<DnsTwisterDomain>, IList<FinderDomain>>(dnsTwisterDomainList);
		}
	}
}