using CarWebsite.Data.Interfaces;
using CarWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWebsite.Data.Repositary
{
    public class CategoryRepositary : IcarsCategory
    {
        private readonly AppDBContent appDBContent;
        public CategoryRepositary(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }


        public IEnumerable<Category> AllCategories => appDBContent.Category;
    }
}
