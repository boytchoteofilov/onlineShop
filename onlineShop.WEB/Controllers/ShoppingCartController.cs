using Microsoft.AspNetCore.Mvc;
using onlineShop.WEB.Data.Interfaces;
using onlineShop.WEB.Data.Models;
using onlineShop.WEB.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineShop.WEB.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IDrinkRepository drinkRepository;
        private readonly ShoppingCart shoppingCart;

        public ShoppingCartController(IDrinkRepository drinkRepository, ShoppingCart shoppingCart)
        {
            this.drinkRepository = drinkRepository;
            this.shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = items;

            var vm = new ShoppingCartViewModel
            {
                ShoppingCart = this.shoppingCart,
                ShoppingCartTotal = this.shoppingCart.GetShoppingCartTotal()
            };

            return View(vm);
        }

        public RedirectToActionResult AddToShoppingCart(int drinkId)
        {
            var selectedDrink = drinkRepository.Drinks.FirstOrDefault(x => x.DrinkId == drinkId);

            if (selectedDrink != null)
            {
                shoppingCart.AddToCart(selectedDrink, 1);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int drinkId)
        {
            var selectedDrink = drinkRepository.Drinks.FirstOrDefault(x => x.DrinkId == drinkId);

            if (selectedDrink != null)
            {
                shoppingCart.RemoveFromCart(selectedDrink);
            }

            return RedirectToAction("Index");
        }
    }
}
