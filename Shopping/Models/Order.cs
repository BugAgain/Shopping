using System;

namespace Shopping.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public DateTime DeliveredBy { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }

    public enum OrderStatus
    {
        Active,
        Inactive
    }
}
