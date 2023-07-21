using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.SignOut
{
    public class SignOutCommandHandler : IRequestHandler<SignOutCommand>
    {
        private readonly IAuthentication _auth;

        public SignOutCommandHandler(IAuthentication auth)
        {
            _auth = auth;
        }

        public async Task<Unit> Handle(SignOutCommand request, CancellationToken cancellationToken)
        {
            await _auth.SignOutAsync();

            return Unit.Value;
        }
    }
}
