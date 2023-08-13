namespace Application.Items.Commands.UpdateItem
{
    public class UpdateItemCommandValidator: AbstractValidator<UpdateItemCommand>
    {
        public UpdateItemCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("The {PropertyName} is required");

            RuleFor(i => i.Name)
                .MaximumLength(250).WithMessage("The {PropertyName} must have maximum length of 250")
                .NotEmpty().WithMessage("The {PropertyName} is required"); ;
        }
    }
}
