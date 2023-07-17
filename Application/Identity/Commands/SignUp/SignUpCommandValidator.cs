using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Identity.Commands.SignUp
{
    internal class SignUpCommandValidator: AbstractValidator<SignUpCommand>
    {
        public SignUpCommandValidator()
        {
            RuleFor(c => c.FirstName).MaximumLength(24).NotEmpty().NotNull();
            RuleFor(c => c.LastName).MaximumLength(24).NotEmpty().NotNull();
            RuleFor(c => c.Email).MaximumLength(256).NotEmpty().NotNull();
            RuleFor(c => c.PhoneNumber).MaximumLength(24).NotEmpty().NotNull();
            RuleFor(c => c.Password).NotEmpty().NotNull();
        }
    }
}
