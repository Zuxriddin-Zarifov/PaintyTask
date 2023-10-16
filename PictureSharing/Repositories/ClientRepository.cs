using PictureSharing.Entity;
using PictureSharing.Repositories.Interface;

namespace PictureSharing.Repositories;

public class ClientRepository : RepositoryBase<Client> ,IClientRepository
{
    public ClientRepository(DataContext context) : base(context)
    {
    }
}