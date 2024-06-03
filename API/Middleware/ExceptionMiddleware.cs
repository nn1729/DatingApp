using System;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;
using API.Errors;
using Microsoft.AspNetCore.Http;

namespace API.Middleware;

public class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try {
            await next(context);
        }
        catch (Exception ex) {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString());

            var options = new JsonSerializerOptions() {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var jsons = JsonSerializer.Serialize(response, options);

            await context.Response.WriteAsync(jsons);
        }
        
    }
}
