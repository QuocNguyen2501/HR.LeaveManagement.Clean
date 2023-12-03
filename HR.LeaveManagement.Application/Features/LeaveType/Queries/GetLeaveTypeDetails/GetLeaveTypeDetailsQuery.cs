using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
public record GetLeaveTypeDetailsQuery(string Id):IRequest<LeaveTypeDetailsDto>;