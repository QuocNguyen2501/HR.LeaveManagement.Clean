using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
        private IMapper _mapper;
        private ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IAppLogger<UpdateLeaveAllocationCommandHandler> _logger;

        public UpdateLeaveAllocationCommandHandler(
            IMapper mapper, 
            ILeaveAllocationRepository leaveAllocationRepository,
            IAppLogger<UpdateLeaveAllocationCommandHandler> logger
            )
        {
            _mapper = mapper;
            _leaveAllocationRepository = leaveAllocationRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveAllocationCommandValidation(_leaveAllocationRepository);
            var validatorResult = validator.Validate(request);
            if(validatorResult.IsValid)
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Domain.LeaveAllocation), request.Id);
                throw new BadRequestException("Invalid Leave Allocation", validatorResult);
            }



            var leaveAllocation = _mapper.Map<Domain.LeaveAllocation>(request);

            await _leaveAllocationRepository.UpdateAsync(leaveAllocation);

            _logger.LogInformation("Updated Leave Allocation successfully");
            return Unit.Value;
        }
    }
}
