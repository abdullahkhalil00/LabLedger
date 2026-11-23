using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; }
    public string RollNo { get; set; }
    public string Department { get; set; }
    public string Program { get; set; }
}