
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using HR.LeaveManagement.BlazorUI.Providers;

namespace HR.LeaveManagement.BlazorUI.Shared;

public partial class MainLayout
{
	[Inject]
	private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

	[Inject]
	private NavigationManager NavigationManager { get; set; }

	protected async override Task OnParametersSetAsync()
	{
		var auth = await ((ApiAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();
		if (auth is null || string.IsNullOrEmpty(auth.User.Identity.Name))
		{
			NavigationManager.NavigateTo("/users/login/");
		}
	}
}
