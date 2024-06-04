using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWebsite.Data.Interfaces;
using CarWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarWebsite.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly IcarsCategory _allCategories;
        public CarsController(IAllCars iAllcars, IcarsCategory IcarsCat)
        {
            _allCars = iAllcars;
            _allCategories = IcarsCat;
        }
        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Car> cars=null;
            string currCategory="";
            if(string.IsNullOrEmpty(category))
            {
                cars = _allCars.Cars.OrderBy(i => i.id);
            }
            else
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.CategoryName.Equals("Электромобили")).OrderBy(i=>i.id);
                    currCategory = "Электромобили";
                }
                else if(string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.CategoryName.Equals("Классические автомобили")).OrderBy(i => i.id);
                    currCategory = "Классические автомобили";
                }
                
              
            }
            var carObj = new CarsList
            {
                AllCars = cars,
                carCategory = currCategory
            };

          
            return View(carObj);
        }

    }
}