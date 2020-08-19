using onlineShop.WEB.Data.Interfaces;
using onlineShop.WEB.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineShop.WEB.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext dbContext;
        private readonly ShoppingCart shoppingCart;

        public OrderRepository(AppDbContext dbContext, ShoppingCart shoppingCart)
        {
            this.dbContext = dbContext;
            this.shoppingCart = shoppingCart;
        }

       

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            dbContext.Orders.Add(order);

            // without this line FK error from database ocurred
            dbContext.SaveChanges();

            var shoppingCartItems = shoppingCart.ShoppingCartItems;

            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = item.Amount,
                    OrderId = order.OrderId,
                    DrinkId = item.Drink.DrinkId,
                    Price = item.Drink.Price
                };

                dbContext.OrderDetails.Add(orderDetail);
            }

            dbContext.SaveChanges();
        }
    }
}
