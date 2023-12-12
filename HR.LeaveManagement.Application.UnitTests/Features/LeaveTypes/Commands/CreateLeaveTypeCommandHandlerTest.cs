using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using HR.LeaveManagement.Application.MappingProfiles;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace HR.LeaveManagement.Application.UnitTests.Features.LeaveTypes.Commands
{
    public class CreateLeaveTypeCommandHandlerTest
    {
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        private readonly IMapper _mapper;
        private readonly Mock<IAppLogger<CreateLeaveTypeCommandHandler>> _mockLogger;
        public CreateLeaveTypeCommandHandlerTest()
        {
            _mockRepo = MockLeaveTypeRepository.InitialLeaveTypeMockRepository();
            _mapper = new MapperConfiguration(c =>
            {
                c.AddProfile<LeaveTypeProfile>();
            }).CreateMapper();
            _mockLogger = new Mock<IAppLogger<CreateLeaveTypeCommandHandler>>();
        }

        [Fact]
        public async Task CreateLeaveTypeTest()
        {
            var handler = new CreateLeaveTypeCommandHandler(_mapper, _mockRepo.Object, _mockLogger.Object);
            var result = await handler.Handle(new CreateLeaveTypeCommand
            {
                DefaultDays = 10,
                Name = "Annual Leave",
            }, CancellationToken.None);
            result.ShouldNotBeNullOrEmpty();
            MockLeaveTypeRepository.mockDb.Count.ShouldBe(4);
        }
    }
}
