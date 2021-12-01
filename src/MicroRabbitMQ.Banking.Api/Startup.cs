using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using MicroRabbitMQ.Banking.Application;
using MicroRabbitMQ.Banking.Application.Account.Commands.Create;
using MicroRabbitMQ.Banking.Application.Behaviours;
using MicroRabbitMQ.Banking.Infrastructure.Data;
using MicroRabbitMQ.Infrastructure.IOC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PMicroRabbitMQ.Banking.Application.Behaviours;
using Swashbuckle.AspNetCore.Swagger;

namespace MicroRabbitMQ.Banking.Api {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<BankingDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("BankingDbContext"));
            });

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo {
                    Title = "Banking Microservice",
                    Version = "v1"
                });
            });
            
            services.AddMediatR(Assembly.GetExecutingAssembly(), Application.DependencyInjection.ExecutingAssembly);
            services.AddValidators();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            services.AddControllers();

            RegisterServices(services);
        }

        private void RegisterServices(IServiceCollection services) {
            DependencyContainer.RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Banking Microservice v1");
            });

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
