using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public Color Color { get; set; }
        
        [Display(Name = "Image Path")]
        public string ImagePath { get; set; }

        [Range(typeof(decimal), "5", "10000", ErrorMessage = "Price should rangue between {1} and {2}")]
        public decimal Price { get; set; }

        [NotMapped]
        public int Quantity { get; set; }

        //public int? CartId { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }


        public virtual ICollection<CustomDetail> CustomDetails { get; set; }

        public decimal GetTotalProducts()
        {
            return Quantity * Price;
        }
    }

    public enum Color
    {
        Red,
        Blue,
        Yellow
    }
}
