using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Persistence.Configurations;

public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
{
    public void Configure(EntityTypeBuilder<LeaveType> builder)
    {
        builder.HasData(
                new LeaveType { 
                    Id = Guid.NewGuid().ToString(),
                    Name = "Vacation",
                    DefaultDays = 10,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                }
            );
        builder.HasKey(q => q.Id);
        builder.HasMany(q => q.LeaveRequests);
        builder.Property(q => q.Name).IsRequired().HasMaxLength(100);
        builder.Property(q => q.DefaultDays).IsRequired();
    }
}
