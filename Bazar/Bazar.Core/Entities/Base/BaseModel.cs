using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bazar.Core.Entities.Base;

public class BaseModel
{
    protected BaseModel()
    {
        // Id = Guid.NewGuid();
    }
    
    [Key]
    [DatabaseGenerated((DatabaseGeneratedOption.Identity))]
    public Guid Id { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    // [DefaultValue("SYSDATETIME()")]
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime? UpdatedAt { get; set; }

    // [DatabaseGenerated((DatabaseGeneratedOption.Computed))]
    // public DateTime? LastAccessed { get; set; }
}
