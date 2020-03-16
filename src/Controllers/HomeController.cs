using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlusPlus.Models;

namespace PlusPlus.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static int _numberOfTimesClicked = 0;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            IncrementViewModel model = new IncrementViewModel();
            model.NumberOfTimesClicked = _numberOfTimesClicked; 
            return View(model);
        }

        [HttpPost]
        public IActionResult Increment()
        {
            _numberOfTimesClicked++;
            IncrementViewModel model = new IncrementViewModel();
            model.NumberOfTimesClicked = _numberOfTimesClicked;
            return View("Index", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
