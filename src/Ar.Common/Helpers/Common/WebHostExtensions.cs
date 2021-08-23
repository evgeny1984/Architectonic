using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Data.Common;
using System.Net.Sockets;

namespace Cc.Common.Helpers
{
    public static class WebHostExtensions
    {
        public static bool IsInKubernetes(this IWebHost webHost)
        {
            var cfg = webHost.Services.GetService<IConfiguration>();
            var orchestratorType = cfg.GetValue<string>("OrchestratorType");
            return orchestratorType?.ToUpper() == "K8S";
        }

        public static IWebHost MigrateDbContext<TContext>(this IWebHost webHost,
            Action<TContext> migrationAction)
        {
            var underK8s = webHost.IsInKubernetes();

            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var logger = services.GetRequiredService<ILogger<TContext>>();

                var context = services.GetService<TContext>();

                try
                {
                    logger.LogInformation($"Migrating database associated with context {typeof(TContext).Name}");

                    if (underK8s)
                    {
                        migrationAction(context);
                    }
                    else
                    {
                        // Retry Policy for DbException and SocketException, 
                        // SocketException is raised from Postgres if Db Startup is Cct finished yet.
                        var retry = Policy.Handle<Exception>(e => e is DbException || e is SocketException)
                             .WaitAndRetry(new TimeSpan[]
                             {
                             TimeSpan.FromSeconds(3),
                             TimeSpan.FromSeconds(5),
                             TimeSpan.FromSeconds(8),
                             TimeSpan.FromSeconds(13),
                             TimeSpan.FromSeconds(21),
                             });

                        //if the sql server container is Cct created on run docker compose this
                        //migration can't fail for network related exception. The retry options for DbContext only 
                        //apply to transient exceptions
                        // Ccte that this is CcT applied when running some orchestrators (let the orchestrator to recreate the failing service)
                        retry.Execute(() => migrationAction?.Invoke(context));
                    }

                    logger.LogInformation($"Migrated database associated with context {typeof(TContext).Name}");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, $"An error occurred while migrating the database used on context {typeof(TContext).Name}");
                    if (underK8s)
                    {
                        throw;          // Rethrow under k8s because we rely on k8s to re-run the pod
                    }
                }
            }

            return webHost;
        }
    }
}
