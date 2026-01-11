using FCG_USERSAPI.Models;
using FCG_USERSAPI.Models.DTO;

namespace FCG_USERSAPI.Interfaces.Services
{
    public interface IClientService
    {
        IEnumerable<Client> GetAll();
        ClientDto? GetById(int id);
        ServiceResult Add(ClientDto client);
    }
}
