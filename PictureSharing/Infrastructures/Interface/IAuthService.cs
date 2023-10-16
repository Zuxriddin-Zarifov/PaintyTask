using PictureSharing.Domain.Dtos;
using PictureSharing.Domain.Entity;

namespace PictureSharing.Infrastructures.Interface;

public interface IAuthService
{
    public ValueTask<bool> Login(LoginDto dto);
    public ValueTask<User> Registration(RegistrationDto dto);
}