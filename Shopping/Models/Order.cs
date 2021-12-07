using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }

    public enum OrderStatus
    {
        Active,
        Inactive
    }
}
