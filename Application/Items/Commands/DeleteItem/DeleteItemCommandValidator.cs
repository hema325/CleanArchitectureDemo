using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Items.Commands.DeleteItem
{
    public class DeleteItemCommandValidator: AbstractValidator<DeleteItemCommand>
    {
        public DeleteItemCommandValidator()
        {
            RuleFor(i => i.Id)
                .NotEmpty().WithMessage("The {PropertyName} is required"); ;
        }
    }
}
