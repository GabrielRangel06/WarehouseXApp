using System.Collections.Generic;

namespace WarehouseXApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
