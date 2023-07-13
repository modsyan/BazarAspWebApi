namespace Bazar.Core.Models;

public class Settings
{
    public Guid Id { get; set; }
    
    public User User { get; set; }


    // Application Settings
    public bool IsDarkMode { get; set; }


    // Privacy Settings
    public bool IsFollowersHide { get; set; }


    //About and Terms
}