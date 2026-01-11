using FCG_USERSAPI.Models;
using FCG_USERSAPI.Models.DTO;

namespace FCG_USERSAPI.Interfaces.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        UserDto? GetById(int id);
        UserDto? GetByUser(string user);
        List<UserDto> GetListByUser(string user);
        ServiceResult Add(UserDto user, int? idCliente);
        string GenerateToken(UserDto user);
    }
}
