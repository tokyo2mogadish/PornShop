using PornApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PornApp.DAL
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; }

        IEnumerable<Pie> PiesOfTheWeek { get; }

        Pie GetPieById(int pieId);
    }
}
