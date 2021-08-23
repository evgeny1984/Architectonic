using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Architect.Dto.Dto
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var exception = contextFeature.Error;
                        string errorMessage = exception?.Message ?? "Internal Server Error.";
                        // Check exception type and handle the exception differently
                        switch (contextFeature.Error)
                        {
                            default:
                                break;
                        }

                        logger.LogError($"Something went wrong: {errorMessage}");

                        await context.Response.WriteAsync(new ApiError(context.Response.StatusCode, errorMessage)
                            .ToString());
                    }
                });
            });
        }
    }
}
