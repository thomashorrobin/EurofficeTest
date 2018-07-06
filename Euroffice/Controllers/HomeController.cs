using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Euroffice.Models;
using Euroffice.Services;

namespace Euroffice.Controllers
{
    public class HomeController : Controller
    {
		private ICatApiService _catApiService;

		public HomeController(ICatApiService catApiService)
		{
			_catApiService = catApiService;
		}

        public IActionResult Index()
        {         
			return View(_catApiService.GetCategories());
        }

		public IActionResult Images([FromQuery]string categoryName)
		{         
            ViewData["Message"] = categoryName;

			return View(_catApiService.GetImages(categoryName));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
