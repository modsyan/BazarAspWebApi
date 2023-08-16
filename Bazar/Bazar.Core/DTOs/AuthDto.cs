using System.ComponentModel;
using Bazar.Core.Entities;

namespace Bazar.Core.DTOs;

public class RegisterUserRequestDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public required string Password { get; set; }
    public DateTime BirthDate { get; set; }
}

public class RegisterUserResponseDto
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public class LoginUserRequestDto
{
    public required string LoginIdentifier { get; set; }
    public required string Password { get; set; }
}

public class LoginUserResponseDto
{
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    
    public ICollection<UserRole>? Roles { get; set; }
    public ICollection<Order>? Orders { get; set; }
    public ICollection<Review>? Reviews { get; set; }
    public ICollection<User>? Blacklist { get; set; }
    public ICollection<Product>? Wishlist { get; set; }
    public ICollection<Chat>? Chats { get; set; }
    public ICollection<User>? Following { get; set; }
    public ICollection<User>? Followers { get; set; }
    public ProfilePicture? Picture { get; set; }
    public Guid? CartId { get; set; }
    public Cart? Cart { get; set; }

    public DateTime BirthDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}