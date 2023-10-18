using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PictureSharing.Domain.Dtos;
using PictureSharing.Domain.Entity;
using PictureSharing.Infrastructures.Interface;

namespace PictureSharing.Controllers;

[ApiController,Route("[controller]")]
public class FriendController : ControllerBase
{
    private readonly IFriendService _friendService;

    public FriendController(IFriendService friendService)
    {
        _friendService = friendService;
    }

    [HttpGet, Authorize]
    public async ValueTask<ApiResult<IEnumerable<Friend>>> GetFriendsAsync(long userId)
    {
        return ApiResult<Friend>.FromIEnumerable(await _friendService.GetFriendsAsync(userId));
    }

    [HttpPost, Authorize]
    public async ValueTask<ApiResult<Friend>> CreateAsync(FriendCreateDto dto)
    {
        return await _friendService.CreateAsync(dto);
    }
}