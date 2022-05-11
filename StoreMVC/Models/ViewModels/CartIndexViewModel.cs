using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreMVC.Models;

namespace StoreMVC.Models.ViewModels
{
    public class CartIndexViewModel
    {
        public Cart CartIndex { get; set; }
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
