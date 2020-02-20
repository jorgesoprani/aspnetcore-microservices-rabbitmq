using MicroRabbitMQ.Core.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbitMQ.Core.Domain.Commands
{
    public abstract class Command : Message
    {
        public DateTime TimeStamp { get; protected set; }

        protected Command()
        {
            this.TimeStamp = DateTime.Now;
        }
    }
}
