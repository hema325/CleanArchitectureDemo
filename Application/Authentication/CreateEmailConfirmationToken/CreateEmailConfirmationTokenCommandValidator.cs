using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.CreateEmailConfirmationToken
{
    public class CreateEmailConfirmationTokenCommandValidator: AbstractValidator<CreateEmailConfirmationTokenCommand>
    {
        public CreateEmailConfirmationTokenCommandValidator()
        {
            RuleFor(c => c.Email).MaximumLength(256).NotEmpty().NotNull();
        }
    }
}
