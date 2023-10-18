using PictureSharing.Domain.Dtos;
using PictureSharing.Domain.Entity;

namespace PictureSharing.Infrastructures.Interface;

public interface IFriendService
{
    public ValueTask<IEnumerable<Friend>> GetFriendsAsync(long userId);
    public ValueTask<Friend> CreateAsync(FriendCreateDto dto);
}