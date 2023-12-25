using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;

public class GetLeaveAllocationDetailsQueryHandler : IRequestHandler<GetLeaveAllocationDetailsQuery, LeaveAllocationDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IAppLogger<GetLeaveAllocationDetailsQueryHandler> _logger;
    public GetLeaveAllocationDetailsQueryHandler(
        IMapper mapper,
        ILeaveAllocationRepository leaveAllocationRepository,
        IAppLogger<GetLeaveAllocationDetailsQueryHandler> logger
        )
    {
        _mapper = mapper;
        _leaveAllocationRepository = leaveAllocationRepository;
        _logger = logger;
    }

    public async Task<LeaveAllocationDetailsDto> Handle(GetLeaveAllocationDetailsQuery request, CancellationToken cancellationToken)
    {
        var leaveAllocation = await _leaveAllocationRepository.GetByIdAsync(request.Id);
        if (leaveAllocation == null)
        {
            throw new NotFoundException(nameof(Domain.LeaveAllocation), request.Id);
        }
        _logger.LogInformation("Leave Allocation was retrieved successfully");
        return _mapper.Map<LeaveAllocationDetailsDto>(leaveAllocation);
    }
}
