using Microsoft.AspNetCore.Components;
using HR.LeaveManagement.BlazorUI.Models.LeaveTypes;
using HR.LeaveManagement.BlazorUI.Contracts;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveTypes;

public partial class Index
{
	[Inject]
	public NavigationManager NavigationManager { get; set; }

	[Inject]
	public ILeaveTypeService LeaveTypeService { get; set; }

	public string Message { get; set; } = string.Empty;
	public List<LeaveTypeVM> LeaveTypes { get; private set; }


	protected void CreateLeaveType()
	{
		NavigationManager.NavigateTo("/leavetypes/create");
	}

	protected void DetailsLeaveType(string id)
	{
		NavigationManager.NavigateTo($"leavetypes/details/{id}");
	}

	protected void AllocateLeaveType(string id)
	{

	}

	protected async Task DeleteLeaveType(string id)
	{
		var response = await LeaveTypeService.DeleteLeaveType(id);
		if (response.Success)
		{
			StateHasChanged();
		}
		else
		{
			Message = response.Message;
		}
	}

	protected void EditLeaveType(string id)
	{
		NavigationManager.NavigateTo($"leavetypes/edit/{id}");
	}


	protected override async Task OnInitializedAsync()
	{
		LeaveTypes = await LeaveTypeService.GetLeaveTypes();
	}
}
