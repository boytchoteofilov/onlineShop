using Microsoft.EntityFrameworkCore;
using onlineShop.WEB.Data.Interfaces;
using onlineShop.WEB.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineShop.WEB.Data.Repositories
{
    public class DrinkRepository : IDrinkRepository
    {
        private readonly AppDbContext dbContext;

        public DrinkRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Drink> Drinks => this.dbContext.Drinks.Include(x=> x.Category);

        public IEnumerable<Drink> PreferredDrinks => this.dbContext.Drinks.Where(x => x.IsPreferredDrink).Include(x => x.Category);

        public Drink GetDrinkById(int drinkId) => this.dbContext.Drinks.FirstOrDefault(x=>x.DrinkId == drinkId);
    }
}
