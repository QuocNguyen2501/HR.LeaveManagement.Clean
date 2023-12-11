using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, string>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IAppLogger<CreateLeaveAllocationCommandHandler> _logger;
        public CreateLeaveAllocationCommandHandler(
            IMapper mapper, 
            ILeaveAllocationRepository leaveAllocationRepository,
            IAppLogger<CreateLeaveAllocationCommandHandler> logger)
        {
            _mapper = mapper;
            _leaveAllocationRepository = leaveAllocationRepository;
            _logger = logger;
        }

        public async Task<string> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validation = new CreateLeaveAllocationCommandValidation();
            var validationResult = await validation.ValidateAsync(request);
            if(validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid LeaveType", validationResult);
            }
            var leaveAllocaTionCreate = _mapper.Map<Domain.LeaveAllocation>(request);
            await _leaveAllocationRepository.CreateAsync(leaveAllocaTionCreate);

            _logger.LogInformation("Created Leave Allocation successfully");

            return leaveAllocaTionCreate.Id;
        }
    }
}
