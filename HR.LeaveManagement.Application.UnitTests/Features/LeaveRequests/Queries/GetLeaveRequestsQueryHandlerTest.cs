using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.MappingProfiles;
using Moq;

namespace HR.LeaveManagement.Application.UnitTests.Features.LeaveRequests.Queries
{
    public class GetLeaveRequestsQueryHandlerTest
    {
        private readonly Mock<ILeaveRequestRepository> _mockRepo;
        private readonly IMapper _mapper;
        private readonly Mock<IUserService> _mockUserService;
        public GetLeaveRequestsQueryHandlerTest(IMapper mapper, ILeaveRequestRepository leaveRequestRepository, IUserService userService)
        {
            _mapper = new MapperConfiguration(c=>
            {
                c.AddProfile<LeaveRequestProfile>();
            }).CreateMapper();

            
        }
    }
}
