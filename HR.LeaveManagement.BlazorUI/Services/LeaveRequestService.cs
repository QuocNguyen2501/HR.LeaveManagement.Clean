using AutoMapper;
using Blazored.LocalStorage;
using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Models.LeaveAllocations;
using HR.LeaveManagement.BlazorUI.Models.LeaveRequests;
using HR.LeaveManagement.BlazorUI.Services.Base;

namespace HR.LeaveManagement.BlazorUI.Services;

public class LeaveRequestService : BaseHttpService, ILeaveRequestService
{
    private readonly IMapper _mapper;

    public LeaveRequestService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client,localStorage)
    {
        _mapper = mapper;

	}

    public async Task<Response<Ulid>>  ApproveLeaveRequest(string id, LeaveRequestStatus approvalStatus)
    {
        try
        {
            var response = new Response<Ulid>();
            await AddBearerTokenAsync();
            var request = new ChangeLeaveRequestApprovalCommand { Id = id, Status = (Base.LeaveRequestStatus)approvalStatus };
            await _client.ApproveRequestAsync(id, request);
            return response;

		}
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Ulid>(ex);
        }
    }

    public async Task<Response<Ulid>> CancelLeaveRequest(string id)
    {
        try
        {
            var response = new Response<Ulid>();
            await AddBearerTokenAsync();
            var request = new ChangeLeaveRequestApprovalCommand { Id = id, Status = (Base.LeaveRequestStatus)LeaveRequestStatus.Cancelled };
            await _client.CancelRequestAsync(id, request);
            return response;
        }
        catch(ApiException ex)
        {
            return ConvertApiExceptions<Ulid>(ex);
        }
    }

    public async Task<Response<Ulid>> CreateLeaveRequest(LeaveRequestVM leaveRequest)
    {
        try
        {
            var response = new Response<Ulid>();
			await AddBearerTokenAsync();
            var request = _mapper.Map<CreateLeaveRequestCommand>(leaveRequest);
            await _client.LeaveRequestsPOSTAsync(request);
            return response;

		}
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Ulid>(ex);
        }
    }

    public async Task<Response<Ulid>> DeleteLeaveRequest(string id)
    {
        try
        {
            var response = new Response<Ulid>();
            await AddBearerTokenAsync();
            await _client.LeaveRequestsDELETEAsync(id);
            return response;

		}
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Ulid>(ex);
        }
    }

    public async Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList()
    {
        var leaveRequests = await _client.LeaveRequestsAllAsync(isLoggedInUser: false);
        var model = new AdminLeaveRequestViewVM
        {
            TotalRequests = leaveRequests.Count,
            ApprovedRequests = leaveRequests.Count(q => q.Status == (Base.LeaveRequestStatus)LeaveRequestStatus.Approved),
            PendingRequests = leaveRequests.Count(q => q.Status == (Base.LeaveRequestStatus)LeaveRequestStatus.New),
            RejectedRequests = leaveRequests.Count(q => q.Status == (Base.LeaveRequestStatus)LeaveRequestStatus.Rejected),
            LeaveRequests = _mapper.Map<List<LeaveRequestVM>>(leaveRequests).OrderBy(o => o.DateRequested).ToList()
        };
        return model;
    }

    public async Task<LeaveRequestVM> GetLeaveRequest(string id)
    {
        var leaveRequest = await _client.LeaveRequestsGETAsync(id);

        return _mapper.Map<LeaveRequestVM>(leaveRequest);
    }

    public async Task<EmployeeLeaveRequestViewVM> GetUserLeaveRequests()
    {
        var leaveRequests = await _client.LeaveRequestsAllAsync(isLoggedInUser: true);
        var allocations = await _client.LeaveAllocationsAllAsync(isLoggedInUser: true);
        var model = new EmployeeLeaveRequestViewVM
        {
            LeaveAllocations = _mapper.Map<List<LeaveAllocationVM>>(allocations),
            LeaveRequests = _mapper.Map<List<LeaveRequestVM>>(leaveRequests)
        };
        return model;
    }
}
