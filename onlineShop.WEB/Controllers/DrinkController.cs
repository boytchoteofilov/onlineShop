using Microsoft.AspNetCore.Mvc;
using onlineShop.WEB.Data.Interfaces;
using onlineShop.WEB.Views;
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

        public IActionResult List()
        {
            var vm =  new DrinkListViewModel();
            vm.Drinks = drinkRepository.Drinks;
            vm.CurrentCategory = "Alcoholic";

            return View(vm);
        }
    }
}
