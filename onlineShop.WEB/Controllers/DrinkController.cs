using Microsoft.AspNetCore.Mvc;
using onlineShop.WEB.Data.Interfaces;
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

        public ViewResult List()
        {
            var drinks = drinkRepository.Drinks;
            return View(drinks);
        }
    }
}
