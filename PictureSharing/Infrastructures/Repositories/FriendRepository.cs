using PictureSharing.Domain.Entity;
using PictureSharing.Infrastructures.Interface;

namespace PictureSharing.Infrastructures.Repositories;

public class FriendRepository : RepositoryBase<Friend,long>, IFriendRepository 
{
    public FriendRepository(DataContext context) : base(context)
    {
    }
}