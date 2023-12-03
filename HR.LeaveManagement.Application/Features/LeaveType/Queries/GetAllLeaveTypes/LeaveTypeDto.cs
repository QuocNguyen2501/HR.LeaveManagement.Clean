namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public class LeaveTypeDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int DefaultDays { get; set; }
}