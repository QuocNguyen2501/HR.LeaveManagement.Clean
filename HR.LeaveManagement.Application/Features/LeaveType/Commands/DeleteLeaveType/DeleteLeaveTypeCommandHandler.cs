using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType;

public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IAppLogger<DeleteLeaveTypeCommandHandler> _logger;

    public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IAppLogger<DeleteLeaveTypeCommandHandler> logger) 
    { 
        _leaveTypeRepository = leaveTypeRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        // retrieve domain entity object
        var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);

        //verify that record exist
        if (leaveType == null)
        {
            throw new NotFoundException(nameof(Domain.LeaveType), request.Id);
        }

        // delete from database
        await _leaveTypeRepository.DeleteAsync(leaveType);
        _logger.LogInformation("Deleted Leave Type successfully");

        return Unit.Value;
    }
}

