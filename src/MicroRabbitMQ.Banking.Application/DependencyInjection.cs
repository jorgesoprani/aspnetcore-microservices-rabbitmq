using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MicroRabbitMQ.Banking.Application {
    public class DependencyInjection {
        public static Assembly ExecutingAssembly => Assembly.GetExecutingAssembly();
    }
}
