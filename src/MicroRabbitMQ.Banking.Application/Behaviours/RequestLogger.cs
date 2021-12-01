using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace MicroRabbitMQ.Banking.Application.Behaviours {
    /// <summary>
    /// Pre Processor for all the requests passed through the Mediatr pipeline
    /// Should log all events that were just initiated
    /// </summary>
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest> {
        private readonly ILogger _logger;
        public RequestLogger(ILogger<TRequest> logger) {
            _logger = logger;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken) {
            //Logging events at Debug level
            var name = typeof(TRequest).Name;
            _logger.LogInformation($"Request: {name} {request}");
            return Task.CompletedTask;
        }
    }
}
