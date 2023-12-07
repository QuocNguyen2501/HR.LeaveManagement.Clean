using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestsByUserId;

public class GetLeaveRequestsByUserIdQueryHandler : IRequestHandler<GetLeaveRequestsByUserIdQuery, List<LeaveRequestDto>>
{
    private readonly IMapper _mapper;
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public GetLeaveRequestsByUserIdQueryHandler(IMapper mapper, ILeaveRequestRepository leaveRequestRepository)
    {
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
    }

    public async Task<List<LeaveRequestDto>> Handle(GetLeaveRequestsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var leaveRequests = await _leaveRequestRepository.GetLeaveRequestsByUserIdAsync(request.userId);
        return _mapper.Map<List<LeaveRequestDto>>(leaveRequests);
    }
}
