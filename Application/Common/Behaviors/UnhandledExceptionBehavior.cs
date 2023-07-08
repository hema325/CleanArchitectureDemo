using Application.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Behaviors
{
    public class UnhandledExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<TRequest> _logger;
        private readonly IUser _user;

        public UnhandledExceptionBehavior(ILogger<TRequest> logger, IUser user)
        {
            _logger = logger;
            _user = user;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch(Exception ex)
            {
                var requestName = request.GetType().Name;
                var userId = _user.Id;

                var error = $"Unhandled exception for request {requestName} {userId} {request} ,message: {ex.Message}";

                _logger.LogError(error);

                throw;
            }
        }
    }
}
