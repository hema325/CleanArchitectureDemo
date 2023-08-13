namespace Application.Items.Commands.CreateItem
{
    public class CreateItemCommandValidator: AbstractValidator<CreateItemCommand>
    {
        public CreateItemCommandValidator()
        {
            RuleFor(i => i.Name)
                .MaximumLength(250).WithMessage("The {PropertyName} must have maximum length of 250")
                .NotEmpty().WithMessage("The {PropertyName} is required");

            RuleFor(i => i.Image)
                .Must(img => img.ContentType.Contains("image")).WithMessage("The {PropertyName} you provided is not valid");
        }
    }
}
