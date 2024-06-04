using CarWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWebsite.Data.Interfaces
{
    public interface IcarsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
