using System.ComponentModel.DataAnnotations;
using HR.LeaveManagement.BlazorUI.Models.LeaveTypes;

namespace HR.LeaveManagement.BlazorUI.Models.LeaveRequests;

public class LeaveRequestVM : IValidatableObject
{
    public string Id { get; set; }

    [Display(Name = "Date Requested")]
    public DateTime DateRequested { get; set; } = DateTime.UtcNow;

    public LeaveTypeVM LeaveType { get; set; } = new LeaveTypeVM();
    public EmployeeVM Employee { get; set; } = new EmployeeVM();
    public string EmployeeId { get; set; } 

    [Display(Name = "Start Date")]
    [Required]
    public DateTime StartDate { get; set; } = DateTime.UtcNow;

    [Display(Name = "End Date")]
    [Required]
    public DateTime EndDate { get; set; } = DateTime.UtcNow;

	[Display(Name = "Leave Type")]
    [Required]
    public string LeaveTypeId { get; set; }

    [Display(Name = "Comments")]
    [MaxLength(300)]
    public string? RequestComments { get; set; }

    public LeaveRequestStatus Status { get; set; }

	public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
	{
		if (EndDate <= StartDate)
		{
			yield return new ValidationResult(
				errorMessage: "EndDate must be greater than StartDate",
				memberNames: new[] { "EndDate" }
		   );
		}
	}
}

