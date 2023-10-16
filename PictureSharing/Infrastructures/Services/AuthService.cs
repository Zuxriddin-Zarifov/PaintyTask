using PictureSharing.Domain.Dtos;
using PictureSharing.Domain.Entity;
using PictureSharing.Infrastructures.Interface;

namespace PictureSharing.Infrastructures.Services;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly IUserRepository _userRepository;

    public AuthService(IUserService userService,IUserRepository userRepository)
    {
        _userService = userService;
        _userRepository = userRepository;
    }
    public async ValueTask<bool> Login(LoginDto dto)
    {
        var user = await _userService.GetUserByEmailAndPassword(dto.Password, dto.Email);
        return true;
    }

    public async ValueTask<User> Registration(RegistrationDto dto)
    {
        var user = await _userService.Create(dto);
        return user;
    }
}