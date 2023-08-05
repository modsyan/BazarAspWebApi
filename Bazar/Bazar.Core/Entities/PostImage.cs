using System.ComponentModel.DataAnnotations;
using Bazar.Core.Entities.Base;
using Bazar.Core.Models;

namespace Bazar.Core.Entities;

public class PostImage : BaseModel
{
    [Required] public string Url { get; set; } = null!; // At the futeure changed to Bytes or To Chepies storge on cloud
    [Required] public Guid PostId { get; set; }
    [Required] public Post Post { get; set; } = null!;
}