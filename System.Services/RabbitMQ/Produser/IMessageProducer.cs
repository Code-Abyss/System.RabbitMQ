using System;
using System.Collections.Generic;
using System.Text;

namespace System.Services.RabbitMQ.Produser
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T message);
    }
}
