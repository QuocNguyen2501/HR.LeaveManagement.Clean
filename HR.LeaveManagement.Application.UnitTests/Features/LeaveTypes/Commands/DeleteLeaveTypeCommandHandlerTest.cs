using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace HR.LeaveManagement.Application.UnitTests.Features.LeaveTypes.Commands
{
    public class DeleteLeaveTypeCommandHandlerTest
    {
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        private readonly Mock<IAppLogger<DeleteLeaveTypeCommandHandler>> _mockLogger;
        public DeleteLeaveTypeCommandHandlerTest()
        {
            _mockRepo = MockLeaveTypeRepository.InitialLeaveTypeMockRepository();
            _mockLogger = new Mock<IAppLogger<DeleteLeaveTypeCommandHandler>>();
        }


        [Fact]
        public async Task DeleteLeaveTypeTest()
        {
            var handler = new DeleteLeaveTypeCommandHandler(_mockRepo.Object, _mockLogger.Object);
            await handler.Handle(new DeleteLeaveTypeCommand("e3e5e97d-d283-4901-9d3d-37fd131ac7bf"),CancellationToken.None);
            MockLeaveTypeRepository.mockDb.Count.ShouldBe(2);
        }
    }
}
