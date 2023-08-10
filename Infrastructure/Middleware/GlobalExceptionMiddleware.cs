using Application.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Infrastructure.Middleware
{
    internal class GlobalExceptionMiddleware: IMiddleware
    {
        private readonly Dictionary<Type, Func<HttpContext, Exception, Task>> _exceptionHandlers;

        public GlobalExceptionMiddleware()
        {
            _exceptionHandlers = new Dictionary<Type, Func<HttpContext, Exception, Task>>
            {
                [typeof(NotFoundException)] = HandleNotFoundException,
                [typeof(Application.Common.Exceptions.ValidationException)] = HandleValidationException
            };
        }


        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleException(context,ex);
            }
        }

        private async Task HandleException(HttpContext context,Exception exception)
        {
            var exType = exception.GetType();

            if (_exceptionHandlers.ContainsKey(exType))
                await _exceptionHandlers[exType].Invoke(context, exception);
            else
                await HandleUnKnownException(context, exception);
        }

        private async Task HandleNotFoundException(HttpContext context,Exception exception)
        {
            var ex = exception as NotFoundException;

            var problemDetails = new ProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                Title = "The specified resource was not found",
                Detail = ex.Message,
                Status = StatusCodes.Status404NotFound
            };

            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }

        private async Task HandleValidationException(HttpContext context, Exception exception)
        {
            var ex = exception as Application.Common.Exceptions.ValidationException;

            var problemDetails = new ValidationProblemDetails(ex.Errors)
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Title = "The specified resource is not valid",
                Detail = ex.Message,
                Status = StatusCodes.Status400BadRequest
            };

            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }

        private async Task HandleUnKnownException(HttpContext context, Exception exception)
        {
            var problemDetails = new ProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                Title = "An error ocurred while processing the request",
                Detail = exception.Message,
                Status = StatusCodes.Status500InternalServerError
            };

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}
