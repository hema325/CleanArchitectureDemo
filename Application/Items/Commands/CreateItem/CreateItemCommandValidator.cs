namespace Application.Items.Commands.CreateItem
{
    public class CreateItemCommandValidator: AbstractValidator<CreateItemCommand>
    {
        public CreateItemCommandValidator()
        {
            RuleFor(i => i.Name)
                .MaximumLength(2).WithMessage("The {PropertyName} must have maximum length of {MaxLength}")
                .NotEmpty().WithMessage("The {PropertyName} is required");

            RuleFor(i => i.Image)
                .Must(img => img.ContentType.Contains("image")).WithMessage("The {PropertyName} you provided is not valid");
        }
    }
}
