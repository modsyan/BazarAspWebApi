using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bazar.Core.Models;

public class Faq
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string Question { get; set; } = null!;
    public string Answer { get; set; } = null!;

    public DateTime CreateAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}