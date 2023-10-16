using PictureSharing.Entity;
using PictureSharing.Entity.Dtos;
using PictureSharing.Infrastructures.Interface;

namespace PictureSharing.Infrastructures.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async ValueTask<Client> Create(ClientCreateDto dto)
    {
        Client client = new Client
        {
            CreatedAt = DateTime.Now,
            Name = dto.Name,
            Surname = dto.Surname,
            UserId = dto.UserId,
        };
        return await _clientRepository.CreatAsync(client);
    }
}