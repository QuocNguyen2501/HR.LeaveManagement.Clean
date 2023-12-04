using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Persistence.DatabaseContext;
using HR.LeaveManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagement.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<HrDatabaseContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString("HrDatabaseConnectionString"));
        });
        // Register the dependency between Generic T IRepository and Generic T Repository
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        services.AddScoped(typeof(ILeaveTypeRepository), typeof(LeaveTypeRepository));
        services.AddScoped(typeof(ILeaveRequestRepository), typeof(LeaveRequestRepository));
        services.AddScoped(typeof(ILeaveAllocationRepository), typeof(LeaveAllocationRepository));

        return services;
    }
}
