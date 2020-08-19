using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using onlineShop.WEB.Views.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using onlineShop.WEB.Views;
using onlineShop.WEB.Data.Interfaces;

namespace onlineShop.WEB.Controllers
{
    public class HomeController : Controller
    {        
        private readonly IDrinkRepository drinkRepository;

        public HomeController(IDrinkRepository drinkRepository)
        {            
            this.drinkRepository = drinkRepository;
        }

        public IActionResult Index()
        {
            var vm = new HomeViewModel
            {
                PreferredDrinks = drinkRepository.PreferredDrinks
            };

            return View(vm);
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
