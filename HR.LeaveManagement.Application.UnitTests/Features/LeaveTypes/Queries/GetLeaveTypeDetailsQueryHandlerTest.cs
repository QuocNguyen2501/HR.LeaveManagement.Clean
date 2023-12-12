using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using HR.LeaveManagement.Application.MappingProfiles;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace HR.LeaveManagement.Application.UnitTests.Features.LeaveTypes.Queries
{
    public class GetLeaveTypeDetailsQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        private readonly Mock<IAppLogger<GetLeaveTypeDetailsQueryHandler>> _loggerMock;
        public GetLeaveTypeDetailsQueryHandlerTest()
        {
            _mockRepo = MockLeaveTypeRepository.InitialLeaveTypeMockRepository();
            _loggerMock = new Mock<IAppLogger<GetLeaveTypeDetailsQueryHandler>>();
            _mapper = new MapperConfiguration(c =>
            {
                c.AddProfile<LeaveTypeProfile>();
            }).CreateMapper();
        }

        [Fact]
        public async Task GetLeaveTypeDetails()
        {
            var handler = new GetLeaveTypeDetailsQueryHandler(_mapper, _mockRepo.Object, _loggerMock.Object);
            var result = await handler.Handle(new GetLeaveTypeDetailsQuery("b80194ce-25f3-41ed-900f-2bfa801e2a81"),CancellationToken.None);
            (result.Id == "b80194ce-25f3-41ed-900f-2bfa801e2a81").ShouldBeTrue();
        }
    }
}
