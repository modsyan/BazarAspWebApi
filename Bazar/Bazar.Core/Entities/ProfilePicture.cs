using Bazar.Core.Entities.Base;

namespace Bazar.Core.Entities;

public class ProfilePicture : BaseModel
{
    private User User { get; set; } = null!;
    private byte[] Picture { get; set; } = null!;
}