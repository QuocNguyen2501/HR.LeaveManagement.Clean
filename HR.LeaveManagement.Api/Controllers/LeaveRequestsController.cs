
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.ChangeLeaveRequestApproval;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.DeleteLeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails;
using HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequests;
using HR.LeaveManagement.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveRequestsController : ControllerBase
{
    private readonly IMediator _mediator;
    public LeaveRequestsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<LeaveRequestDto>>> Get()
    {
        return Ok(await _mediator.Send(new GetLeaveRequestsQuery()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveRequestDetailsDto>> Get(string id)
    {
        return Ok(await _mediator.Send(new GetLeaveRequestDetailsQuery(id)));
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Post(CreateLeaveRequestCommand leaveRequest)
    {
        var response = await _mediator.Send(leaveRequest);
        return CreatedAtAction(nameof(Get), new { id = response });
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Put(string id, UpdateLeaveRequestCommand leaveRequest)
    {
        leaveRequest.Id = id;
        await _mediator.Send(leaveRequest);
        return NoContent();
    }

    [HttpPut("{id}")]
    [Route("CancelRequest")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> CancelRequest(string id, ChangeLeaveRequestApprovalCommand leaveRequest)
    {
        leaveRequest.Id = id;
        leaveRequest.Status = LeaveRequestStatus.Cancelled;
        await _mediator.Send(leaveRequest);
        return NoContent();
    }

    [HttpPut("{id}")]
    [Route("ApproveRequest")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> ApproveRequest(string id, ChangeLeaveRequestApprovalCommand leaveRequest)
    {
        leaveRequest.Id = id;
        leaveRequest.Status = LeaveRequestStatus.Approved;
        await _mediator.Send(leaveRequest);
        return NoContent();
    }

    [HttpPut("{id}")]
    [Route("RejectRequest")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> RejectRequest(string id, ChangeLeaveRequestApprovalCommand leaveRequest)
    {
        leaveRequest.Id = id;
        leaveRequest.Status = LeaveRequestStatus.Rejected;
        await _mediator.Send(leaveRequest);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(string id)
    {
        var command = new DeleteLeaveRequestCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}