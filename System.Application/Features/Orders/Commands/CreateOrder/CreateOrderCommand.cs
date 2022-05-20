using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using System.Domain;
namespace System.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand:IRequest<Guid>
    {
        public OrderType Type { get; set; }
        public virtual List<Guid> Products { get; set; }
    }
}