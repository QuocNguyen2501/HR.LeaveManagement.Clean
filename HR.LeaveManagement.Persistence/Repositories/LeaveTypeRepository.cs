using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
{

    public LeaveTypeRepository(HrDatabaseContext context):base(context)
    {
    }

    public async Task<bool> IsLeaveTypeUnique(string? id, string name)
    {
        if(string.IsNullOrEmpty(id))
            return !(await _context.LeaveTypes.AnyAsync(x => x.Name == name));
        else
			return !(await _context.LeaveTypes.AnyAsync(x => x.Id != id && x.Name == name));
	}
}
