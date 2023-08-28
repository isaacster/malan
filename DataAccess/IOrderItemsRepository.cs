using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{

    public interface IOrderItemsRepository
    {
        Task<IEnumerable<OrderItems>> GetOrderItems();
        Task<OrderItems> GetOrderItem(string namr);
        Task AddOrderItem(OrderItems orderItem);
        Task UpdateOrderItem(OrderItems orderItem);
        Task DeleteOrderItem(int id);
    }

    public class OrderItemsRepository : IOrderItemsRepository
    {
        private readonly DbContextConnector _dbContext;

        public OrderItemsRepository(DbContextConnector dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<OrderItems>> GetOrderItems()
        {
            return await _dbContext.OrderItems.ToListAsync();
        }

        public async Task<OrderItems> GetOrderItem(string namr)
        {
            return await _dbContext.OrderItems.FirstOrDefaultAsync(item => item.ProductName == namr);
        }

        public async Task AddOrderItem(OrderItems orderItem)
        {
            _dbContext.OrderItems.Add(orderItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateOrderItem(OrderItems orderItem)
        {
            _dbContext.Entry(orderItem).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteOrderItem(int id)
        {
            var orderItem = await _dbContext.OrderItems.FindAsync(id);
            if (orderItem != null)
            {
                _dbContext.OrderItems.Remove(orderItem);
                await _dbContext.SaveChangesAsync();
            }
        }
    }

}
