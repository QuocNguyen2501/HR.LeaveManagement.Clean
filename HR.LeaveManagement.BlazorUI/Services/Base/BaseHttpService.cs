using System.Net;

namespace HR.LeaveManagement.BlazorUI.Services.Base
{
    public class BaseHttpService
    {
        protected IClient _client;

        public BaseHttpService(IClient client)
        {
            _client = client;
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
    }
}
