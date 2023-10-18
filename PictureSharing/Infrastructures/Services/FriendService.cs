using PictureSharing.Domain.Dtos;
using PictureSharing.Domain.Entity;
using PictureSharing.Domain.Enum;
using PictureSharing.Domain.Expections;
using PictureSharing.Infrastructures.Interface;

namespace PictureSharing.Infrastructures.Services;

public class FriendService : IFriendService
{
    private readonly IFriendRepository _friendRepository;

    public FriendService(IFriendRepository friendRepository)
    {
        _friendRepository = friendRepository;
    }
    public async ValueTask<IEnumerable<Friend>> GetFriendsAsync(long userId)
    {
        var friends = _friendRepository.DbGetSet().Where(friend => friend.UserId == userId &&
                                                                   friend.Status == FriendsStatus.Active);
        if (friends is null)
            throw new CustomException(404, "Friend not found");
        return friends;
    }

    public async ValueTask<Friend> CreateAsync(FriendCreateDto dto)
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
}