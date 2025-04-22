using FluentValidation;
public class PhoneValidator : AbstractValidator<PhoneModel> {
    public PhoneValidator() {
        RuleFor(x => x.Number)
            .NotEmpty()
            .WithMessage("Number cannot be empty")
            .Length(10, 15)
            .WithMessage("Number must be between 10 and 15 characters long")
            .Matches(@"^\d{10,15}$")
            .WithMessage("Number must contain only digits");
    }
}