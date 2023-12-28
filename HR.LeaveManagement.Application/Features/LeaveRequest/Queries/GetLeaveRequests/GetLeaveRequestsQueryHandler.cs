using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequests
{
    public class GetLeaveRequestsQueryHandler : IRequestHandler<GetLeaveRequestsQuery, List<LeaveRequestDto>>
    {
        private IMapper _mapper;
        private ILeaveRequestRepository _leaveRequestRepository;
        private IUserService _userService;
        public GetLeaveRequestsQueryHandler(
            IMapper mapper, 
            ILeaveRequestRepository leaveRequestRepository,
			IUserService userService
			)
        {
            _mapper = mapper;
            _leaveRequestRepository = leaveRequestRepository;
			_userService = userService;

		}

        public async Task<List<LeaveRequestDto>> Handle(GetLeaveRequestsQuery request, CancellationToken cancellationToken)
        {

            var leaveRequests = new List<Domain.LeaveRequest>();
            var requests = new List<LeaveRequestDto>();
            // Check if it is logged in employee
            if(request.IsLoggedInUser)
            {
                var userId = _userService.UserId;
                leaveRequests = await _leaveRequestRepository.GetLeaveRequestsWithDetails(userId);

                var employee = await _userService.GetEmployee(userId);
                requests = _mapper.Map<List<LeaveRequestDto>>(leaveRequests);
                foreach(var req in requests)
                {
                    req.Employee = employee;
                }
            }
            else
            {
                leaveRequests = await _leaveRequestRepository.GetLeaveRequestWithDetailsAsync();
                requests = _mapper.Map<List<LeaveRequestDto>>(leaveRequests);
                foreach (var req in requests)
                {
                    req.Employee = await _userService.GetEmployee(req.RequestingEmployeedId);
                }
            }
            return requests;
        }
    }
}
