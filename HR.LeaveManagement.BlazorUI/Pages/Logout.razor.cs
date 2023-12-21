
using HR.LeaveManagement.BlazorUI.Contracts;
using Microsoft.AspNetCore.Components;

namespace HR.LeaveManagement.BlazorUI.Pages;

public partial class Logout
{
    [Inject]
    private IAuthenticationService _authService {get;set;}
    [Inject]
    private NavigationManager _navManager{get;set;}
    
    public Logout()
    {
        
    }

    protected override async Task OnInitializedAsync()
    {
        await _authService.Logout();
        _navManager.NavigateTo("/");
    }

}