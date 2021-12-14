using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shopping.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Color { get; set; }
        
        [Display(Name = "Image Path")]
        public string ImagePath { get; set; }

        [Range(typeof(decimal), "5", "10000", ErrorMessage = "Price should rangue between {1} and {2}")]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public bool SoftDeleted { get; set; }

        public DateTime CreatedAt { get; set; }


        public virtual ICollection<CustomDetail> CustomDetails { get; set; }

        public decimal GetTotalProducts()
        {
            return Quantity > 0 ? Quantity * Price : decimal.Zero;
        }
    }
}
