using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;

public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, string>
{
    private readonly IMapper _mapper;
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IUserService _userService;

    public CreateLeaveRequestCommandHandler(
        IMapper mapper, 
        ILeaveRequestRepository leaveRequestRepository, 
        ILeaveAllocationRepository leaveAllocationRepository,
        IUserService userService)
    {
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
        _leaveAllocationRepository = leaveAllocationRepository;
        _userService = userService;
    }

    public async Task<string> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
		

		var validator = new CreateLeaveRequestCommandValidation();
        var validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            throw new BadRequestException("Invalid LeaveType", validationResult);
        }

		// Get requesting employee's id
		var employeeId = _userService.UserId;
		// Check on employee's allocation
		var allocation = await _leaveAllocationRepository.GetUserAllocations(employeeId, request.LeaveTypeId);
        // if allocations aren't enough, return validation error with message
        if (allocation is null)
        {
            validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure(nameof
                    (request.LeaveTypeId),"You do not have any allocations for this leave type."));
            throw new BadRequestException("Invalid Leave Request", validationResult);
        }
        int daysRequested = (int)(request.EndDate.Date - request.StartDate.Date).TotalDays;
        if(daysRequested > allocation.NumberOfDays) 
        {
            validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure(nameof
                    (request.EndDate), "You do not have enough days for this request"));
            throw new BadRequestException("Invalid Leave Request", validationResult);
        }

		// Create leave request
		var leaveRequest = _mapper.Map<Domain.LeaveRequest>(request);
        leaveRequest.RequestingEmployeedId = employeeId;
        leaveRequest.DateRequested = DateTime.UtcNow;
        await _leaveRequestRepository.CreateAsync(leaveRequest);

        return leaveRequest.Id;
    }
}