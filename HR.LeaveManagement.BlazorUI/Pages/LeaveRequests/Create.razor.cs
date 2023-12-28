using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Models.LeaveRequests;
using HR.LeaveManagement.BlazorUI.Models.LeaveTypes;
using Microsoft.AspNetCore.Components;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveRequests;

public partial class Create
{
	LeaveRequestVM LeaveRequest { get; set; } = new LeaveRequestVM();
	List<LeaveTypeVM> LeaveTypes { get; set; } = new List<LeaveTypeVM>();

	[Inject]
	ILeaveTypeService LeaveTypeService { get; set; }
	[Inject]
	ILeaveRequestService LeaveRequestService { get; set; }
	[Inject]
	NavigationManager NavigationManager { get; set; }

	protected override async Task OnInitializedAsync()
	{
		LeaveTypes = await LeaveTypeService.GetLeaveTypes();
	}
	private async Task HandleValidSubmit()
	{
		await LeaveRequestService.CreateLeaveRequest(LeaveRequest);
		NavigationManager.NavigateTo("/leaverequests");
	}
}