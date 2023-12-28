using Blazored.LocalStorage;
using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Services.Base;

namespace HR.LeaveManagement.BlazorUI.Services;

public class LeaveAllocationService : BaseHttpService, ILeaveAllocationService
{
    public LeaveAllocationService(IClient client, ILocalStorageService localStorage) : base(client,localStorage)
    {
    }

    public async Task<Response<Ulid>> CreateLeaveAllocations(string leaveTypeId)
    {
        try
        {
            var response = new Response<Ulid>();
            CreateLeaveAllocationCommand command = new CreateLeaveAllocationCommand { LeaveTypeId = leaveTypeId };

            await _client.LeaveAllocationsPOSTAsync(command);
            return response;
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Ulid>(ex);
        }
    }
}
