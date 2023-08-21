using System.ComponentModel;
using Bazar.Core.Entities;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Bazar.Core.DTOs;

public class UpdateUserRequestDto
{
}

public class UpdateUserResponseDto
{
}

public class UserResponseDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public byte[] ProfilePicture { get; set; } = null!;
    public DateTime BirthDate { get; set; }
}

public class UserDetailDtoResponse : UserResponseDto
{
    public ICollection<Order>? Orders { get; set; }
    public ICollection<Review>? Reviews { get; set; }
    public ICollection<User>? Blacklist { get; set; }
    public ICollection<Product>? Wishlist { get; set; }
    public ICollection<Chat>? Chats { get; set; }
    public ICollection<User>? Following { get; set; }
    public ICollection<User>? Followers { get; set; }
    public Guid? CartId { get; set; }
    public Cart? Cart { get; set; }
    public DateTime CreatedAt { get; set; }
    // public DateTime? UpdatedAt { get; set; }
}

