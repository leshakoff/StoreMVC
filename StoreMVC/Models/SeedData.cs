using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDBContext context = app.ApplicationServices.
            GetRequiredService<ApplicationDBContext>();
            context.Database.Migrate();
            if (!context.Candies.Any())
                context.Candies.AddRange(
                new Candy
                {
                    Name = "Милка",
                    Price = 120,
                    Amount = 150,
                    Category = "Шоколад",
                    Availability = "В наличии"
                },
                new Candy
                {
                    Name = "Сникерс",
                    Price = 150,
                    Amount = 150,
                    Category = "Шоколад",
                    Availability = "Нет в наличии"
                },
                new Candy
                {
                    Name = "Долька",
                    Price = 160,
                    Amount = 150,
                    Category = "Мармелад",
                    Availability = "Только оптом"
                }
                                    ) ;
            context.SaveChanges();
        }

    }
}
