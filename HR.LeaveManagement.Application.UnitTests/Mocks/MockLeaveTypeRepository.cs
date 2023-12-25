using Moq;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.UnitTests.Mocks;

public class MockLeaveTypeRepository
{
    public static List<LeaveType> mockDb = new List<LeaveType>
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
    public static Mock<ILeaveTypeRepository> InitialLeaveTypeMockRepository() 
    {
        var mockRepo = new Mock<ILeaveTypeRepository>();
        mockRepo.Setup(r => r.IsLeaveTypeUnique(It.IsAny<string>()))
            .Returns((string name) =>
            {
                var result = mockDb.Any(a => a.Name != name);
                return Task.FromResult(result);
            });
        mockRepo.Setup(r => r.CreateAsync(It.IsAny<LeaveType>()))
                .Returns((LeaveType leaveType) => {
                    mockDb.Add(leaveType);
                    return Task.CompletedTask;
                });
        mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(mockDb);
        mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<string>()))
            .Returns((string id) =>
            {
                var result = mockDb.Find(f => f.Id == id);
                return Task.FromResult(result);
            });
        mockRepo.Setup(r => r.DeleteAsync(It.IsAny<LeaveType>()))
            .Returns((LeaveType leaveType) =>
            {
                mockDb.Remove(leaveType);
                return Task.CompletedTask;
            });
        mockRepo.Setup(r => r.UpdateAsync(It.IsAny<LeaveType>()))
            .Returns((LeaveType leaveType) =>
            {
                var target = mockDb.Find(f => f.Id == leaveType.Id);
                target.Name = leaveType.Name;
                target.DefaultDays = leaveType.DefaultDays;
                return Task.CompletedTask;
            });
        return mockRepo;
    }
}