using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace HR.LeaveManagement.Persistence.IntegrationTests
{
    public class HrDatabaseContextTest
    {
        private readonly HrDatabaseContext _hrDatabaseContext;
        public HrDatabaseContextTest()
        {
            var dbOptions = new DbContextOptionsBuilder<HrDatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            _hrDatabaseContext = new HrDatabaseContext(dbOptions);
        }

        [Fact]
        public async void Save_SetDateCreatedValue()
        {
            // Arrange
            var leaveType = new LeaveType
            {
                Id = "b80194ce-25f3-41ed-900f-2bfa801e2a81",
                DefaultDays = 15,
                Name = "Test Sick"
            };
            // Act
            await _hrDatabaseContext.LeaveTypes.AddAsync(leaveType);
            await _hrDatabaseContext.SaveChangesAsync();
            // Assert
            leaveType.DateCreated.ShouldNotBeNull();
        }

        [Fact]
        public async void Save_SetDateModifiedValue() {
            var leaveType = new LeaveType
            {
                Id = "b80194ce-25f3-41ed-900f-2bfa801e2a81",
                DefaultDays = 15,
                Name = "Test Sick"
            };
            // Act
            await _hrDatabaseContext.LeaveTypes.AddAsync(leaveType);
            await _hrDatabaseContext.SaveChangesAsync();
            // Assert
            leaveType.DateModified.ShouldNotBeNull();
        }
    }
}
