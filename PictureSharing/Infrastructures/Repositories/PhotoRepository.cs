using PictureSharing.Entity;
using PictureSharing.Infrastructures.Interface;

namespace PictureSharing.Infrastructures.Repositories;

public class PhotoRepository : RepositoryBase<Photo> , IPhotoRepository
{
    public PhotoRepository(DataContext context) : base(context)
    {
    }
}