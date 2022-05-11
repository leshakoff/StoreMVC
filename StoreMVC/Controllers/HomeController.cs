using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreMVC.Models;
using StoreMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private ICandyRepository repository;
        private ApplicationDBContext db;

        public HomeController(ICandyRepository repo, ApplicationDBContext context)
        {
            repository = repo;
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }


 //       public IActionResult List(string category, int productPage = 1) =>
 //View(new ProductsListViewModel
 //{
 //    Products = repository.Products
 //       .Where(p => category == null || p.Category == category)
 //       .OrderBy(p => p.ProductID)
 //       .Skip((productPage - 1) * PageSize)
 //       .Take(PageSize),
 //    PagingInfo = new PagingInfo
 //    {
 //        CurrentPage = productPage,
 //        ItemsPerPage = PageSize,
 //        TotalItems = category == null ?
 //        repository.Products.Count() :
 //        repository.Products
 //        .Where(e => e.Category == category).Count()
 //    },
 //    CurrentCategory = category
 //});
        public IActionResult CandyList()
        {

            return View(
                new CandyListViewModel
                {
                    Candies = repository.Candies
                }
                ) ;
        }

        [HttpGet]
        public IActionResult AddCandy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCandy(Candy candy)
        {
            if (ModelState.IsValid)
            {
                db.Candies.Add(candy);
                db.SaveChanges();
                return View("Done", candy);
            }
            else
            {
                return View();
            }

        }

    }
}
