
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Moq;

namespace HR.LeaveManagement.Application.UnitTests.Mocks;

public class MockLeaveRequestRepository
{
    public static List<LeaveRequest> mockDb = new List<LeaveRequest>
    {
        new LeaveRequest
        {
            DateCreated = DateTime.UtcNow,
            DateModified = DateTime.UtcNow,
            DateRequested = DateTime.UtcNow,
            LeaveTypeId = "5b42de3b-0b2b-40ab-ba53-fe3de782acdf",
            RequestComments= "Personal issue",
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow.AddDays(4),
            RequestingEmployeedId = "5b42de3b-0b2b-40ab-ba53-fe3de786dz",
            Status = LeaveRequestStatus.Approved,
        }

    };
    public static Mock<ILeaveRequestRepository> InitialLeaveRequestMockRepository()
    {
        var mockRepo = new Mock<ILeaveRequestRepository>();

        mockRepo.Setup(r => r.GetAsync()).Returns(() =>
        {
            return Task.FromResult(mockDb);
        });




        return mockRepo;
    }
}