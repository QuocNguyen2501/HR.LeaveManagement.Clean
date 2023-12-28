using HR.LeaveManagement.BlazorUI.Models.LeaveRequests;
using HR.LeaveManagement.BlazorUI.Services.Base;

namespace HR.LeaveManagement.BlazorUI.Contracts;

public interface ILeaveRequestService
{
	Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList();
	Task<EmployeeLeaveRequestViewVM> GetUserLeaveRequests();
	Task<Response<Ulid>> CreateLeaveRequest(LeaveRequestVM leaveRequest);
	Task<LeaveRequestVM> GetLeaveRequest(string id);
	Task<Response<Ulid>> DeleteLeaveRequest(string id);
	Task<Response<Ulid>> ApproveLeaveRequest(string id, LeaveRequestStatus status);
	Task<Response<Ulid>> CancelLeaveRequest(string id);
}
