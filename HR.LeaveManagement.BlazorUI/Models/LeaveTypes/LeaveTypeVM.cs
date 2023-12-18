using System.ComponentModel.DataAnnotations;

namespace HR.LeaveManagement.BlazorUI.Models.LeaveTypes
{
    public class LeaveTypeVM
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name="Default Number Of Days")]
        public int DefaultDays { get; set; }
    }
}
