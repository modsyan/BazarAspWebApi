using System.ComponentModel.DataAnnotations.Schema;
using Bazar.Core.Entities.Base;

namespace Bazar.Core.Entities;

public class Settings : BaseModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public User User { get; set; }

    // Application Settings
    public bool PushNotificationsEnabled { get; set; }
    public bool EmailNotificationsEnabled { get; set; }
    
    public string Theme { get; set; }
    public string Language { get; set; }
    
    // Privacy Settings
    public bool IsFollowersHide { get; set; }

    //About and Terms
    
}