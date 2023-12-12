using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;

public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, string>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IAppLogger<CreateLeaveTypeCommandHandler> _logger;
    public CreateLeaveTypeCommandHandler(
        IMapper mapper, 
        ILeaveTypeRepository leaveTypeRepository,
        IAppLogger<CreateLeaveTypeCommandHandler> logger)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
        _logger = logger;
    }

    public async Task<string> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        // Validate incoming data
        var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request);

        if(!validationResult.IsValid){
            throw new BadRequestException("Invalid LeaveType",validationResult);
        }

        // Convert to domain entity object
        var leaveTypeToCreate = _mapper.Map<Domain.LeaveType>(request);

        // Add to database
        await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);
        _logger.LogInformation("Created Leave Type successfully");
        return leaveTypeToCreate.Id;
    }
}