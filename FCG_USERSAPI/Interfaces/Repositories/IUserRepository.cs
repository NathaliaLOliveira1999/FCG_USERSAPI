using FCG_USERSAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FCG_USERSAPI.Interfaces.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User? GetById(int id);
        User? GetByUser(string user);
        IEnumerable<User> GetListByUser(string user);
        ServiceResult Add(User user, int? idCliente);
        ServiceResult Update(User user);
        ServiceResult Delete(int id);
    }
}
