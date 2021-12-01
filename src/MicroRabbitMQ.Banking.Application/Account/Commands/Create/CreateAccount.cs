using MediatR;
using MicroRabbitMQ.Banking.Domain.Interfaces;
using MicroRabbitMQ.Core.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroRabbitMQ.Banking.Application.Account.Commands.Create {
    public class CreateAccount : Command {
        public string AccountType { get; set; }
        public decimal InitialBalance { get; set; }
    }

    public class CreateAccountHandler : IRequestHandler<CreateAccount, Unit> {
        private readonly IAccountRepository _accounts;
        public CreateAccountHandler(IAccountRepository accounts) {
            this._accounts = accounts;
        }

        public async Task<Unit> Handle(CreateAccount request, CancellationToken cancellationToken) {
            var newAccount = new Domain.Models.Account {
                AccountType = request.AccountType,
                Balance = request.InitialBalance
            };
            await _accounts.Create(newAccount, cancellationToken);
            return Unit.Value;
        }
    }
}
