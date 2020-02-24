using MicroRabbitMQ.Transfer.Domain.Interfaces;
using MicroRabbitMQ.Transfer.Domain.Models;
using MicroRabbitMQ.Transfer.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbitMQ.Transfer.Infrastructure.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private readonly TransferDbContext _dbContext;
        public TransferRepository(TransferDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IEnumerable<TransferLog> GetAll()
        {
            return _dbContext.TransferLogs;
        }

        public void Add(TransferLog transfer)
        {
            _dbContext.TransferLogs.Add(transfer);
            _dbContext.SaveChanges();
        }
    }
}
