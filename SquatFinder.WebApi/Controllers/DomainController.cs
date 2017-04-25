using Microsoft.AspNetCore.Mvc;
using SquatFinder.Core.Models;
using SquatFinder.Core.Services;

namespace SquatFinder.WebApi.Controllers
{
	[Route("api/[controller]")]
	public class DomainController : Controller
	{
		private readonly ITwisterService _twisterService;

		public DomainController(ITwisterService twisterService)
		{
			_twisterService = twisterService;
		}

		// GET api/domain/{domain}
		[HttpGet("{domain}")]
		public AnalysisResult Get(string domain)
		{
			var result = new AnalysisResult {DomainList = _twisterService.GetFuzzyDomains(domain)};

			return result;
		}
	}
}