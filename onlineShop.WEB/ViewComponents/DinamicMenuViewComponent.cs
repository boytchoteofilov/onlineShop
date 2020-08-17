using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using onlineShop.WEB.Data.Interfaces;
using onlineShop.WEB.Views.ViewModels;

namespace onlineShop.WEB.ViewComponents
{
    public class DinamicMenuViewComponent:ViewComponent
    {
        private readonly ICategoryRepository categoryRepository;

        public DinamicMenuViewComponent(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = categoryRepository.Categories.OrderBy(x=>x.CategoryName);

            var vm = new DinamicMenuViewModel()
            {
                Categories = categories,
            };

            return View(vm);
        }
    }
}
