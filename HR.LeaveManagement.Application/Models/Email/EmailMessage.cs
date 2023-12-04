namespace HR.LeaveManagement.Application.Models.Email;

public class EmailMessage
{
    public List<string> Tos { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}
