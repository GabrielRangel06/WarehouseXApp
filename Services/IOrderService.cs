using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseXApp.Models;

namespace WarehouseXApp.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderSummary>> GetRecentOrdersAsync();
    }
}
