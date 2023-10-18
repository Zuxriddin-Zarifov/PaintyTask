using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PictureSharing.Domain.Dtos;
using PictureSharing.Domain.Entity;
using PictureSharing.Domain.Expections;
using PictureSharing.Infrastructures.Interface;
using PictureSharing.Services.Interface;

namespace PictureSharing.Controllers;

[ApiController, Route("[controller]")]
public class PhotoController : ControllerBase
{
    private readonly IPhotoRepository _photoRepository;
    private readonly IPhotoService _photoService;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public PhotoController(IPhotoRepository photoRepository, IPhotoService photoService,
        IWebHostEnvironment webHostEnvironment)
    {
        _photoRepository = photoRepository;
        _photoService = photoService;
        _webHostEnvironment = webHostEnvironment;
    }

    [HttpPost, Authorize]
    public async ValueTask<ApiResult<Photo>> CreateAsync(IFormFile file, long userId)
    {
        var webRootPath = _webHostEnvironment.WebRootPath;
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), webRootPath, "photos");

        return await _photoService.CreateAsync(file, filePath, userId);
    }

    [HttpGet("{id:long}"), Authorize]
    public async ValueTask<ApiResult<IEnumerable<Photo>>> GetPhotoByUserIdAsync(long id)
    {
        return ApiResult<Photo>.FromIEnumerable(await _photoService.GetPhotoByUserIdAsync(id));
    }

    [HttpDelete("{id:guid}"), Authorize]
    public async ValueTask<ApiResult<Photo>> DeleteAsync(Guid id)
    {
        var webRootPath = _webHostEnvironment.WebRootPath;
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), webRootPath, "photos");
        var photo = await _photoRepository.GetByIdAsync(id);
        if (photo is null)
            throw new CustomException(404, "photo not found");
        var result = await _photoService.DeleteAsync(filePath, photo);
        return result;
    }
}