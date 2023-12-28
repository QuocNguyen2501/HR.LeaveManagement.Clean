using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Models;
using Microsoft.AspNetCore.Components;

namespace HR.LeaveManagement.BlazorUI.Pages
{
    public partial class Register
    {
        public RegisterVM Model { get; set; }

        public string Message { get; private set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }


        public async Task HandleRegister()
        {
            var result = await AuthenticationService.RegisterAsync(Model.FirstName, Model.LastName, Model.UserName, Model.Email, Model.Password);
            if(result)
            {
                NavigationManager.NavigateTo("home");
            }
            Message = "Something went wrong, please try again.";
        }

        protected override void OnInitialized()
        {
            Model = new RegisterVM();
        }
    }
}