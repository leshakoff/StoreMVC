using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Models
{
    public interface ICandyRepository
    {
        IQueryable<Candy> Candies { get; }
    }
}
