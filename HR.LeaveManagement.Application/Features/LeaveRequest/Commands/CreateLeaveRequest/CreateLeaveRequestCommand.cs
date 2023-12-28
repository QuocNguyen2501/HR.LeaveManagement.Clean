using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;

public class CreateLeaveRequestCommand:IRequest<string>
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string LeaveTypeId { get; set; }
    public DateTime DateRequested { get; set; }
    public string RequestComments { get; set; }
    public LeaveRequestStatus Status { get; set; } = LeaveRequestStatus.New;
    public string RequestingEmployeedId { get; set; }
}