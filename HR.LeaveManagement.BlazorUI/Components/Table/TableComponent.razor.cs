using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;
namespace HR.LeaveManagement.BlazorUI.Components.Table;

public partial class TableComponent<TItem> where TItem : class 
{
	[Parameter]
	public RenderFragment? TableHeader { get; set; }

	[Parameter]
	public RenderFragment<TItem>? RowTemplate { get; set; }

	[Parameter,AllowNull]
	public IReadOnlyList<TItem> Items { get; set; }
}