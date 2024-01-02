using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;

public class GetLeaveAllocationsQueryHandler : IRequestHandler<GetLeaveAllocationsQuery, List<LeaveAllocationDto>>
{
    private readonly IMapper _mapper;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IAppLogger<GetLeaveAllocationsQueryHandler> _logger;
    private readonly IUserService _userService;
    public GetLeaveAllocationsQueryHandler(
        IMapper mapper,
        ILeaveAllocationRepository leaveAllocationRepository,
		IUserService userService,
		IAppLogger<GetLeaveAllocationsQueryHandler> logger
        )
    {
        _mapper = mapper;
        _leaveAllocationRepository = leaveAllocationRepository;
        _userService = userService;
		_logger = logger;
    }

    public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationsQuery request, CancellationToken cancellationToken)
    {
        if (request.isLoggedInUser)
        {
			var leaveAllocations = await _leaveAllocationRepository.GetLeaveAllocationsWithDetails(_userService.UserId);
			_logger.LogInformation("Leave Allocation were retrieved successfully");
			return _mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);
		}
        else
        {
            var leaveAllocations = await _leaveAllocationRepository.GetAsync();
            _logger.LogInformation("Leave Allocation were retrieved successfully");
            return _mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);
        }
    }
}
