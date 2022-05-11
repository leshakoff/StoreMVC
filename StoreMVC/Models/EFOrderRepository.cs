using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private ApplicationDBContext context;

        public EFOrderRepository(ApplicationDBContext ctx)
        {
            context = ctx;
        }


        public IQueryable<Order> Orders => context.Orders
                    .Include(o => o.Lines)
                    .ThenInclude(l => l.Candy);

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Candy));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
