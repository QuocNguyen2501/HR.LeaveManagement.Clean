using FluentValidation;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;

public class CreateLeaveAllocationCommandValidation:AbstractValidator<CreateLeaveAllocationCommand>
{
    public CreateLeaveAllocationCommandValidation()
    {
        RuleFor(p => p.LeaveTypeId)
            .NotNull();
    }
}
