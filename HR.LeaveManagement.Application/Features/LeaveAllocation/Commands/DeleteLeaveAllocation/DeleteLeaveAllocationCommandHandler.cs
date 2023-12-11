using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation
{
    public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IAppLogger<DeleteLeaveAllocationCommandHandler> _logger;
        public DeleteLeaveAllocationCommandHandler(
            IMapper mapper, 
            ILeaveAllocationRepository leaveAllocationRepository,
            IAppLogger<DeleteLeaveAllocationCommandHandler> logger)
        {
            _mapper = mapper;
            _leaveAllocationRepository = leaveAllocationRepository;
            _logger = logger;
        }
        public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var deletedLeaveAllocation = await _leaveAllocationRepository.GetAsyncById(request.Id);

            if (deletedLeaveAllocation == null)
            {
                throw new NotFoundException(nameof(Domain.LeaveAllocation), request.Id);
            }

            await _leaveAllocationRepository.DeleteAsync(deletedLeaveAllocation);
            _logger.LogInformation("Deleted Leave Allocation successfully");
            return Unit.Value;
        }
    }
}
