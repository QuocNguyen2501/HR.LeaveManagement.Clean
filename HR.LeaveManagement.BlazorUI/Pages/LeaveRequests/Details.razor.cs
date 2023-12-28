using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Models.LeaveRequests;
using Microsoft.AspNetCore.Components;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveRequests;

public partial class Details
{
	[Inject]
	ILeaveRequestService LeaveRequestService { get; set; }

	[Inject]
	NavigationManager NavigationManager { get; set; }

	[Parameter]
	public string id {  get; set; }

	string ClassName;
	string HeadingText;

	public LeaveRequestVM Model { get; private set; } = new LeaveRequestVM();

	protected override async Task OnParametersSetAsync()
	{
		Model = await LeaveRequestService.GetLeaveRequest(id);
	}

	protected override void OnInitialized()
	{
		switch (Model.Status) {
			case LeaveRequestStatus.New:
				ClassName = "warning";
				HeadingText = "Pending Approval";
				break;
			case LeaveRequestStatus.Approved:
				ClassName = "success";
				HeadingText = "Approved";
				break;
			case LeaveRequestStatus.Rejected:
				ClassName = "danger";
				HeadingText = "Rejected";
				break;
			default:
				break;
		}
	}

	public async Task ChangeApproval(LeaveRequestStatus approvalStatus)
	{ 
		await LeaveRequestService.ApproveLeaveRequest(id, approvalStatus);
		NavigationManager.NavigateTo("/leaverequests/");
	}
}