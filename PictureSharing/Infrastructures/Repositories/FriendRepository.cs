using Microsoft.EntityFrameworkCore;
using PictureSharing.Entity;
using PictureSharing.Infrastructures.Interface;

namespace PictureSharing.Infrastructures.Repositories;

public class FriendRepository : RepositoryBase<Friends>, IFriendRepository
{
    protected FriendRepository(DataContext context) : base(context)
    {
    }
}