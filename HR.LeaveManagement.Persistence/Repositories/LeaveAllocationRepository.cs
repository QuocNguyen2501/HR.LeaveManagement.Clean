using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
        {
        }

        public Task AddAllocations(List<LeaveAllocation> allocations)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AllocationExists(string userId, string leaveTypeId, int period)
        {
            throw new NotImplementedException();
        }

        public Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            throw new NotImplementedException();
        }

        public Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
        {
            throw new NotImplementedException();
        }
    }
}
