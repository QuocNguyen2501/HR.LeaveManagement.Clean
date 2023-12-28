using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;

public class CreateLeaveAllocationCommand: IRequest<Unit>
{
    public string LeaveTypeId { get; set; }
}
