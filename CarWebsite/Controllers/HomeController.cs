using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarWebsite.Models;
using CarWebsite.Data.Interfaces;
using CarWebsite.Data.ViewModels;

namespace CarWebsite.Controllers
{
    public class HomeController : Controller
    {
        private IAllCars _carRep;

        private readonly ILogger<HomeController> _logger;
       
        public HomeController(IAllCars carRep)
        {
            _carRep = carRep;
        }
        public ViewResult Index()
        {
            var homeCars = new HomeViewModel
            {
                favCars=_carRep.GetFavCars
            };
            return View(homeCars);
        }

       

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
