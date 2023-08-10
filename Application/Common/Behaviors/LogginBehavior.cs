using Application.Common.Interfaces.Identity;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Behaviors
{
    internal class LogginBehavior<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
    {
        private readonly ICurrentUser _currentUser;
        private readonly ILogger<TRequest> _logger;

        public LogginBehavior(ICurrentUser user, ILogger<TRequest> logger)
        {
            _currentUser = user;
            _logger = logger;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = request.GetType().Name;
            var userId = _currentUser.Id;
            var userName = _currentUser.UserName;

            _logger.LogInformation("Request: {requestName} {userId} {userName} {request}",
                                   requestName,
                                   userId,
                                   userName,
                                   request);
        }
    }
}
