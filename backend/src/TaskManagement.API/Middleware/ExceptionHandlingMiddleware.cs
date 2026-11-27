using System;
using System.Net;
//using System.Text.Json;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace TaskManagement.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ArgumentException ex)
            {
                Log.Warning(ex, "Validation error while processing {Path}", context.Request.Path);
                await WriteErrorResponseAsync(context, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Log.Warning(ex, "Unauthorized access attempt at {Path}", context.Request.Path);
                await WriteErrorResponseAsync(context, HttpStatusCode.Unauthorized, "Unauthorized access.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Unhandled exception while processing {Path}", context.Request.Path);
                await WriteErrorResponseAsync(
                    context,
                    HttpStatusCode.InternalServerError,
                    "An unexpected error occurred. Please try again later."
                );
            }
        }

        private static Task WriteErrorResponseAsync(HttpContext context, HttpStatusCode statusCode, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var payload = JsonConvert.SerializeObject(new
            {
                statusCode = (int)statusCode,
                message,
                traceId = context.TraceIdentifier
            });

            return context.Response.WriteAsync(payload);
        }
    }
}