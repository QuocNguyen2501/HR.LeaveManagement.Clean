using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;

public class CreateLeaveAllocationCommand: IRequest<string>
{
    public int NumberOfDays { get; set; }
    public string LeaveTypeId { get; set; }
    public int Period { get; set; }
}
