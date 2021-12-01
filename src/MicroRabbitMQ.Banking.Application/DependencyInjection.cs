using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using FluentValidation;

namespace MicroRabbitMQ.Banking.Application {
    public static class DependencyInjection {
        public static Assembly ExecutingAssembly => Assembly.GetExecutingAssembly();

        public static void AddValidators(this IServiceCollection services) {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
