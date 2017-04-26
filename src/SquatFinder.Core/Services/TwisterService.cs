using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
		private readonly IMapper _mapper;
		private readonly ITwisterHttpClient _twisterHttpClient;

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

		public AnalysisResult GetFuzzyDomains(string domain)
		{
			var domains = _twisterHttpClient.GetFuzzyDomains(domain);

			var finderDomains = Map(domains.FuzzyDomainList);
			
			var tasks = new Dictionary<FinderDomain, Task<bool>>();

			//Create tasks
			foreach (var finderDomain in finderDomains)
				tasks[finderDomain] = _dnsResolver.GetHostEntry(finderDomain.Domain);

			//Fire all tasks async
			Task.WaitAll(tasks.Values.ToArray());
			
			//Validate Result
			foreach (var task in tasks)
			{
				var resultDomain = task.Key;
				resultDomain.IsValidDomain = task.Value.Result;

				if (resultDomain.IsValidDomain)
					resultDomain.ScreenshotImageUrl = _imageRenderService.GenerateImageUrl(resultDomain.Domain);
			}

			//Group Results by Algorithm Type
			var result = new AnalysisResult
			{
				SearchResult = finderDomains,
				ResultStatistics = BuildAlgorithmResultStatisics(finderDomains)
			};

			return result;
		}

		private static IList<AlgorithmResultsStatistics> BuildAlgorithmResultStatisics(ICollection<FinderDomain> domains)
		{
			var data = domains.GroupBy(c => c.AlgorithmName);

			var algorithmResultsStatisticsList = data.Select(item => new AlgorithmResultsStatistics()
			{
				Name = item.Key,
				Count = item.ToList().Count,
				Percentage = (int)Math.Round((double)(100 * item.ToList().Count) / domains.Count)
			}).ToList();

			return algorithmResultsStatisticsList;
		}

		private IList<FinderDomain> Map(IList<DnsTwisterDomain> dnsTwisterDomainList)
		{
			return _mapper.Map<IList<DnsTwisterDomain>, IList<FinderDomain>>(dnsTwisterDomainList);
		}
	}
}