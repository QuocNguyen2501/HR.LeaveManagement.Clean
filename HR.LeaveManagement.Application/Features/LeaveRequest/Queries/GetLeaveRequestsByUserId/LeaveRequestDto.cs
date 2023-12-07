using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestsByUserId;

public class LeaveRequestDto
{
    public string Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string LeaveType { get; set; }
    public string LeaveTypeId { get; set; }
    public DateTime DateRequested { get; set; }
    public string RequestComments { get; set; }
    public LeaveRequestStatus Status { get; set; }
    public string RequestingEmployeedId { get; set; }
}
