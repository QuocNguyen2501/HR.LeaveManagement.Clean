using Moq;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.UnitTests.Mocks;

public class MockLeaveTypeRepository
{
    private static List<LeaveType> mockDb = new List<LeaveType>
        {
            new LeaveType
            {
                Id = "5b42de3b-0b2b-40ab-ba53-fe3de782acdf",
                DefaultDays = 10,
                Name = "Test Vacation"
            },
            new LeaveType
            {
                Id = "b80194ce-25f3-41ed-900f-2bfa801e2a81",
                DefaultDays = 15,
                Name = "Test Sick"
            },
            new LeaveType
            {
                Id = "e3e5e97d-d283-4901-9d3d-37fd131ac7bf",
                DefaultDays = 15,
                Name = "Test Maternity"
            }
        };
    public static Mock<ILeaveTypeRepository> GetLeaveTypesMockLeaveTypeRepository()
    {
        var mockRepo = new Mock<ILeaveTypeRepository>();
        mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(mockDb);
        return mockRepo;
    }
}