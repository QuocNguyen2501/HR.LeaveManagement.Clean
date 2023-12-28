using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface ILeaveAllocationRepository: IGenericRepository<LeaveAllocation>
{
    Task<LeaveAllocation> GetLeaveAllocationWithDetails(string id);
    Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails();
    Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId);
    Task<bool> AllocationExists(string userId, string leaveTypeId, int period);
    Task AddAllocations(List<LeaveAllocation> allocations);
    Task<LeaveAllocation> GetUserAllocations(string userId, string leaveTypeId);
}
