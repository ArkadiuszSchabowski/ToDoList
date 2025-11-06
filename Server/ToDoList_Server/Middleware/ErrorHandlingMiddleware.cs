using ToDoList_Server.Exceptions;

namespace ToDoList_Server.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (BadRequestException e)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(e.ToString());
            }

            catch (NotFoundException e)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(e.ToString());
            }
            catch (ConflictException e)
            {
                context.Response.StatusCode = 409;
                await context.Response.WriteAsync(e.ToString());
            }

            catch (Exception e)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(e.ToString());
            }
        }
    }
}