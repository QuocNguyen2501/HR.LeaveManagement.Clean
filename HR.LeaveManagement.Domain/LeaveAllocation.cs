using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Domain;

public class LeaveAllocation: BaseEntity
{
    public int NumberOfDays { get; set; }
    public LeaveType LeaveType { get; set; }
    public string LeaveTypeId { get; set; }
    public int Period { get; set; }
    public string EmployeeId { get; set; }
}