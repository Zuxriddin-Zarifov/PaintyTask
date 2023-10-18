using PictureSharing.Domain.Dtos;
using PictureSharing.Domain.Expections;

namespace PictureSharing.Middlewares;

public class ExceptionHandlerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
           await next(context);
        }
        catch (CustomException e)
        {
            context.Response.StatusCode = e.StatusCode;
            context.Response.WriteAsJsonAsync(e.Message);
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            context.Response.StatusCode = 400;
            context.Response.WriteAsJsonAsync(e.Message);
            Console.WriteLine(e.Message);
        }
    }
}