using Ar.Generator.Repository;
using Ar.Generator.Repository.Wrapper;
using Ar.Generator.Service.IntegrationEvents.EventHandling;
using Ar.Generator.Service.IntegrationEvents.Events;
using Ar.Generator.Service.Services;
using Ar.Messages.EventBus.EventBus;
using Ar.Messages.EventBus.EventBus.Abstractions;
using Ar.Messages.EventBus.EventBusRabbitMQ;
using Architect.Dto.Dto;
using Autofac;
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

            return services;
        }

        public static void RegisterEventBus(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
            {
                var subscriptionClientName = appSettings.SubscriptionClientName;
                var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
                var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
                var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                var retryCount = 5;
                retryCount = appSettings.EventBusRetryCount;

                return new EventBusRabbitMQ(rabbitMQPersistentConnection, logger, iLifetimeScope, eventBusSubcriptionsManager, subscriptionClientName, retryCount);
            });

            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();

            services.AddTransient<SemanticModelCreatedIntegrationEvent>();
            services.AddTransient<SemanticModelCreatedIntegrationEventHandler>();
        }

    }
}
