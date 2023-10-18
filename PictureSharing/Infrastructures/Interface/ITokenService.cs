namespace PictureSharing.Infrastructures.Interface;

public interface ITokenService
{
    public ValueTask<string> GetTokenAsync(string email,string password);
}