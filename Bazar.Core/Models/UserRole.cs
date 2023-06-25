using Microsoft.AspNetCore.Identity;

namespace Bazar.Core.Models;

public class UserRole : IdentityRole
{
    
    public ICollection<User> Users { get; } = new List<User>();
}