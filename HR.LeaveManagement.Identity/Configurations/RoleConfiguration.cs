using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Identity.Configurations
{
	public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
	{
		public void Configure(EntityTypeBuilder<IdentityRole> builder)
		{
			builder.HasData(
					new IdentityRole { 
						Id = "d8d717d6-031f-4c61-ae1c-741710c74851",
						Name = "Employee",
						NormalizedName = "EMPLOYEE",
					},
					new IdentityRole
					{
						Id = "90704952-6035-47f7-8d96-ae900598e407",
						Name = "Administrator",
						NormalizedName = "ADMINISTRATOR",
					}
				);
		}
	}
}
