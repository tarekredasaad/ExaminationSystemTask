
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
namespace DynamicAuthApi.Middlewaare
{
    public class CustomMiddleWare : IMiddleware
    {
        
        public  async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next(context);
            //var endpoint = context.GetEndpoint();

            //var hasAuthorizeAttribute = endpoint?.Metadata.GetMetadata<AuthorizeAttribute>() != null;
           
                int statusCode = context.Response.StatusCode;

                switch (statusCode)
                {
                    case 200:
                        
                        context.Response.ContentType = "text/plain";
                        await context.Response.WriteAsync("success access.");
                        break;

                    case 302:
                       
                        context.Response.ContentType = "text/plain";
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        await context.Response.WriteAsync("Unauthorized access.");
                        break;

                    case 500:
                        context.Response.ContentType = "text/plain";
                        await context.Response.WriteAsync("internal server error");
                        break;

                    case 400:
                        context.Response.ContentType = "text/plain";
                        await context.Response.WriteAsync("faild request");
                        break;

                    default:
                        context.Response.ContentType = "text/plain";
                        await context.Response.WriteAsync("Unauthorized access Or default error.");
 
                        break;
                
                }


        }
    }
}
