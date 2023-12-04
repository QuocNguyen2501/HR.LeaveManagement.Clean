using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    public UpdateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        RuleFor(p=>p.Id)
            .NotNull()
            .MustAsync(LeaveTypeMustExist);
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

        RuleFor(p => p.DefaultDays)
            .GreaterThan(1).WithMessage("{PropertyName} cannot exceed 100")
            .LessThan(100).WithMessage("{PropertyName} cannot be less than 1");

        RuleFor(p=>p)
            .MustAsync(LeaveTypeNameUnique)
            .WithMessage("Leave type already exist");

        this._leaveTypeRepository = leaveTypeRepository;
    }

    private Task<bool> LeaveTypeNameUnique(UpdateLeaveTypeCommand command, CancellationToken token)
    {
        return _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
    }

    public async Task<bool> LeaveTypeMustExist(string id, CancellationToken token)
    {
        var leaveType = await _leaveTypeRepository.GetAsyncById(id);
        return leaveType != null;
    }
}