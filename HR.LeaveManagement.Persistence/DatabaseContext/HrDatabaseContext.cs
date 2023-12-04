using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.DatabaseContext;

public class HrDatabaseContext: DbContext
{
    public HrDatabaseContext(DbContextOptions<HrDatabaseContext> options): base(options)
    {
        
    }

    public DbSet<LeaveType> LeaveTypes { get; set; }
    public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }


    // This is an interceptor
    // it will change the data entity rely on what we need before we change state from database
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
            .Where(q=>q.State==EntityState.Added || q.State == EntityState.Modified))
        {
            entry.Entity.DateModified = DateTime.UtcNow;
            if (entry.State == EntityState.Added)
            { 
                entry.Entity.Id = Guid.NewGuid().ToString();
                entry.Entity.DateCreated = DateTime.UtcNow;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // There are 2 ways to setup our database
        // 1: Use DataAnotation, for this way need to add anotations into our Domain Entities
        // 2: Use Fluent API in EF
        //      - Configure our database in OnModelCreating function
        //      - Congfigure our database in other files, and use ApplyConfigurationsFromAssembly to load and apply configurations to database
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HrDatabaseContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}