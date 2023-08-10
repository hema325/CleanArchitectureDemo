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
    internal class RequestLoggingMiddleware : IMiddleware
    {
        private readonly ILogger<RequestLoggingMiddleware> _logger;
        private readonly ICurrentUser _currentUser;
        private readonly IDateTime _dateTime;

        public RequestLoggingMiddleware(ILogger<RequestLoggingMiddleware> logger, ICurrentUser currentUser, IDateTime dateTime)
        {
            _logger = logger;
            _currentUser = currentUser;
            _dateTime = dateTime;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger.LogInformation("Request with path {path} has Madded by User with Id {id} at {dateTime}",
                                   context.Request.Path,
                                   _currentUser.Id,
                                   _dateTime.Now);
            await next.Invoke(context);
        }
    }
}
