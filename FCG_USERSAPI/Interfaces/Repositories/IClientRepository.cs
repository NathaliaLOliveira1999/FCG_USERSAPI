using FCG_USERSAPI.Models;

namespace FCG_USERSAPI.Interfaces.Repositories
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAll();
        Client? GetById(int id);
        ServiceResult Add(Client client);
        IEnumerable<Client> GetListByEmail(string email);
    }
}
