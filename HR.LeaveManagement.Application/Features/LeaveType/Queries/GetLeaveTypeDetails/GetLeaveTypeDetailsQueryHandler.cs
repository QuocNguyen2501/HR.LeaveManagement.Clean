using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
{
    private IMapper _mapper;
    private ILeaveTypeRepository _leaveTypeRepository;
    private IAppLogger<GetLeaveTypeDetailsQueryHandler> _logger;
    public GetLeaveTypeDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository, IAppLogger<GetLeaveTypeDetailsQueryHandler> logger)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
        _logger = logger;
    }

    public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
    {
        var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);

        if(leaveType==null){
            throw new NotFoundException(nameof(Domain.LeaveType), request.Id);
        }

        var data = _mapper.Map<LeaveTypeDetailsDto>(leaveType);
        _logger.LogInformation("Leave type was retrieved successfully");
        return data;
    }
}
