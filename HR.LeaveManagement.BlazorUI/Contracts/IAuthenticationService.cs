namespace HR.LeaveManagement.BlazorUI.Contracts
{
	public interface IAuthenticationService
	{
		// use to login
		Task<bool> AuthenticateAsync(string email, string password);
		// use to register an account
		Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password);
		// use to logout
		Task Logout();
	}
}
