﻿using System.ComponentModel.DataAnnotations;

namespace HR.LeaveManagement.BlazorUI.Models
{
	public class LoginVM
	{
		[Required]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
	}
}

