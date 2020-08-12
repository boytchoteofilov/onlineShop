using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using onlineShop.WEB.Data.Models;

namespace onlineShop.WEB.Views.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }

        public decimal ShoppingCartTotal { get; set; }
    }
}
