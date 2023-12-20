using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Identity.Configurations
{
	public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
	{
		public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
		{
			builder.HasData(
					new IdentityUserRole<string>
					{ 
						RoleId = "90704952-6035-47f7-8d96-ae900598e407",
						UserId = "8fa7097a-9ed4-11ee-8c90-0242ac120002"
					},
					new IdentityUserRole<string>
					{
						RoleId = "d8d717d6-031f-4c61-ae1c-741710c74851",
						UserId = "d934794c-9ed4-11ee-8c90-0242ac120002"
					}
				);
		}
	}
}
