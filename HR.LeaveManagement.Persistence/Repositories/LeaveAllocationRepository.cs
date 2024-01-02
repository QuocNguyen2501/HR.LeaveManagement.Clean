using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
        {
        }

        public async Task AddAllocations(List<LeaveAllocation> allocations)
        {
            await _context.AddRangeAsync(allocations);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AllocationExists(string userId, string leaveTypeId, int period)
        {
           
                return await _context.LeaveAllocations.AnyAsync(q => q.EmployeeId == userId
                                                                    && q.LeaveTypeId == leaveTypeId
                                                                    && q.Period == period);
            
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            var leaveAllocations = await _context.LeaveAllocations.Include(q => q.LeaveType).ToListAsync();
            return leaveAllocations;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId)
        {
			var leaveAllocations = await _context.LeaveAllocations.Where(q => q.EmployeeId == userId)
				.Include(q => q.LeaveType)
				.ToListAsync();
			return leaveAllocations;
		}

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(string id)
        {
          return await _context.LeaveAllocations.FirstOrDefaultAsync(w => w.Id == id);
		}

        public async Task<LeaveAllocation> GetUserAllocations(string userId, string leaveTypeId)
        {
            var leaveAllocation = await _context.LeaveAllocations.FirstOrDefaultAsync(w => w.EmployeeId == userId && w.LeaveTypeId == leaveTypeId);
            return leaveAllocation;
        }
    }
}
