using PictureSharing.Domain.Dtos;
using PictureSharing.Domain.Entity;
using PictureSharing.Domain.Expections;
using PictureSharing.Infrastructures.Interface;

namespace PictureSharing.Infrastructures.Services;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public AuthService(IUserService userService,IUserRepository userRepository,ITokenService tokenService)
    {
        _userService = userService;
        _userRepository = userRepository;
        _tokenService = tokenService;
    }
    public async ValueTask<string> LoginAsync(LoginDto dto)
    {
        if (dto is null)
            throw new CustomException(400, "Bad request dto null");
        
        var user = await _userService.GetUserByEmailAndPasswordAsync(dto.Password, dto.Email);
        if (user is null)
            throw new CustomException(404, "user not found");
        var token = await _tokenService.GetTokenAsync(user.Email, user.Password);
        return token;
    }

    public async ValueTask<User> RegistrationAsync(RegistrationDto dto)
    {
        if (dto is null)
            throw new CustomException(400, "Bad request dto null");
        var user = await _userService.CreateAsync(dto);
        return user;
    }
}