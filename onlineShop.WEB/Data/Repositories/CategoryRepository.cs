using onlineShop.WEB.Data.Interfaces;
using onlineShop.WEB.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineShop.WEB.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext dbContext;

        public CategoryRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<Category> Categories => this.dbContext.Categories;
    }
}
