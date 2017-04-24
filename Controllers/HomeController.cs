﻿using DnsTwisterMonitor.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace DnsTwisterMonitor.Controllers
{
	public class HomeController : Controller
	{
		private readonly ITwisterService _twisterService;

		public HomeController(ITwisterService twisterService)
		{
			_twisterService = twisterService;
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