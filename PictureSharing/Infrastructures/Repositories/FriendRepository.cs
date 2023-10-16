using PictureSharing.Domain.Entity;
using PictureSharing.Infrastructures.Interface;

namespace PictureSharing.Infrastructures.Repositories;

public class FriendRepository : RepositoryBase<Friend>, IFriendRepository 
{
    protected FriendRepository(DataContext context) : base(context)
    {
    }
}