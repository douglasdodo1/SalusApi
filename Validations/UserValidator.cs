using FluentValidation;
using FluentValidation.Validators;

public class UserValidator : AbstractValidator<UserModel> {
    public UserValidator() {
        RuleFor(x => x.Cpf)
            .NotEmpty()
            .WithMessage("Cpf cannot be empty")
            .Length(11)
            .WithMessage("Cpf must be 11 characters long")
            .Matches(@"^\d{11}$")
            .WithMessage("Cpf must contain only digits")
            .Custom((cpf, context) => {
                if (!CpfValidator.IsValid(cpf)) {
                    context.AddFailure("Cpf", "Cpf is invalid");
                }
            });
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name cannot be empty")
            .Length(3, 50)
            .WithMessage("Name must be between 3 and 50 characters long")
            .Matches(@"^[a-zA-Z\s]+$")
            .WithMessage("Name must contain only letters and spaces");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email cannot be empty")
            .EmailAddress(EmailValidationMode.AspNetCoreCompatible)
            .WithMessage("Email is not valid");
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password cannot be empty")
            .Length(6, 20)
            .WithMessage("Password must be between 6 and 20 characters long")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,20}$")
            .WithMessage("Password must contain at least one uppercase letter, one lowercase letter, and one digit");
    }
}