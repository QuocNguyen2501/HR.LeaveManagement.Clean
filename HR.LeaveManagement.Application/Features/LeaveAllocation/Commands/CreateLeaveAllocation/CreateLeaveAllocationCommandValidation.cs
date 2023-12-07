using FluentValidation;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;

public class CreateLeaveAllocationCommandValidation:AbstractValidator<CreateLeaveAllocationCommand>
{
    public CreateLeaveAllocationCommandValidation()
    {
        RuleFor(p => p.NumberOfDays)
            .NotNull()
            .GreaterThan(1).WithMessage("{PropertyName} cannot exceed 100")
            .LessThan(100).WithMessage("{PropertyName} cannot be less than 1");
        RuleFor(p => p.LeaveTypeId)
            .NotNull();
        RuleFor(p => p.Period)
            .NotNull();
    }
}
