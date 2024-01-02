using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;

public record GetLeaveAllocationsQuery(bool isLoggedInUser) :IRequest<List<LeaveAllocationDto>>
{
}
