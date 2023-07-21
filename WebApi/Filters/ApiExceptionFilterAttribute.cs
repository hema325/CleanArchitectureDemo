using Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters
{
    public class ApiExceptionFilterAttribute: ExceptionFilterAttribute
    {
        private readonly Dictionary<Type,Action<ExceptionContext>> _exceptionHandlers;

        public ApiExceptionFilterAttribute()
        {
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                [typeof(NotFoundException)] = HandleNotFoundException,
                [typeof(ValidationException)] = HandleValidationException
            };
        }

        public override void OnException(ExceptionContext context)
        {
            HandleException(context);

            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            var exType = context.Exception.GetType();

            if (_exceptionHandlers.ContainsKey(exType))
                _exceptionHandlers[exType].Invoke(context);
            else
                HandleUnKnownException(context);
        }

        private void HandleNotFoundException(ExceptionContext context)
        {
            var ex = context.Exception as NotFoundException;

            var problemDetails = new ProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                Title = "The specified resource was not found",
                Detail = ex.Message,
                Status = StatusCodes.Status404NotFound
            };

            context.Result = new NotFoundObjectResult(problemDetails);
            context.ExceptionHandled = true;
        }

        private void HandleValidationException(ExceptionContext context)
        {
            var ex = context.Exception as ValidationException;

            var problemDetails = new ValidationProblemDetails(ex.Errors)
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Title = "The specified resource is not valid",
                Detail = ex.Message,
                Status = StatusCodes.Status400BadRequest
            };

            context.Result = new BadRequestObjectResult(problemDetails);
            context.ExceptionHandled = true;
        }

        private void HandleUnKnownException(ExceptionContext context)
        {
            var problemDetails = new ProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                Title = "An error ocurred while processing the request",
                Detail = context.Exception.Message,
                Status = StatusCodes.Status500InternalServerError
            };

            context.Result = new ObjectResult(problemDetails)
            { 
                StatusCode = StatusCodes.Status500InternalServerError
            };
            context.ExceptionHandled = true;
        }
    }
}

