using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(HrDatabaseContext context) : base(context)
        {
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetailsAsync()
        {
            return await _context.LeaveRequests
                .Where(q=>!string.IsNullOrEmpty(q.RequestingEmployeedId))
                .Include(i => i.LeaveType)
                .ToListAsync();
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string userId)
        {
            return await _context.LeaveRequests
                .Where(w=>w.RequestingEmployeedId == userId)
                .Include(i => i.LeaveType)
                .ToListAsync();
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetailsAsync(string id)
        {
            return await _context.LeaveRequests
               .Include(i => i.LeaveType)
               .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
