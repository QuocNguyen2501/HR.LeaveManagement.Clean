using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails;

internal class GetLeaveRequestDetailsQueryHandler : IRequestHandler<GetLeaveRequestDetailsQuery, LeaveRequestDetailsDto>
{
    private IMapper _mapper;
    private ILeaveRequestRepository _leaveRequestRepository;
    public GetLeaveRequestDetailsQueryHandler(IMapper mapper, ILeaveRequestRepository  leaveRequestRepository)
    {
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
    }

    public async Task<LeaveRequestDetailsDto> Handle(GetLeaveRequestDetailsQuery request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetLeaveRequestWithDetailsAsync(request.Id);
        if(leaveRequest == null)
        {
            throw new NotFoundException(nameof(Domain.LeaveRequest), request.Id);
        }
        return _mapper.Map<LeaveRequestDetailsDto>(leaveRequest);
    }
}
