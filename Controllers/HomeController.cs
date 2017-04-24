using DnsTwisterMonitor.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace DnsTwisterMonitor.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(string domainName)
		{
			var domainTwisterService = new TwisterService();

			var domainFuzzyList = domainTwisterService.GetFuzzyDomains(domainName);

			return View(domainFuzzyList.Result);
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