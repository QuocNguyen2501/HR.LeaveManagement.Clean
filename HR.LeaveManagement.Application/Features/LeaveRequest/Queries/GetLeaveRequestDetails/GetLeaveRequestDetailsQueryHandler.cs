using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails;

internal class GetLeaveRequestDetailsQueryHandler : IRequestHandler<GetLeaveRequestDetailsQuery, LeaveRequestDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IUserService _userService;
    public GetLeaveRequestDetailsQueryHandler(IMapper mapper, ILeaveRequestRepository  leaveRequestRepository, IUserService userService)
    {
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
		_userService = userService;
	}

    public async Task<LeaveRequestDetailsDto> Handle(GetLeaveRequestDetailsQuery request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetLeaveRequestWithDetailsAsync(request.Id);
        if(leaveRequest == null)
        {
            throw new NotFoundException(nameof(Domain.LeaveRequest), request.Id);
        }
        var result = _mapper.Map<LeaveRequestDetailsDto>(leaveRequest);
        result.Employee = await _userService.GetEmployee(leaveRequest.RequestingEmployeedId);
		return result;
    }
}
