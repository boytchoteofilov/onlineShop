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
    public class DrinkController : Controller
    {
        private readonly IDrinkRepository drinkRepository;
        private readonly ICategoryRepository categoryRepository;

        public DrinkController(IDrinkRepository drinkRepository, ICategoryRepository categoryRepository)
        {
            this.drinkRepository = drinkRepository;
            this.categoryRepository = categoryRepository;
        }

        public IActionResult List(string category)
        {
            string _category = category;
            IEnumerable<Drink> drinks;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                drinks = drinkRepository.Drinks.OrderBy(p => p.DrinkId);
                currentCategory = "All drinks";
            }
            else
            {
                if (string.Equals("Alcoholic", _category, StringComparison.OrdinalIgnoreCase))
                    drinks = drinkRepository.Drinks.Where(p => p.Category.CategoryName.Equals("Alcoholic")).OrderBy(p => p.Name);
                else
                    drinks = drinkRepository.Drinks.Where(p => p.Category.CategoryName.Equals("Non-alcoholic")).OrderBy(p => p.Name);

                currentCategory = _category;
            }

            return View(new DrinkListViewModel
            {
                Drinks = drinks,
                CurrentCategory = currentCategory
            });
        }
    }
}
