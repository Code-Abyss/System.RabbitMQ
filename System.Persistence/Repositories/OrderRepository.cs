using System;
using System.Application.Contracts;
using System.Application.Features.Orders.Commands.CreateOrder;
using System.Domain;
using System.Threading.Tasks;

namespace System.Persistence.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderAsyncRepository
    {
        private readonly SystemDBContext _dbContext;

        public OrderRepository(SystemDBContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Order> CreateOrderProducts(CreateOrderCommand createOrderCommand, Guid OrderId)
        {
            foreach (var productId in createOrderCommand.Products)
            {
                OrderProduct orderProduct = new OrderProduct
                {
                    Id = Guid.NewGuid(),
                    OrderId = OrderId,
                    ProductId = productId,
                };
                _dbContext.OrderProducts.Add(orderProduct);

              
            }
           await _dbContext.SaveChangesAsync();
            return await _dbContext.Orders.FindAsync(OrderId);

        }
    }
}
