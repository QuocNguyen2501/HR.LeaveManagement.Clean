using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Shared;

public class BaseLeaveRequestValidator: AbstractValidator<BaseLeaveRequest>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public BaseLeaveRequestValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;

        RuleFor(p=>p.StartDate)
            .LessThan(p=>p.EndDate).WithMessage("{PropertyName} must be before {ComparisonValue}");

        RuleFor(p => p.EndDate)
            .GreaterThan(p=>p.StartDate).WithMessage("{PropertyName} must be after {ComparisonValue}");

        RuleFor(p=>p.LeaveTypeId)
            .NotNull()
            .MustAsync(LeaveTypeMustExist)
            .WithMessage("{PropertyName} does not exist");
    }

    private async Task<bool> LeaveTypeMustExist(string id, CancellationToken token)
    {
        var leaveType = await _leaveTypeRepository.GetAsyncById(id);
        return leaveType != null;
    }
}