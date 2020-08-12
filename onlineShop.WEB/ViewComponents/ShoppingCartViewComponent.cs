using Microsoft.AspNetCore.Mvc;
using onlineShop.WEB.Data.Models;
using onlineShop.WEB.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineShop.WEB.Components
{
    [ViewComponent(Name = "ShoppingCart")]
    public class ShoppingCartViewComponent : ViewComponent
    {
        private readonly ShoppingCart shoppingCart;

        public ShoppingCartViewComponent(ShoppingCart shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }

        public IViewComponentResult  Invoke()
        {
            var items = shoppingCart.GetShoppingCartItems(); // new List<ShoppingCartItem>(){new ShoppingCartItem(), new ShoppingCartItem()};
            shoppingCart.ShoppingCartItems = items;

            var vm = new ShoppingCartViewModel
            {
                ShoppingCart = shoppingCart,
                ShoppingCartTotal = shoppingCart.GetShoppingCartTotal()
            };

            return View(vm);
        }
    }
}
