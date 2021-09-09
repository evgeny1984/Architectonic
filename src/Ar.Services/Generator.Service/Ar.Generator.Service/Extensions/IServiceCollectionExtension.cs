using Ar.Generator.Repository;
using Ar.Generator.Repository.Wrapper;
using Ar.Generator.Service.IntegrationEvents.EventHandling;
using Ar.Generator.Service.Services;
using Ar.Messages.EventBus.EventBus;
using Ar.Messages.EventBus.EventBus.Abstractions;
using Ar.Messages.EventBus.EventBusRabbitMQ;
using Architect.Dto.Dto;
using Architect.Dto.Events;
using Autofac;
using Jering.Javascript.NodeJS;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Ar.Generator.Service.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddPostgreDbContext(this IServiceCollection services, string connectionString = "")
        {
            services.AddDbContext<GeneratorDbContext>(options =>
               options.UseNpgsql(connectionString, builder =>
               {
                   builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
               }));

            return services;
        }

        public static IServiceCollection AddRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            return services;
        }

        public static IServiceCollection AddInternalServices(this IServiceCollection services)
        {
            services.AddTransient<ISolutionService, SolutionService>();
            services.AddTransient<INodeJsService, NodeJsService>();
            services.AddTransient<IGeneratorService, GeneratorService>();

            return services;
        }

        public static IServiceCollection AddNodeJsService(this IServiceCollection services)
        {
            // Add node js library to call js functions
            services.AddNodeJS();

            // Set the folder containing scripts
            services.Configure<NodeJSProcessOptions>(options => options.ProjectPath = "./wwwroot/scripts/");
            
            // Enable javascript debugging in chrome
            services.Configure<NodeJSProcessOptions>(options => options.NodeAndV8Options = "--inspect-brk");

            services.Configure<OutOfProcessNodeJSServiceOptions>(options =>
            {
                options.TimeoutMS = -1; // Set the timeout for connecting to the NodeJS process and for invocations to -1(infinite)
                options.Concurrency = Concurrency.MultiProcess; // Concurrency.None by default, Invocations will be distributed among multiple NodeJS processes using round-robin load balancing
                options.ConcurrencyDegree = 8; // Number of processes. Defaults to the number of logical processors on your machine.
            });

            return services;
        }

        public static void RegisterEventBus(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
            {
                var subscriptionClientName = appSettings.EventBusSettings?.SubscriptionClientName;
                var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
                var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
                var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                var retryCount = 5;
                retryCount = appSettings.EventBusSettings?.EventBusRetryCount ?? 5;

                return new EventBusRabbitMQ(rabbitMQPersistentConnection, logger, iLifetimeScope, eventBusSubcriptionsManager, subscriptionClientName, retryCount);
            });

            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();

            services.AddTransient<SemanticModelCreatedIntegrationEvent>();
            services.AddTransient<SemanticModelCreatedIntegrationEventHandler>();
        }

    }
}
