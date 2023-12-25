using Blazored.LocalStorage;
using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Models.LeaveRequests;
using HR.LeaveManagement.BlazorUI.Services.Base;

namespace HR.LeaveManagement.BlazorUI.Services;

public class LeaveRequestService : BaseHttpService, ILeaveRequestService
{
    public LeaveRequestService(IClient client, ILocalStorageService localStorage) : base(client,localStorage)
    {
    }

    public Task<Response<Guid>> ApproveLeaveRequest(int id, bool approved)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Guid>> CancelLeaveRequest(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Guid>> CreateLeaveRequest(LeaveRequestVM leaveRequest)
    {
        throw new NotImplementedException();
    }

    public Task DeleteLeaveRequest(int id)
    {
        throw new NotImplementedException();
    }

    public Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList()
    {
        throw new NotImplementedException();
    }

    public Task<LeaveRequestVM> GetLeaveRequest(int id)
    {
        throw new NotImplementedException();
    }

    public Task<EmployeeLeaveRequestViewVM> GetUserLeaveRequests()
    {
        throw new NotImplementedException();
    }
}
