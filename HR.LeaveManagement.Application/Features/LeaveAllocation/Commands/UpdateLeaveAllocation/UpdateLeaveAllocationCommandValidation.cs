using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;

public class UpdateLeaveAllocationCommandValidation : AbstractValidator<UpdateLeaveAllocationCommand>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    public UpdateLeaveAllocationCommandValidation(ILeaveAllocationRepository leaveAllocationRepository)
    {
        RuleFor(p => p.Id)
            .NotNull()
            .MustAsync(LeaveAllocationMustExist);
        RuleFor(p => p.NumberOfDays)
            .NotNull()
            .GreaterThan(1).WithMessage("{PropertyName} cannot exceed 100")
            .LessThan(100).WithMessage("{PropertyName} cannot be less than 1");
        RuleFor(p => p.LeaveTypeId)
            .NotNull();
        RuleFor(p => p.Period)
            .NotNull();

        _leaveAllocationRepository = leaveAllocationRepository;
    }

    public async Task<bool> LeaveAllocationMustExist(string id, CancellationToken token)
    {
        var leaveType = await _leaveAllocationRepository.GetByIdAsync(id);
        return leaveType != null;
    }
}
