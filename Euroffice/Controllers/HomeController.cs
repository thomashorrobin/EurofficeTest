using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Euroffice.Models;

namespace Euroffice.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
			Services.CatApiService _catApiService = new Services.CatApiService();

			return View(_catApiService.GetCategories());
        }

		public IActionResult Images([FromQuery]string categoryName)
		{
            Services.CatApiService _catApiService = new Services.CatApiService();

            ViewData["Message"] = categoryName;

			return View(_catApiService.GetImages(categoryName));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
