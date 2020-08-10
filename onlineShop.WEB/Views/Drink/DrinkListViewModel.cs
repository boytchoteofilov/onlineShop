using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using onlineShop.WEB.Data.Models;

namespace onlineShop.WEB.Views
{
    public class DrinkListViewModel
    {
        public IEnumerable<Drink> Drinks { get; set; }

        public string CurrentCategory { get; set; }
    }
}
