using APIGetaway;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using TestMassTransit.Consumers;
using static MassTransit.MessageHeaders;

namespace TestMassTransit
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddMassTransit(x =>
            {
                x.AddConsumers(Assembly.GetExecutingAssembly());
                x.SetKebabCaseEndpointNameFormatter();

                x.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(new Uri("rabbitmq://localhost"), h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                });
                


            });

            services.AddMediator(mediator => Bus.Factory.CreateMediator(cfg =>
            {
                cfg.Consumer<FirstConsumer>();
            }));

            services.AddMassTransitHostedService();
            services.AddControllers();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TestMassTransit", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestMassTransit v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
