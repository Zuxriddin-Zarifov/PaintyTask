using Microsoft.AspNetCore.Mvc;
using PictureSharing.Entity;
using PictureSharing.Entity.Dtos;
using PictureSharing.Infrastructures.Interface;
using PictureSharing.Infrastructures.Repositories;
using PictureSharing.Infrastructures.Services;

namespace PictureSharing.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IUserService _userService;

    public UserController(IUserRepository userRepository, IUserService userService)
    {
        _userRepository = userRepository;
        _userService = userService;
    }
    [HttpGet]
    public async ValueTask<ApiResult<IEnumerable<User>>> GetAll()
        => ApiResult<User>.FromIEnumerable(await _userRepository.GetAllAsync());

    [HttpPost]
    public async ValueTask<ApiResult<User>> Create(UserCreateDto data)
    {
       User user = await _userService.Create(data);
       return user;
    }


}