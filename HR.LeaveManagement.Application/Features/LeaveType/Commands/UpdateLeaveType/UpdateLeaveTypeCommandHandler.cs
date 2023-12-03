using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
{
    private IMapper _mapper;
    private ILeaveTypeRepository _leaveTypeRepository;
    public UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }
    public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        // Validate incoming data

        // Convert to domain entity object
        var leaveType = _mapper.Map<Domain.LeaveType>(request);
        // Update to database
        await _leaveTypeRepository.UpdateAsync(leaveType);
        // return Unit value
        return Unit.Value;
    }
}