using AutoMapper;
using MediatR;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.ChangeLeaveRequestApproval;


public class ChangeLeaveRequestApprovalCommandHandler : IRequestHandler<ChangeLeaveRequestApprovalCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
	private readonly ILeaveAllocationRepository _leaveAllocationRepository;

	public ChangeLeaveRequestApprovalCommandHandler(
        IMapper mapper,
        ILeaveRequestRepository leaveRequestRepository,
        ILeaveTypeRepository leaveTypeRepository,
        ILeaveAllocationRepository leaveAllocationRepository
        )
    {
        _leaveRequestRepository = leaveRequestRepository;
        _leaveTypeRepository = leaveTypeRepository;
		_leaveAllocationRepository = leaveAllocationRepository;
		_mapper = mapper;
    }

    public async Task<Unit> Handle(ChangeLeaveRequestApprovalCommand request, CancellationToken token)
    {
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

        if (leaveRequest is null)
        {
            throw new NotFoundException(nameof(Domain.LeaveRequest), request.Id);
        }

        leaveRequest.Status = request.Status;
        await _leaveRequestRepository.UpdateAsync(leaveRequest);

        if (leaveRequest.Status == LeaveRequestStatus.Approved)
        {
            int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
            var allocation = await _leaveAllocationRepository.GetUserAllocations(leaveRequest.RequestingEmployeedId, leaveRequest.LeaveTypeId);
            allocation.NumberOfDays -= daysRequested;

            await _leaveAllocationRepository.UpdateAsync(allocation);
        }
        else if (leaveRequest.Status == LeaveRequestStatus.Cancelled) {
            int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
            var allocation = await _leaveAllocationRepository.GetUserAllocations(leaveRequest.RequestingEmployeedId,leaveRequest.LeaveTypeId);
            allocation.NumberOfDays += daysRequested;

            await _leaveAllocationRepository.UpdateAsync(allocation);
        }

        return Unit.Value;
    }
}