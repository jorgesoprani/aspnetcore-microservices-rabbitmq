using MicroRabbitMQ.Core.Domain.Commands;
using MicroRabbitMQ.Core.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbitMQ.Core.Domain.Bus
{
    public interface IEventBus
    {
        void Publish<TEvent>(TEvent @event) where TEvent : Event;
        void Subscribe<TEvent, THandler>()
            where TEvent : Event
            where THandler : IEventHandler;
    }
}
