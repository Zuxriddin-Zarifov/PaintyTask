using PictureSharing.Entity;
using PictureSharing.Entity.Dtos;

namespace PictureSharing.Infrastructures.Interface;

public interface IClientService
{
    public ValueTask<Client> Create(ClientCreateDto dto);
}