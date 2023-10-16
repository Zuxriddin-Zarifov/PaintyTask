using PictureSharing.Entity;
using PictureSharing.Entity.Dtos;

namespace PictureSharing.Infrastructures.Interface;

public interface IPhotoService
{
    public ValueTask<Photo> Create(IFormFile file);
    
}