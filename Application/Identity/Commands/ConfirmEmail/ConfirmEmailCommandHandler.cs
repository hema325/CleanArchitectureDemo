using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Identity.Commands.ConfirmEmail
{
    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand>
    {
        private readonly IUser _user;
        private readonly IAuthentication _authentication;

        public ConfirmEmailCommandHandler(IUser user, IAuthentication authentication)
        {
            _user = user;
            _authentication = authentication;
        }

        public async Task<Unit> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var result = await _user.ConfirmEmailAsync(request.UserId, request.Token);

            if (!result.Succeeded)
                throw new Exception(string.Join(",", result.Errors));

            await _authentication.SignInAsync(request.UserId);

            return Unit.Value;
        }
    }
}
