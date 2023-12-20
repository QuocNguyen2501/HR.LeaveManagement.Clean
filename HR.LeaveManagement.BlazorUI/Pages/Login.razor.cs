using HR.LeaveManagement.BlazorUI.Models;
using Microsoft.AspNetCore.Components;

namespace HR.LeaveManagement.BlazorUI.Pages;

public partial class Login
{
    public LoginVM Model { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    public Login()
    { }

    public void HandleLogin(){}

    protected override void OnInitialized()
    { }
}
