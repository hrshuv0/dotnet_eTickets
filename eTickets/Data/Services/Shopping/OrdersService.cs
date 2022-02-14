using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTickets.Models.Shopping;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services.Shopping
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _context;

        public OrdersService(AppDbContext context)
        {
            _context = context;
        }


        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    MovieId = item.Movie.Id,
                    OrderId = order.Id,
                    Price = item.Movie.Price
                };
                await _context.OrderItems.AddAsync(orderItem);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetOrdersByUserAsync(string userId)
        {
            var orders = await _context.Orders
                .Include(n => n.OrderItems)
                .ThenInclude(n => n.Movie)
                .Where(n => n.UserId == userId).ToListAsync();
            
            return orders;
        }
    }
}