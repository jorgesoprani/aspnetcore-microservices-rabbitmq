using MediatR;
using MicroRabbitMQ.Banking.Domain.Interfaces;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroRabbitMQ.Banking.Application.Account.Queries.GetAll {
    public class GetAllAccounts : IRequest<AllAccountsView> {
    }

    public class GetAllAccountsHandler : IRequestHandler<GetAllAccounts, AllAccountsView> {

        private readonly IAccountRepository _accounts;
        public GetAllAccountsHandler(IAccountRepository accounts) {
            this._accounts = accounts;
        }

        public async Task<AllAccountsView> Handle(GetAllAccounts request, CancellationToken cancellationToken) {
            var items = await _accounts.GetAll(cancellationToken);
            await Task.Delay(1000);

            return new AllAccountsView {
                Quantity = items.Count(),
                Items = items.Select(item => new AllAccountsView.AllAccountsViewItem {
                    Id = item.Id,
                    AccountType = item.AccountType,
                    Balance = item.Balance
                }).ToList()
            };
        }
    }
}
