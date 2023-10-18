using PictureSharing.Domain.Entity;
using PictureSharing.Infrastructures.Interface;

namespace PictureSharing.Infrastructures.Repositories;

public class PhotoRepository : RepositoryBase<Photo,Guid> , IPhotoRepository
{
    public PhotoRepository(DataContext context) : base(context)
    {
    }
}