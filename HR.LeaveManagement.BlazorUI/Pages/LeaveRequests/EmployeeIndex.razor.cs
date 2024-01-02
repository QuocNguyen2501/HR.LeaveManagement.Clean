using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Models.LeaveRequests;
using HR.LeaveManagement.BlazorUI.Services.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveRequests;

public partial class EmployeeIndex
{
    [Inject]
    ILeaveRequestService LeaveRequestService { get; set; }

    [Inject]
    IJSRuntime js { get; set; }

    [Inject]
    NavigationManager NavigationManager { get; set; }
    public EmployeeLeaveRequestViewVM Model { get; set; } = new EmployeeLeaveRequestViewVM();

    public string Message { get; set; } = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        Model = await LeaveRequestService.GetUserLeaveRequests();
    }

    async Task CancelRequestAsync(string id)
    {
        var confirm = await js.InvokeAsync<bool>("confirm", "Do you want to cancel this request?");
        if(confirm)
        {
            var response = await LeaveRequestService.CancelLeaveRequest(id);
            if (response != null)
            {
                StateHasChanged();
            }
            else
            {
                Message = response.Message;
            }
        }
    }
}