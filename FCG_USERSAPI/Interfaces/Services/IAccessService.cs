using FCG_USERSAPI.Models;
using FCG_USERSAPI.Models.DTO;

namespace FCG_USERSAPI.Interfaces.Services
{
    public interface IAccessService
    {
        IEnumerable<Access> GetAll();
        AccessDto? GetById(int id);
        ServiceResult Add(AccessDto access);
        ServiceResult Update(AccessDto access);
        ServiceResult Delete(int id);
    }
}
