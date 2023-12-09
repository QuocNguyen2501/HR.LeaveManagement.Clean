
using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.DeleteLeaveRequest;

public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand, Unit>
{
    private IMapper _mapper;
    private ILeaveRequestRepository _leaveRequestRepository;
    public DeleteLeaveRequestCommandHandler(IMapper mapper, ILeaveRequestRepository leaveRequestRepository)
    {
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
    }

    public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetAsyncById(request.id);
        if (leaveRequest == null)
        {
            throw new NotFoundException(nameof(Domain.LeaveRequest), request.id);
        }
        await _leaveRequestRepository.DeleteAsync(leaveRequest);
        return Unit.Value;
    }
}