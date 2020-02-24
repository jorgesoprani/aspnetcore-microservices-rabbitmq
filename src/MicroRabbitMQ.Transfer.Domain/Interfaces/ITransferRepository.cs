using MicroRabbitMQ.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbitMQ.Transfer.Domain.Interfaces
{
    public interface ITransferRepository
    {
        void Add(TransferLog transfer);
        IEnumerable<TransferLog> GetAll();
    }
}
