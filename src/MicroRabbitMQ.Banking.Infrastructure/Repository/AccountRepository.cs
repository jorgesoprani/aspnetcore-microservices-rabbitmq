using MicroRabbitMQ.Banking.Domain.Interfaces;
using MicroRabbitMQ.Banking.Domain.Models;
using MicroRabbitMQ.Banking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroRabbitMQ.Banking.Infrastructure.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankingDbContext _context;
        public AccountRepository(BankingDbContext context)
        {
            this._context = context;
        }

        public async Task Create(Account account, CancellationToken cancellationToken) {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Account>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Accounts.ToListAsync(cancellationToken);
        }
    }
}
