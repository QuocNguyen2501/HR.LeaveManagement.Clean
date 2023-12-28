using HR.LeaveManagement.Application.Models.Identity;

namespace HR.LeaveManagement.Application.Contracts.Identity
{
	public interface IUserService
	{
		Task<List<Employee>> GetEmployees();
		Task<Employee> GetEmployee(string userId);
		Task<List<Employee>> GetStaffs();

		public string UserId { get; }
	}
}
