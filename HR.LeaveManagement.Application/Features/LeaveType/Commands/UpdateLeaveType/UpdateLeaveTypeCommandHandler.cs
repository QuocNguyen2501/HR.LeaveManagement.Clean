using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
{
    private IMapper _mapper;
    private ILeaveTypeRepository _leaveTypeRepository;
    private readonly IAppLogger<UpdateLeaveTypeCommandHandler> _logger;

    public UpdateLeaveTypeCommandHandler(
        IMapper mapper, 
        ILeaveTypeRepository leaveTypeRepository, 
        IAppLogger<UpdateLeaveTypeCommandHandler> logger)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
        _logger = logger;
    }
    public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
		var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);
		if (leaveType is null)
		{
			throw new NotFoundException(nameof(Domain.LeaveType), request.Id);
		}
		// Validate incoming data
		var validator = new UpdateLeaveTypeCommandValidator(_leaveTypeRepository);
        var validatorResult = await validator.ValidateAsync(request);
        if(validatorResult.Errors.Any())
        {
            _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(LeaveType), request.Id);
            throw new BadRequestException("Invalid Leave Type", validatorResult);
        }

		// Convert to domain entity object
		leaveType.DefaultDays = request.DefaultDays;
        leaveType.Name = request.Name;
		// Update to database
		await _leaveTypeRepository.UpdateAsync(leaveType);
        // return Unit value
        return Unit.Value;
    }
}