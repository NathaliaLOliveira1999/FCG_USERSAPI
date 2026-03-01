using FCG_USERSAPI.Models;

namespace FCG_USERSAPI.Interfaces.Repositories
{
    public interface IAccessProfileRepository
    {
        IEnumerable<AccessProfile> GetAll();

        AccessProfile? GetById(int id);
        ServiceResult Add(AccessProfile profile);
        ServiceResult Update(AccessProfile profile);
        ServiceResult Delete(int id);
    }
}
