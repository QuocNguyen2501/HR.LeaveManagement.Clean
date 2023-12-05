using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType;

public class DeleteLeaveTypeCommand : IRequest<Unit>
{
    public string Id { get; set; }

    public DeleteLeaveTypeCommand(string id)
    {
        Id = id;
    }
}