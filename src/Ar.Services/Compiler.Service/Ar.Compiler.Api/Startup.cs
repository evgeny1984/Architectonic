using Ar.Compiler.Service.Extensions;
using Ar.Messages.EventBus.EventBusRabbitMQ;
using Architect.Dto.Dto;
using Architect.Dto.Exceptions;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Ar.Compiler.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var appSettings = new AppSettings();
            Configuration.Bind(appSettings);

            services.AddInternalServices();

            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<GzipCompressionProvider>();
            });

            // Add event bus
            services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();

                var factory = new ConnectionFactory()
                {
                    HostName = appSettings.EventBusSettings?.EventBusConnection,
                    DispatchConsumersAsync = true
                };

                if (!string.IsNullOrEmpty(appSettings.EventBusSettings?.EventBusUserName))
                {
                    factory.UserName = appSettings.EventBusSettings?.EventBusUserName;
                }

                if (!string.IsNullOrEmpty(appSettings.EventBusSettings?.EventBusPassword))
                {
                    factory.Password = appSettings.EventBusSettings?.EventBusPassword;
                }

                var retryCount = 5;
                retryCount = appSettings.EventBusSettings?.EventBusRetryCount ?? 5;

                return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);
            });

            services.RegisterEventBus(appSettings);

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Architect Engine Project Compiler API",
                    Version = "v1",
                    Description = "Architect Engine Project Compiler Microservice API",
                    Contact = new OpenApiContact() { Name = "Evgeny Volynsky", Email = "evgeny.volynsky@tum.de" }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, true);
            });

            var container = new ContainerBuilder();
            container.Populate(services);

            return new AutofacServiceProvider(container.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Architect Engine Project Compiler API v1"));

            app.ConfigureExceptionHandler(loggerFactory.CreateLogger<Startup>());

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
