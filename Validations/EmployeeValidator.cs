using FluentValidation;

public class EmployeeValidator : AbstractValidator<EmployeeModel> {
    public EmployeeValidator(bool isUpdate = false) {
        RuleFor(x => x.Position)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().When(x => !isUpdate).WithMessage("Position is required.")
            .Length(2, 50).WithMessage("Position must be between 2 and 50 characters long.");
        RuleFor(x => x.HireDate)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().When(x => !isUpdate).WithMessage("Hire date is required.")
            .Matches(@"^\d{2}/\d{2}/\d{4}$").WithMessage("Hire date must be in the format DD-MM-YYYY.");
        RuleFor(x => x.Salary)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().When(x => !isUpdate).WithMessage("Salary is required.");
        RuleFor(x => x.Shift)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().When(x => !isUpdate).WithMessage("Shift is required.")
            .Length(2, 50).WithMessage("Shift must be between 2 and 50 characters long.");
    }
}