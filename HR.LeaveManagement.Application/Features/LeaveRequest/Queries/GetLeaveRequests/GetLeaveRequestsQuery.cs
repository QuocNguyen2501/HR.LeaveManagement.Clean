using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequests;

public record GetLeaveRequestsQuery:IRequest<List<LeaveRequestDto>>
{
	public bool IsLoggedInUser { get; set; }
}
