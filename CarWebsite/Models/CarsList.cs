using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWebsite.Models
{
    
        public class CarsList
        {
            public IEnumerable<Car> AllCars { get; set; }
            public string carCategory { get; set; }
        }
    
}
