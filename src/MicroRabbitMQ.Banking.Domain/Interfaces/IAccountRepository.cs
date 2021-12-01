using MicroRabbitMQ.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroRabbitMQ.Banking.Domain.Interfaces
{
    public interface IAccountRepository {
        Task<IEnumerable<Account>> GetAll(CancellationToken cancellationToken);
        Task Create(Account account, CancellationToken cancellationToken);
    }
}
