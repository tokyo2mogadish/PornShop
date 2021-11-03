using Microsoft.EntityFrameworkCore;
using PornApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PornApp.DAL
{
    public class PieRepository : IPieRepository
    {
        private readonly PornDbContext _context;

        public PieRepository(PornDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IEnumerable<Pie> AllPies 
        {
            get
            {
                return _context.Pies.Include(p => p.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return AllPies.Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie GetPieById(int pieId)
        {
            return  AllPies.FirstOrDefault( p => p.PieId == pieId );
            
        }
    }
}
