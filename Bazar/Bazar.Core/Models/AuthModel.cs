namespace Bazar.Core.Models;

// AuthModel Will Be Deleted And Merged With Login and Register DtoS
public class AuthModel
{
    public required string Message { get; set; }
    public bool IsAuthenticated { get; set; }
    public required string Email { get; set; }
    public string Username { get; set; }
    public List<string> Roles { get; set; }
    public required string Token { get; set; }
}