using PornApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PornApp.DAL
{
    public class MockCategoryReporitory : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories()
        {
            var categories  = new List<Category>
            {
                new Category{CategoryId = 1, CategoryName ="Fruit pies", Description = "All fruity pies"},
                new Category{CategoryId = 2, CategoryName ="Chees cakes", Description = "Cheesy all the way"},
                new Category{CategoryId = 3, CategoryName ="Seasonal pies", Description = "Get in the mood for a seasonal pie"},
            };

            return categories;
        }

        
    }
}
