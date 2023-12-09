using FluentValidation;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;

public class CreateLeaveRequestCommandValidation : AbstractValidator<CreateLeaveRequestCommand>
{
    public CreateLeaveRequestCommandValidation()
    {
        RuleFor(p => p.StartDate).NotNull();
        RuleFor(p => p.EndDate).NotNull();
        RuleFor(p => p.LeaveTypeId).NotNull();
        RuleFor(p => p.DateRequested).NotNull();
        RuleFor(p => p.RequestComments).NotNull().MaximumLength(255);
        RuleFor(p => p.Status).NotNull();
        RuleFor(p => p.RequestingEmployeedId).NotNull();
    }
}