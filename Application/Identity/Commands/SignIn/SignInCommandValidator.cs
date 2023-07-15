using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Identity.Commands.SignIn
{
    public class SignInCommandValidator: AbstractValidator<SignInCommand>
    {
        public SignInCommandValidator()
        {
            RuleFor(c => c.Email).MaximumLength(256).NotEmpty();
            RuleFor(c => c.Password).NotEmpty();
            RuleFor(c => c.RememberMe).NotEmpty();
        }
    }
}
