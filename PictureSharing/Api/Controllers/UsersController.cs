using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PictureSharing.Domain.Dtos;
using PictureSharing.Domain.Entity;
using PictureSharing.Infrastructures.Interface;

namespace PictureSharing.Controllers;

[ApiController, Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet, Authorize]
    public async ValueTask<ApiResult<IEnumerable<User>>> GetAllAsync()
        => ApiResult<User>.FromIEnumerable(await _userRepository.GetAllAsync());

    [HttpGet("{id:long}"), Authorize]
    public async ValueTask<ApiResult<User>> GetByIdAsync(long id)
        => await _userRepository.GetByIdAsync(id);

    [HttpDelete, Authorize]
    public async ValueTask<ApiResult<User>> DeleteAsync(long id)
        => await _userRepository.DeleteAsync(id);
}