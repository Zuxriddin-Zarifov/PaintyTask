using Microsoft.EntityFrameworkCore;
using PictureSharing.Entity;
using PictureSharing.Repositories.Interface;

namespace PictureSharing.Repositories;

public class PhotoRepository : RepositoryBase<Photo> , IPhotoRepository
{
    public PhotoRepository(DataContext context) : base(context)
    {
    }
}