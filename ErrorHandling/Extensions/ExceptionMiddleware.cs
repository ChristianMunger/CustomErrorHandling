using ErrorHandling.Models;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace ErrorHandling.Extensions
{
    public static class ExceptionMiddleware
    {
        public static void UseCustomExceptionHandling(this IApplicationBuilder app)
        {   
            // now when we have an exception the following will occur
            app.UseExceptionHandler(x =>
            {
                x.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var feature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = context.Features.Get<IExceptionHandlerFeature>();

                    if (feature != null)
                    {
                        var error = new ErrorDetails
                        {
                            Statuscode = context.Response.StatusCode,
                            Message = "An unexpected error was encountered",
                            CorrelationId = context.TraceIdentifier,
                            ExceptionMessage = exception?.Error?.Message
                        };
                        await context.Response.WriteAsync(error.ToString());
                    }
                });
            });
        }
    }
}
