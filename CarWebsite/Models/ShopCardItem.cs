using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWebsite.Models
{
    public class ShopCardItem
    {
        public int id { get; set; }
        public Car car { get; set; } 
        public int prize { get; set; }

            public string ShopCarId { get; set; }
    }
}
