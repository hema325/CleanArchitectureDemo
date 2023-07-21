using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Items.Commands.UpdateItem
{
    public class UpdateItemCommandValidator: AbstractValidator<UpdateItemCommand>
    {
        public UpdateItemCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(i => i.Name).MaximumLength(250).NotEmpty();
        }
    }
}
