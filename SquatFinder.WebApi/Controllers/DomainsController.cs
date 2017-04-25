using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SquatFinder.Core.Models;
using SquatFinder.Core.Services;

namespace SquatFinder.WebApi.Controllers
{
	[Route("api/[controller]")]
	public class DomainsController : Controller
	{
		private readonly ITwisterService _twisterService;

		public DomainsController(ITwisterService twisterService)
		{
			_twisterService = twisterService;
		}

		// GET api/domain/{domain}
		[HttpGet("{domain}")]
		public IActionResult Get(string domain)
		{
			if (string.IsNullOrEmpty(domain))
				return NotFound();

			var data = _twisterService.GetFuzzyDomains(domain);

			return new ObjectResult(data);
		}
	}
}