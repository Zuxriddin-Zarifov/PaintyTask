using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PictureSharing.Domain.Dtos;
using PictureSharing.Domain.Entity;
using PictureSharing.Infrastructures.Interface;

namespace PictureSharing.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;

    public UserController(IUserRepository userRepository, IUserService userService,ITokenService tokenService)
    {
        _userRepository = userRepository;
        _userService = userService;
        _tokenService = tokenService;
    }

    [HttpGet,Authorize]
    public async ValueTask<ApiResult<IEnumerable<User>>> GetAll()
        => ApiResult<User>.FromIEnumerable(await _userRepository.GetAllAsync());

    [HttpGet("get-token"),AllowAnonymous]
    public async ValueTask<string> GetToken()
        => await _tokenService.GetToken();

    [HttpPost,Authorize]
    public async ValueTask<ApiResult<User>> Create(RegistrationDto dto)
    {
        User user = await _userService.Create(dto);
        return user;
    }
}