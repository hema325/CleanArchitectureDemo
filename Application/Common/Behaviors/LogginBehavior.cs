using Application.Common.Interfaces;
using Infrastructure.Services.Identity;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Behaviors
{
    public class LogginBehavior<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
    {
        private readonly IUser _user;
        private readonly IIdentityService _identityService;
        private readonly ILogger<TRequest> _logger;

        public LogginBehavior(IUser user, IIdentityService identityService, ILogger<TRequest> logger)
        {
            _user = user;
            _identityService = identityService;
            _logger = logger;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = request.GetType().Name;
            var userId = _user.Id;
            var userName = string.Empty;

            if (!string.IsNullOrEmpty(userId))
                userName = await _identityService.GetUserName(userId);

            var info = $"Request: {requestName} {userId} {userName} {request}";

            _logger.LogInformation(info);
        }
    }
}
