using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWebsite.Models
{
    public class Car
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string shortDesc { get; set; }
        public string longDesc { get; set; }
        public string img { get; set; }
        public string desc { get; set; }
        public ushort prize { get; set; }
        public bool IsFavourite { get; set; }
        public bool available { get; set; }
        public int categoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}
