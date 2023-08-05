using System.ComponentModel.DataAnnotations;
using Bazar.Core.Entities.Base;

namespace Bazar.Core.Entities;

public class Faq : BaseModel
{
    [Required] public string Question { get; set; } = null!;
    [Required] public string Answer { get; set; } = null!;
}