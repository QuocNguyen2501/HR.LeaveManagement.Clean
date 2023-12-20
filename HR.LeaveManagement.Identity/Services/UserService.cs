using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Models.Identity;
using HR.LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace HR.LeaveManagement.Identity.Services
{
	public class UserService : IUserService
	{
		private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
			_userManager = userManager;
		}

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

		public Task<List<Employee>> GetEmployees()
		{
			throw new NotImplementedException();
		}
	}
}
