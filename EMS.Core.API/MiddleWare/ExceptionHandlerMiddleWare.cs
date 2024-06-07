using EMS.Core.Commons;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace EMS.Core.API.MiddleWare
{
    public class ExceptionHandlerMiddleWare : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            ProblemDetails details = new()
            {
                Title = "Server error",
                Type = "Server error",
            };
            try
            {
                await next(context);
            }
            catch (ItemNotFoundException ex)
            {
                details = new()
                {
                    Detail = ex.Message,
                    Status = (int)HttpStatusCode.NotAcceptable,
                };
                context.Response.StatusCode = (int)HttpStatusCode.NotAcceptable;
                await context.Response.WriteAsync(JsonSerializer.Serialize(details));
            }
            catch (InvalidFormatException ex)
            {
                details = new()
                {
                    Detail = ex.Message,
                    Status = (int)HttpStatusCode.NotFound,
                };
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await context.Response.WriteAsync(JsonSerializer.Serialize(details));
            }
            catch (Exception ex)
            {
                details = new()
                {
                    Detail = ex.Message,
                    Status = (int)HttpStatusCode.InternalServerError,
                };
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(JsonSerializer.Serialize(details));
            }
        }
    }
}
