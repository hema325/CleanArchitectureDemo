using Application.Common.Interfaces.Identity;
using Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Middleware
{
    internal class ResponseLoggingMiddleware : IMiddleware
    {
        private readonly ICurrentUser _currentUser;
        private readonly ILogger<ResponseLoggingMiddleware> _logger;
        private readonly IDateTime _dateTime;

        public ResponseLoggingMiddleware(ICurrentUser currentUser, ILogger<ResponseLoggingMiddleware> logger, IDateTime dateTime)
        {
            _currentUser = currentUser;
            _logger = logger;
            _dateTime = dateTime;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next.Invoke(context);

            _logger.LogInformation("Response for request with path {path} made by user id {id} has status code of {statusCode} at {dateTime}",
                                   context.Request.Path,
                                   _currentUser.Id,
                                   context.Response.StatusCode,
                                   _dateTime.Now);
        }
    }
}
