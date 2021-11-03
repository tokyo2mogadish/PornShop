using PornApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PornApp.DAL
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PornDbContext _context;

        public CategoryRepository(PornDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IEnumerable<Category> AllCategories()
        {
            return _context.Categories.ToList();
        }
    }
}
