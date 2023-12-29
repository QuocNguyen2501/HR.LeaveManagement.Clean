using Microsoft.AspNetCore.Components;
using HR.LeaveManagement.BlazorUI.Models.LeaveTypes;
using HR.LeaveManagement.BlazorUI.Contracts;
using Microsoft.JSInterop;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveTypes;

public partial class Index
{
	[Inject]
	NavigationManager NavigationManager { get; set; }

	[Inject]
	ILeaveTypeService LeaveTypeService { get; set; }

	[Inject]
	ILeaveAllocationService LeaveAllocationService { get; set; }

	[Inject]
	IJSRuntime js { get; set; }


	public string Message { get; set; } = string.Empty;
	public List<LeaveTypeVM> LeaveTypes { get; private set; } = new List<LeaveTypeVM>();


	protected void CreateLeaveType()
	{
		NavigationManager.NavigateTo("/leavetypes/create");
	}

	protected void DetailsLeaveType(string id)
	{
		NavigationManager.NavigateTo($"leavetypes/details/{id}");
	}

	protected async Task AllocateLeaveType(string leaveTypeId,string leaveTypeName)
	{
		var confirm =  await js.InvokeAsync<bool>("confirm", $"Do you want to allocate {leaveTypeName} to your employees ?");
		if(confirm)
			await LeaveAllocationService.CreateLeaveAllocations(leaveTypeId);
	}

	protected async Task DeleteLeaveType(string id, string name)
	{
		var confirm = await js.InvokeAsync<bool>("confirm", $"Do you want to delete {name}");
		if (confirm)
		{
			var response = await LeaveTypeService.DeleteLeaveType(id);
			if (response.Success)
			{
				LeaveTypes = LeaveTypes.Where(d => d.Id != id).ToList();
			}
			else
			{
				Message = response.Message;
			}
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
