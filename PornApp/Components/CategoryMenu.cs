using Microsoft.AspNetCore.Mvc;
using PornApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PornApp.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
           
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.AllCategories().OrderBy(c => c.CategoryName);

            return View(categories);
        }
    }
}
