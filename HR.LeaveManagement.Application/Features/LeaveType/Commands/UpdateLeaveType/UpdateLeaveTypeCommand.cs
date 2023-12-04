using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommand : IRequest<Unit>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int DefaultDays { get; set; }
}