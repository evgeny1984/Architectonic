using Ar.Compiler.Service.Services;
using Ar.Messages.EventBus.EventBus;
using Ar.Messages.EventBus.EventBus.Abstractions;
using Ar.Messages.EventBus.EventBusRabbitMQ;
using Architect.Dto.Dto;
using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Ar.Compiler.Service.Extensions
{
    public static class IServiceCollectionExtension
    {

        public static IServiceCollection AddInternalServices(this IServiceCollection services)
        {
            services.AddTransient<IRecognitionService, RecognitionService>();
            services.AddTransient<ITransformationService, TransformationService>();

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

        }

    }
}
