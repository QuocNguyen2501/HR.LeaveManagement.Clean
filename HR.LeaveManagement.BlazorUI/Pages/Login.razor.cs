using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Models;
using Microsoft.AspNetCore.Components;

namespace HR.LeaveManagement.BlazorUI.Pages;

public partial class Login
{
    public LoginVM Model { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public IAuthenticationService AuthenticationService { get; set; }

    public string Msg { get; set; }

    public Login()
    { }

    public async void HandleLogin()
    {
        if(await AuthenticationService.AuthenticateAsync(Model.Email,Model.Password))
        {
            NavigationManager.NavigateTo("home");
            return;
        }
        Msg = "Username/password combination unknown";
    }

    protected override void OnInitialized()
    { 
        Model = new LoginVM();
    }
}
