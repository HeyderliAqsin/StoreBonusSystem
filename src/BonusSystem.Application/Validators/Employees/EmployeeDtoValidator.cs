using BonusSystem.Models.DTOs.Employees;
using FluentValidation;

namespace BonusSystem.Application.Validators.Employees
{
    public class EmployeeDtoValidator : AbstractValidator<EmployeeDto>
    {
        public EmployeeDtoValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage("FullName name is required")
                .MinimumLength(5)
                .WithMessage("FullName must be at least 5 characters long");

            RuleFor(x => x.Salary)
               .GreaterThan(0)
               .WithMessage("Salary must be greater than 0");

            RuleFor(x => x.StoreId)
                .Must((model, field) => field != default)
                .WithMessage("StoreId cannot be the default Guid (empty).");

            RuleFor(x => x.PositionId)
                .Must((model, field) => field != default)
                .WithMessage("PositionId cannot be the default Guid (empty).");

        }
    }
}
