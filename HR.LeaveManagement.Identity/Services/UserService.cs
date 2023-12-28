using System.Security.Claims;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Models.Identity;
using HR.LeaveManagement.Identity.DbContext;
using HR.LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Identity.Services
{
	public class UserService : IUserService
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IHttpContextAccessor _contextAccessor;
		private readonly HrLeaveManagementIdentityDbContext _context;

		public UserService(
			UserManager<ApplicationUser> userManager, 
			IHttpContextAccessor httpContextAccessor,
			HrLeaveManagementIdentityDbContext context
			)
        {
			_userManager = userManager;
			_contextAccessor = httpContextAccessor;
			_context = context;
		}

		public string UserId { get=> _contextAccessor.HttpContext?.User?.FindFirstValue("uid"); }

        public async Task<Employee> GetEmployee(string userId)
		{
			var employee = await _userManager.FindByIdAsync(userId);
			return new Employee
			{
				Email = employee.Email,
				Id = employee.Id,
				FirstName = employee.FirstName,
				LastName = employee.LastName,
			};
		}

		public async Task<List<Employee>> GetEmployees()
		{
			var employees = await _userManager.GetUsersInRoleAsync("Employee");
			return employees.Select(q => new Employee
			{
				Id = q.Id,
				Email = q.Email,
				FirstName = q.FirstName,
				LastName = q.LastName
			}).ToList();
		}

		public async Task<List<Employee>> GetStaffs()
		{
			var employees = await _context.Users.ToListAsync();
			return employees.Select(q => new Employee
			{
				Id = q.Id,
				Email = q.Email,
				FirstName = q.FirstName,
				LastName = q.LastName
			}).ToList();
		}
	}
}
