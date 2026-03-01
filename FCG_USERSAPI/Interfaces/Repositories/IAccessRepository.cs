using FCG_USERSAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FCG_USERSAPI.Interfaces.Repositories
{
    public interface IAccessRepository
    {
        IEnumerable<Access> GetAll();
        Access? GetById(int id);
        ServiceResult Add(Access access);
        ServiceResult Update(Access access);
        ServiceResult Delete(int id);
    }
}
