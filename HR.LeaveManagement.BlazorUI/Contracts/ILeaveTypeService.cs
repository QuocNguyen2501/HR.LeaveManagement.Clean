using HR.LeaveManagement.BlazorUI.Models.LeaveTypes;
using HR.LeaveManagement.BlazorUI.Services.Base;

namespace HR.LeaveManagement.BlazorUI.Contracts
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveTypeVM>> GetLeaveTypes();
        Task<LeaveTypeVM> GetLeaveTypeDetails(string id);
        Task<Response<Guid>> CreateLeaveType(LeaveTypeVM leaveType);
        Task<Response<Guid>> UpdateLeaveType(string id, LeaveTypeVM leaveType);
        Task<Response<Guid>> DeleteLeaveType(string id);
    }
}
