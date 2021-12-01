using MicroRabbitMQ.Banking.Domain.Interfaces;
using MicroRabbitMQ.Banking.Infrastructure.Data;
using MicroRabbitMQ.Banking.Infrastructure.Repository;
using MicroRabbitMQ.Core.Domain.Bus;
using MicroRabbitMQ.Infrastructure.Bus;
using MicroRabbitMQ.Transfer.Application.Interfaces;
using MicroRabbitMQ.Transfer.Application.Services;
using MicroRabbitMQ.Transfer.Domain.Events.Transfer;
using MicroRabbitMQ.Transfer.Domain.Interfaces;
using MicroRabbitMQ.Transfer.Infrastructure.Data;
using MicroRabbitMQ.Transfer.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace MicroRabbitMQ.Infrastructure.IOC {
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(scopeFactory);
            });

            //Subscriptions
            services.AddTransient<TransferEventHandler>();

            //Domain Events
            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

            //Application Services
            services.AddTransient<ITransferService, TransferService>();

            //Data Layer
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransferRepository, TransferRepository>();
            services.AddTransient<BankingDbContext>();
            services.AddTransient<TransferDbContext>();
        }
    }
}
