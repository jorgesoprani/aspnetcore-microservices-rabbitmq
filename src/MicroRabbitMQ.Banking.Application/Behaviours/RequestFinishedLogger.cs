using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace MicroRabbitMQ.Banking.Application.Behaviours {
    /// <summary>
    /// Post Processor for all the requests passed through the Mediatr pipeline
    /// Should log all events after they are completed
    /// </summary>
    public class RequestFinishedLogger<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse> {
        private readonly ILogger _logger;
        public RequestFinishedLogger(ILogger<TRequest> logger) {
            _logger = logger;
        }

        public Task Process(TRequest request, TResponse response, CancellationToken cancellationToken) {
            //Logging events at Debug level
            var name = typeof(TRequest).Name;

            var json = JsonConvert.SerializeObject(response, new JsonSerializerSettings {
                ContractResolver = new IgnoreStreamsResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            _logger.LogInformation($"Request Finished : {name} {request} {Environment.NewLine} {json}");
            return Task.CompletedTask;
        }
    }

    public class IgnoreStreamsResolver : DefaultContractResolver {
        protected override JsonProperty CreateProperty(
            MemberInfo member,
            MemberSerialization memberSerialization
        ) {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            if (typeof(Stream).IsAssignableFrom(property.PropertyType)) {
                property.Ignored = true;
            }
            return property;
        }
    }
}
