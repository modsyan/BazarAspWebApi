using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bazar.Core.Models;

public class Address
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required] public Guid UserId { get; set; }
    [Required] public User User { get; set; }

    [Required] public string Country { get; set; }
    [Required] public string City { get; set; }
    [Required] public string StreetAddress { get; set; }
    [Required] public string? ZipCode { get; set; }
}