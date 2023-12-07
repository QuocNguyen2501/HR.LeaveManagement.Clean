using MediatR;
using HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequests;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequests
{
    public record GetLeaveRequestsQuery:IRequest<List<LeaveRequestDto>>;
}
