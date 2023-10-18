using Microsoft.EntityFrameworkCore;
using PictureSharing.Domain.Dtos;
using PictureSharing.Domain.Entity;
using PictureSharing.Domain.Enum;
using PictureSharing.Domain.Expections;
using PictureSharing.Infrastructures.Interface;
using PictureSharing.Services.Interface;

namespace PictureSharing.Services;

public class FriendService : IFriendService
{
    private readonly IFriendRepository _friendRepository;

    public FriendService(IFriendRepository friendRepository)
    {
        _friendRepository = friendRepository;
    }

    public async ValueTask<IEnumerable<Friend>> GetFriendsActiveAsync(long userId)
    {
        var friends = _friendRepository.DbGetSet().Where(friend => friend.UserId == userId &&
                                                                   friend.Status == FriendsStatus.Active);
        if (friends is null)
            throw new CustomException(404, "Friend not found");
        return friends;
    }

    public async ValueTask<IEnumerable<Friend>> GetFriendsAsync(long userId)
    {
        var friends = _friendRepository.DbGetSet().Where(friend => friend.UserId == userId);
        if (friends is null)
            throw new CustomException(404, "Friend not found");
        return friends;
    }

    public async ValueTask<Friend> GetFriendAsync(FriendDto dto)
    {
        var friend = await _friendRepository.DbGetSet()
            .FirstOrDefaultAsync(friend => friend.UserId == dto.UserId && friend.FriendId == dto.FriendId);
        if (friend is null)
            throw new CustomException(404, "Friend not found");
        return friend;
    }


    public async ValueTask<Friend> CreateAsync(FriendDto dto)
    {
        if (dto is null)
            throw new CustomException(400, "Bad request dto null");
        var friend = new Friend
        {
            UserId = dto.UserId,
            FriendId = dto.FriendId,
            Status = FriendsStatus.Active
        };
        return await _friendRepository.CreatAsync(friend);
    }


    public async ValueTask<Friend> BlockFriendsAsync(FriendDto dto)
    {
        if (dto is null)
            throw new CustomException(400, "Bad request dto null");
        Friend friend = await this.GetFriendAsync(dto);
        if (friend is null)
        {
            friend = new Friend
            {
                UserId = dto.UserId,
                FriendId = dto.FriendId,
                Status = FriendsStatus.Blocked
            };
        }

        else
        {
            friend.Status = FriendsStatus.Blocked;
        }

        return await _friendRepository.CreatAsync(friend);
    }

    public async ValueTask<Friend> RequestFriendsAsync(FriendDto dto)
    {
        if (dto is null)
            throw new CustomException(400, "Bad request dto null");
        Friend friend = await this.GetFriendAsync(dto);
        if (friend is null)
        {
            friend = new Friend
            {
                UserId = dto.UserId,
                FriendId = dto.FriendId,
                Status = FriendsStatus.Requested
            };
        }

        else
        {
            friend.Status = FriendsStatus.Requested;
        }

        return await _friendRepository.CreatAsync(friend);
    }

    public async ValueTask<Friend> RejectedFriendsAsync(FriendDto dto)
    {
        if (dto is null)
            throw new CustomException(400, "Bad request dto null");
        Friend friend = await this.GetFriendAsync(dto);
        if (friend is null)
        {
            friend = new Friend
            {
                UserId = dto.UserId,
                FriendId = dto.FriendId,
                Status = FriendsStatus.Rejected
            };
        }

        else
        {
            friend.Status = FriendsStatus.Rejected;
        }
        return await _friendRepository.CreatAsync(friend);
    }
}