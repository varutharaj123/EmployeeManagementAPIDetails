using EmployeeManagement.Application.DTOs;
using FluentValidation;

namespace EmployeeManagement.Application.Validators
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeDto>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(x => x.EmployeeName).NotEmpty().MaximumLength(100);

            RuleFor(x => x.Email).NotEmpty().EmailAddress();

            RuleFor(x => x.Department).NotEmpty();

            RuleFor(x => x.DateOfJoining).NotEmpty();

        }
    }
}