using System;
namespace HR.LeaveManagement.Domain.Common;

public abstract class BaseEntity
{
	public string Id { get; set; }
	public DateTime? DateCreated { get; set; }
	public DateTime? DateModified { get; set; }
}

