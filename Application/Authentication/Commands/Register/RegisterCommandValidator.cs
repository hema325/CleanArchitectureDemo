using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.SignUp
{
    public class RegisterCommandValidator: AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(c => c.FirstName).MaximumLength(24).NotEmpty().NotNull();
            RuleFor(c => c.LastName).MaximumLength(24).NotEmpty().NotNull();
            RuleFor(c => c.Email).MaximumLength(256).NotEmpty().NotNull();
            RuleFor(c => c.Password).NotEmpty().NotNull();
        }
    }
}
