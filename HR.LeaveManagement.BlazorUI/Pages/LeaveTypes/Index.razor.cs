using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using HR.LeaveManagement.BlazorUI;
using HR.LeaveManagement.BlazorUI.Shared;
using HR.LeaveManagement.BlazorUI.Models.LeaveTypes;
using HR.LeaveManagement.BlazorUI.Contracts;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveTypes;

public partial class Index
{
	[Inject]
	public NavigationManager NavigationManager { get; set; }

	[Inject]
	public ILeaveTypeService LeaveTypeService { get; set; }

	public string Message { get; set; } = string.Empty;
	public List<LeaveTypeVM> LeaveTypes { get; private set; }


	protected void CreateLeaveType()
	{

	}

	protected void AllocateLeaveType(string id)
	{

	}

	protected void DeleteLeaveType(string id)
	{

	}

	protected void UpdateLeaveType(string id)
	{

	}
}
