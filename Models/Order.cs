using System;
using System.Collections.Generic;

namespace WarehouseXApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public List<OrderItem> Items { get; set; } = new();
    }

}
