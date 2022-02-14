using System.Collections.Generic;
using System.Threading.Tasks;
using eTickets.Models.Shopping;

namespace eTickets.Data.Services.Shopping
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        Task<List<Order>> GetOrdersByUserAsync(string userId);

    }
}