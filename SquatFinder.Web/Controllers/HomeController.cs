using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SquatFinder.Core.Services;

namespace SquatFinder.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly IMapper _mapper;
		private readonly ITwisterService _twisterService;


		public HomeController(ITwisterService twisterService, IMapper mapper)
		{
			_twisterService = twisterService;
			_mapper = mapper;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(string domainName)
		{
			var domainFuzzyList = _twisterService.GetFuzzyDomains(domainName);

			return View(domainFuzzyList);
		}


		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";
			return View();
		}

		public IActionResult Error()
		{
			return View();
		}
	}
}