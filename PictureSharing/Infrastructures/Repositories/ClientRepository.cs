using PictureSharing.Entity;
using PictureSharing.Infrastructures.Interface;

namespace PictureSharing.Infrastructures.Repositories;

public class ClientRepository : RepositoryBase<Client> ,IClientRepository
{
    public ClientRepository(DataContext context) : base(context)
    {
    }
}