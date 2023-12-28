using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Models.LeaveTypes;
using Microsoft.AspNetCore.Components;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveTypes;

public partial class Edit
{
	[Inject]
	ILeaveTypeService LeaveTypeService { get; set; }

	[Inject]
	NavigationManager NavigationManager { get; set; }

	[Parameter]
	public string id { get; set; }

	public string Message { get; private set; }

	LeaveTypeVM LeaveTypeVM { get; set; } = new LeaveTypeVM();

	protected override async Task OnParametersSetAsync()
	{
		LeaveTypeVM = await LeaveTypeService.GetLeaveTypeDetails(id);
	}

	public async Task EditLeaveType()
	{
		var response = await LeaveTypeService.UpdateLeaveType(id, LeaveTypeVM);
		if (response.Success)
		{
			NavigationManager.NavigateTo("/leavetypes/");
		}
		Message = response.Message;
	}
}