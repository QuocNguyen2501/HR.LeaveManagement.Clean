
namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;

public class LeaveAllocationDto
{
    public string Id { get; set; }
    public int NumberOfDays { get; set; }
    public string LeaveType { get; set; }
    public string LeaveTypeId { get; set; }
    public int Period { get; set; }
}
