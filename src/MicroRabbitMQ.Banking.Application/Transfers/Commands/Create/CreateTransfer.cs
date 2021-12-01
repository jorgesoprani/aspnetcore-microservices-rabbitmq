using MediatR;
using MicroRabbitMQ.Core.Domain.Bus;
using MicroRabbitMQ.Core.Domain.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace MicroRabbitMQ.Banking.Application.Transfers.Commands.Create {
    public class CreateTransfer : Command {
        public int FromAccount { get; set; }
        public int ToAccount { get; set; }
        public decimal Amount { get; set; }
    }

    public class CreateTransferHandler : IRequestHandler<CreateTransfer> {
        private readonly IEventBus _eventBus;
        public CreateTransferHandler(IEventBus eventBus) {
            this._eventBus = eventBus;
        }
        public Task<Unit> Handle(CreateTransfer request, CancellationToken cancellationToken) {
            _eventBus.Publish(new TransferCreatedEvent(request.FromAccount, request.ToAccount, request.Amount));
            return Task.FromResult(Unit.Value);
        }
    }
}
