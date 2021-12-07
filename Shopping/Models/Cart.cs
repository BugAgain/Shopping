using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public string UserId { get; set; }
        public virtual ICollection<Product> Items { get; set; }
        
        [NotMapped]
        public decimal Total { get; set; }

        public void AddProduct(Product product)
        {
            if (Items == null)
            {
                Items = new List<Product>();
            }
            Items.Add(product);
        }

        public void GetTotal()
        {
            Total = Items.Sum(i => i.Price * i.Quantity);
        }
    }
}
