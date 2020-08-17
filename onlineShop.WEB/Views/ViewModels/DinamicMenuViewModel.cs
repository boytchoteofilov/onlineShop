using onlineShop.WEB.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineShop.WEB.Views.ViewModels
{
    public class DinamicMenuViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}
