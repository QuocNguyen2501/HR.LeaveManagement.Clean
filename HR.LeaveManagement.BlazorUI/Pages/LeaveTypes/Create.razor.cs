using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Models.LeaveTypes;
using Microsoft.AspNetCore.Components;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveTypes;

public partial class Create
{
	[Inject]
	NavigationManager NavigationManager { get; set; }

	[Inject]
	ILeaveTypeService LeaveTypeService { get; set; }
	public string Message { get; private set; }
	public LeaveTypeVM LeaveType { get; set; } = new LeaveTypeVM();


	public async Task CreateLeaveType()
	{
		var response = await LeaveTypeService.CreateLeaveType(LeaveType);
		if(response.Success)
		{
			NavigationManager.NavigateTo("/leavetypes/");
		}
		Message = response.Message;
	}
}