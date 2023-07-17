using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Identity.Commands.ConfirmEmail
{
    internal class ConfirmEmailCommandValidator: AbstractValidator<ConfirmEmailCommand>
    {
        public ConfirmEmailCommandValidator()
        {
            RuleFor(c => c.UserId).NotEmpty().NotNull();
            RuleFor(c => c.Token).NotEmpty().NotNull();
        }
    }
}
