﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Items.Commands.CreateItem
{
    public class CreateItemCommandValidator: AbstractValidator<CreateItemCommand>
    {
        public CreateItemCommandValidator()
        {
            RuleFor(i => i.Name).MaximumLength(250).NotEmpty().NotNull();
            RuleFor(i => i.Image).Must(img => img.ContentType.Contains("image")).WithMessage("the file you provided is not an image");
        }
    }
}
