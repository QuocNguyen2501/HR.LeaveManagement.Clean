using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Models;
using Microsoft.AspNetCore.Components;

namespace HR.LeaveManagement.BlazorUI.Pages
{
    public partial class Register
    {
        public RegisterVM Model { get; set; }

        public string Msg { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        public Register()
        {
            
        }

        public async Task HandleRegister()
        {
            var result = await AuthenticationService.RegisterAsync(Model.FirstName, Model.LastName, Model.UserName, Model.Email, Model.Password);
            if(result)
            {
                NavigationManager.NavigateTo("home");
            }
            Msg = "Something went wrong, please try again.";
        }

        protected override void OnInitialized()
        {
            Model = new RegisterVM();
        }
    }
}