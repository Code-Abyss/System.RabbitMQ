using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MediatR;
using AutoMapper;
using System.Application.Contracts;
using System.Threading.Tasks;
using System.Threading;
using System.Domain;
using System.Application.RabbitMQ;
using System.Application.RabbitMQ.Produser;

namespace System.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler:IRequestHandler<CreateOrderCommand,Guid>
    {
        private readonly IOrderAsyncRepository _OrderRepository;
        private readonly IMapper _mapper;
        private readonly IMessageProducer _messageProducer;

      

        public CreateOrderCommandHandler(IOrderAsyncRepository OrderRepository,IMapper mapper, IMessageProducer messageProducer)
         {
            this._OrderRepository=OrderRepository;
            this._mapper=mapper;
            this._messageProducer = messageProducer;
        }
        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            Order order = _mapper.Map<Order>(request);
            
         
            order=await _OrderRepository.AddAsync(order);

            var FullOrder=await _OrderRepository.CreateOrderProducts(request, order.Id);
            _messageProducer.SendMessage<Guid>(FullOrder.Id);

            return order.Id;
        }
    }
}
