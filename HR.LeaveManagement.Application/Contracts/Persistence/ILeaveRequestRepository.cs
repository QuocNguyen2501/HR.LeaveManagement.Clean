using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
{
    Task<LeaveRequest> GetLeaveRequestWithDetailsAsync(string id);
    Task<List<LeaveRequest>> GetLeaveRequestsAsync();
    Task<List<LeaveRequest>> GetLeaveRequestsByUserIdAsync(string userId);
}