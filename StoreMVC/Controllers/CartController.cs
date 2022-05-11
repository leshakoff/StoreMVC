using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreMVC.Models;
using StoreMVC.Infrastructure;
using StoreMVC.Models.ViewModels;

namespace StoreMVC.Controllers
{
    public class CartController : Controller
    {

        private ICandyRepository repository;
        private Cart cart;
        public CartController(ICandyRepository repo, Cart cartService)
        {
            repository = repo;
            cart = cartService;
        }
        public IActionResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToCart(int candyID, string returnUrl)
        {
            Candy product = repository.Candies
            .FirstOrDefault(р => р.CandyID == candyID);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToActionResult RemoveFromCart(int candyID,
        string returnUrl)
        {
            Candy product = repository.Candies
            .FirstOrDefault(p => p.CandyID == candyID);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }



        //private ICandyRepository repository;

        //public CartController(ICandyRepository repo)
        //{
        //    repository = repo;
        //}

        //public IActionResult Index(string returnUrl)
        //{
        //    return View(new CartIndexViewModel
        //    {
        //        Cart = GetCart(),
        //        ReturnUrl = returnUrl
        //    });
        //}

        //public RedirectToActionResult AddToCart(int candyID, string returnUrl)
        //{
        //    Candy candy = repository.Candies.FirstOrDefault(x => x.CandyID == candyID);
        //    if (candy != null)
        //    {
        //        Cart cart = GetCart();
        //        cart.AddItem(candy, 1);
        //        SaveCart(cart);
        //    }

        //    return RedirectToAction("Index", new { returnUrl });
        //}

        //public RedirectToActionResult RemoveFromCart(int candyID, string returnUrl)
        //{
        //    Candy candy = repository.Candies.FirstOrDefault(x => x.CandyID == candyID);

        //    if (candy != null)
        //    {
        //        Cart cart = GetCart();
        //        cart.RemoveLine(candy);
        //        SaveCart(cart);
        //    }

        //    return RedirectToAction("Index", new { returnUrl });
        //}

        //private Cart GetCart()
        //{
        //    Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
        //    return cart;
        //}

        //private void SaveCart(Cart cart)
        //{
        //    HttpContext.Session.SetJson("Cart", cart);
        //}
    }
}
