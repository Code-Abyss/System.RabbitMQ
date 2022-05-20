using System;
using System.Collections.Generic;
using System.Text;

namespace System.Application.RabbitMQ.Produser
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T message);
    }
}
