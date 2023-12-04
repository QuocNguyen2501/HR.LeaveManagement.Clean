using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Persistence.Configurations
{
    public class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
    {
        public void Configure(EntityTypeBuilder<LeaveRequest> builder)
        {
            builder.HasKey(q => q.Id);
            builder.Property(q => q.StartDate).IsRequired();
            builder.Property(q => q.EndDate).IsRequired();
            builder.Property(q => q.LeaveTypeId).IsRequired();
            builder.HasOne(q => q.LeaveType);
            builder.Property(q => q.DateRequested).IsRequired();
            builder.Property(q => q.RequestComments).IsRequired().HasMaxLength(250);
            builder.Property(q => q.Status).IsRequired();
            builder.Property(q => q.RequestingEmployeedId).IsRequired();
        }
    }
}
