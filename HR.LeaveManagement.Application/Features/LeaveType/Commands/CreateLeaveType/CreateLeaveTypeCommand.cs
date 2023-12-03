using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;

public class CreateLeaveTypeCommand : IRequest<string>
{
    public string Name { get; set; }
    public int DefaultDays { get; set; }
}
