using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestsByUserId;

public record GetLeaveRequestsByUserIdQuery(string userId):IRequest<List<LeaveRequestDto>>;

