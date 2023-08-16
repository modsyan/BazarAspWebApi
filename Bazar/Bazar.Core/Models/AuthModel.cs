using Bazar.Core.Entities;

namespace Bazar.Core.Models;

// AuthModel Will Be Deleted And Merged With Login and Register DtoS
public class AuthModel
{
    public User User { get; set; } = null!;
    public string Token { get; set; } = null!;
}