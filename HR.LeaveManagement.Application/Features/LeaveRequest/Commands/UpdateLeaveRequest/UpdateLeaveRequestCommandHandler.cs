using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;

public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
{
    private IMapper _mapper;
    private ILeaveRequestRepository _leaveRequestRepository;
    private ILeaveTypeRepository _leaveTypeRepository;

    public UpdateLeaveRequestCommandHandler(
        IMapper mapper,
        ILeaveRequestRepository leaveRequestRepository,
        ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
        _leaveTypeRepository = leaveTypeRepository;
    }
    public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);
        if (leaveRequest is null)
        {
            throw new NotFoundException(nameof(Domain.LeaveRequest), request.Id);
        }

        var validator = new UpdateLeaveRequestCommandValidation(_leaveTypeRepository, _leaveRequestRepository);
        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
        {
            throw new BadRequestException("Invalid Leave Request", validationResult);
        }
        _mapper.Map(request, leaveRequest);
        await _leaveRequestRepository.UpdateAsync(leaveRequest);

        return Unit.Value;
    }
}