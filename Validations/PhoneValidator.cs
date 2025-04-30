using FluentValidation;
public class PhoneValidator : AbstractValidator<PhoneModel> {
    public PhoneValidator(bool isUpdate = false) {
        RuleFor(x => x.Number)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().When(x => !isUpdate)
            .WithMessage("Number cannot be empty")
            .Length(10, 15)
            .WithMessage("Number must be between 10 and 15 characters long")
            .Matches(@"^\d{10,15}$")
            .WithMessage("Number must contain only digits");
    }
}