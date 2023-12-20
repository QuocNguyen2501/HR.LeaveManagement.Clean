using System.Net;
using System.Net.Http.Headers;
using Blazored.LocalStorage;

namespace HR.LeaveManagement.BlazorUI.Services.Base
{
    public class BaseHttpService
    {
        protected IClient _client;
        protected readonly ILocalStorageService _localStorage;

        public BaseHttpService(IClient client, ILocalStorageService localStorage)
        {
            _client = client;
			_localStorage = localStorage;

		}

        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException ex)
        {
            switch(ex.StatusCode)
            {
                case (int)HttpStatusCode.BadRequest:
                    return new Response<Guid>() { Message = "Invalid data was submitted", ValidationErrors = ex.Response, Success = false };
                case (int)HttpStatusCode.NotFound:
                    return new Response<Guid>() { Message = "The record was not found", Success = false };
                default:
                    return new Response<Guid>() { Message = "Something went wrong, please try again", Success=false };
            }
        }

        protected async Task AddBearerToken()
        {
            if (await _localStorage.ContainKeyAsync("token"))
            {
                _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _localStorage.GetItemAsync<string>("token"));
            }
        }
    }
}
