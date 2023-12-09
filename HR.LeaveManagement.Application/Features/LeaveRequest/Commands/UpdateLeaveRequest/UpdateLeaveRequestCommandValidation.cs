using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveRequest.Shared;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;
public class UpdateLeaveRequestCommandValidation : AbstractValidator<UpdateLeaveRequestCommand>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    public UpdateLeaveRequestCommandValidation(ILeaveTypeRepository leaveTypeRepository,ILeaveRequestRepository leaveRequestRepository)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _leaveTypeRepository = leaveTypeRepository;

        Include(new BaseLeaveRequestValidator(_leaveTypeRepository));

        RuleFor(p=>p.Id).NotNull().MustAsync(LeaveRequestMustExist).WithMessage("{PropertyName} must be present");
    }

    private async Task<bool> LeaveRequestMustExist(string id, CancellationToken token)
    {
        var leaveRequest = await _leaveRequestRepository.GetAsyncById(id);
        return leaveRequest != null;
    }
}