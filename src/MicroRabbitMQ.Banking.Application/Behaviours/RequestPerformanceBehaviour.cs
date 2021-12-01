using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace PMicroRabbitMQ.Banking.Application.Behaviours {
    /// <summary>
    /// Middleware for all the requests passed through the Mediatr pipeline    
    /// </summary>
    public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;

        public RequestPerformanceBehaviour(ILogger<TRequest> logger) {
            _timer = new Stopwatch();

            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next) {
            //Logging at warning level requests that take longer than a threshold to finish
            _timer.Start();

            var response = await next();

            _timer.Stop();

            var thresholdInMs = 1000;

            if (_timer.ElapsedMilliseconds > thresholdInMs) {
                var name = typeof(TRequest).Name;
                _logger.LogWarning($"Long Running Request: {name} ({_timer.ElapsedMilliseconds} milliseconds) {request}");
            }

            return response;
        }
    }
}
