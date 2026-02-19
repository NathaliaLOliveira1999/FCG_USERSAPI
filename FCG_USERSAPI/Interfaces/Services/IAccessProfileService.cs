using FCG_USERSAPI.Models;
using FCG_USERSAPI.Models.DTO;

namespace FCG_USERSAPI.Interfaces.Services
{
    public interface IAccessProfileService
    {
        IEnumerable<AccessProfile> GetAll();
        AccessProfileDto? GetById(int id);
        ServiceResult Add(AccessProfileDto accessProfile);
    }
}
