using HR.LeaveManagement.BlazorUI.Models.LeaveTypes;
using System.ComponentModel.DataAnnotations;


namespace HR.LeaveManagement.BlazorUI.Models.LeaveAllocations;

public class LeaveAllocationVM
{
    public string Id { get; set; }
    [Display(Name = "Number Of Days")]

    public int NumberOfDays { get; set; }
    public int Period { get; set; }

    public LeaveTypeVM LeaveType { get; set; }
    public string LeaveTypeId { get; set; }
}

