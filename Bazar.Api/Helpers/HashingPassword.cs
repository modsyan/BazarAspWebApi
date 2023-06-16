namespace Bazar.Api.Helpers;

public class HashingPassword
{
    public static  string Hash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, "");
    }
    
    public static  bool Verify(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}