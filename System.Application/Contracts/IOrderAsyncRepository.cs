using System;
using System.Application.Features.Orders.Commands.CreateOrder;
using System.Collections.Generic;
using System.Domain;
using System.Text;
using System.Threading.Tasks;

namespace System.Application.Contracts
{
    public interface IOrderAsyncRepository : IAsyncRepository<Order>
    {
        Task<Order> CreateOrderProducts(CreateOrderCommand createOrderCommand,Guid OrderId); 
    }
}
