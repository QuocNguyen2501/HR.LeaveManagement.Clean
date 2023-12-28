using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation
{
	public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, Unit>
	{
		private readonly ILeaveAllocationRepository _leaveAllocationRepository;
		private readonly ILeaveTypeRepository _leaveTypeRepository;
		private readonly IUserService _userService;

		private readonly IMapper _mapper;
		private readonly IAppLogger<CreateLeaveAllocationCommandHandler> _logger;
		public CreateLeaveAllocationCommandHandler(
			IMapper mapper,
			IAppLogger<CreateLeaveAllocationCommandHandler> logger,
			ILeaveAllocationRepository leaveAllocationRepository,
			ILeaveTypeRepository leaveTypeRepository,
			IUserService userService)
		{
			_mapper = mapper;
			_leaveAllocationRepository = leaveAllocationRepository;
			_leaveTypeRepository = leaveTypeRepository;
			_userService = userService;
			_logger = logger;
		}

		public async Task<Unit> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
		{
			var validation = new CreateLeaveAllocationCommandValidation();
			var validationResult = await validation.ValidateAsync(request);
			if (validationResult.Errors.Any())
			{
				throw new BadRequestException("Invalid LeaveType", validationResult);
			}

			// Get Leave Type for Allocations
			var leaveType = await _leaveTypeRepository.GetByIdAsync(request.LeaveTypeId);

			// Get employees
			var employees = await _userService.GetStaffs();

			//Get Period
			var period = DateTime.UtcNow.Year;

			var allocations = new List<Domain.LeaveAllocation>();
			foreach (var employee in employees)
			{
				var allocationExists = await _leaveAllocationRepository.AllocationExists(employee.Id, leaveType.Id, period);
				if (!allocationExists)
				{

					var allocation = new Domain.LeaveAllocation
					{
						EmployeeId = employee.Id,
						LeaveTypeId = leaveType.Id,
						NumberOfDays = leaveType.DefaultDays,
						Period = period,
						Id = Ulid.NewUlid().ToString()
					};
					allocations.Add(allocation);
				}
			}

			if (allocations.Any())
			{
				await _leaveAllocationRepository.AddAllocations(allocations);
				_logger.LogInformation("Created Leave Allocation successfully");
			}

			return Unit.Value;
		}
	}
}
