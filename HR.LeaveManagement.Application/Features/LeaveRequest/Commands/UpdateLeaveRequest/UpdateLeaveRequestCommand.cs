using HR.LeaveManagement.Application.Features.LeaveRequest.Shared;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;

public class UpdateLeaveRequestCommand:BaseLeaveRequest, IRequest<Unit>
{
    public string Id { get; set; }
    public string RequestComments { get; set; }
    public bool Cancelled { get; set; }
}