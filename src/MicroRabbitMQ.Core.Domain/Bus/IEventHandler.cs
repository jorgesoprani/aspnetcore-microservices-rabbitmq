using MicroRabbitMQ.Core.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbitMQ.Core.Domain.Bus
{
    public interface IEventHandler<in TEvent> : IEventHandler
        where TEvent : Event
    {
        Task Handler(TEvent @event);
    }

    public interface IEventHandler { }

}
