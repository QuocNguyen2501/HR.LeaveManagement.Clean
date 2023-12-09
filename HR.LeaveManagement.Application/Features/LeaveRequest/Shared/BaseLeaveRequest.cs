namespace HR.LeaveManagement.Application.Features.LeaveRequest.Shared;

public abstract class BaseLeaveRequest
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string LeaveTypeId { get; set; }
}