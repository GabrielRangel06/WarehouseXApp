using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseXApp.Models;

namespace WarehouseXApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderSummary>> GetRecentOrdersAsync()
        {
            return await _context.Orders
                .Where(o => o.OrderDate >= new DateTime(2023, 1, 1))
                .OrderByDescending(o => o.OrderDate)
                .Take(100)
                .Select(o => new OrderSummary
                {
                    OrderId = o.Id,
                    CustomerName = o.Customer.Name,
                    OrderDate = o.OrderDate,
                    TotalAmount = o.Items.Sum(i => i.Quantity * i.Product.Price)
                })
                .ToListAsync();
        }
    }
}
