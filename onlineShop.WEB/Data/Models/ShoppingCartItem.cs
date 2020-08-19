using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace onlineShop.WEB.Data.Models
{
    public class ShoppingCartItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShoppingCartItemId { get; set; }

        public Drink Drink { get; set; }

        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
