using Microsoft.AspNetCore.Mvc;
using PictureSharing.Entity;
using PictureSharing.Entity.Dtos;
using PictureSharing.Infrastructures.Interface;
using PictureSharing.Infrastructures.Repositories;

namespace PictureSharing.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    private readonly ClientRepository _clientRepository;
    private readonly IClientService _clientService;

    public ClientController(ClientRepository clientRepository, IClientService clientService)
    {
        _clientRepository = clientRepository;
        _clientService = clientService;
    }
    [HttpGet]
    public async ValueTask<ApiResult<IEnumerable<Client>>> GetAll()
        => ApiResult<Client>.FromIEnumerable(await _clientRepository.GetAllAsync());

    [HttpPost]
    public async ValueTask<ApiResult<Client>> Create(ClientCreateDto data)
    {
        Client client = await _clientService.Create(data);
        return client;
    }
}