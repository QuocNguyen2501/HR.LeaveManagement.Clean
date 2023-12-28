using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
{
    Task<LeaveRequest> GetLeaveRequestWithDetailsAsync(string id);
    Task<List<LeaveRequest>> GetLeaveRequestWithDetailsAsync();
    Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string userId);
}