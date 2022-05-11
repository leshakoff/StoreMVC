using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Models
{
    public class EFCandyRepository : ICandyRepository
    {
        private ApplicationDBContext context;
        public EFCandyRepository(ApplicationDBContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Candy> Candies => context.Candies;

    }
}
