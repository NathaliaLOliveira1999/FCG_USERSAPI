using FCG_USERSAPI.Interfaces.Repositories;
using FCG_USERSAPI.Models;

namespace FCG_USERSAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll() => _context.Users.ToList();

        public User? GetById(int id) => _context.Users.Find(id);

        public User? GetByUser(string user)
        {
            return _context.Users.Where(x => x.UserName == user.ToUpper()).FirstOrDefault();
        }

        public IEnumerable<User> GetListByUser(string user)
        {
            var result = _context.Users.Where(x => x.UserName == user.ToUpper()).ToList();

            return result ?? Enumerable.Empty<User>();
        }

        public ServiceResult Add(User user, int? idCliente)
        {
            try
            {
                user.IdClient = idCliente;
                user.CreatedAt = DateTime.Now;
                _context.Users.Add(user);
                _context.SaveChanges();
                return ServiceResult.Ok(user);
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail("Erro ao inserir usuário: " + ex.Message);
            }
        }

        public ServiceResult Update(User user)
        {
            try
            {
                var userUpd = _context.Users.Find(user.IdUser);
                if (userUpd == null)
                {
                    return ServiceResult.Fail("Usuario não identificado não encontrado!");
                }
                userUpd.IdClient = user.IdClient;
                userUpd.UserName = user.UserName; 
                userUpd.PasswordHash = user.PasswordHash; 
                userUpd.IdAccessProfile = user.IdAccessProfile;
                userUpd.DtLastUpdate = DateTime.Now;
                userUpd.IdUserLastUpdate = user.IdUserLastUpdate;

                _context.Users.Update(userUpd);
                _context.SaveChanges();
                return ServiceResult.Ok();
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail("Erro ao atualizar usuario: " + ex.Message);
            }
        }

        public ServiceResult Delete(int id)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.IdUser == id);
                if (user == null)
                {
                    return ServiceResult.Fail("user não identificado não encontrado!");
                }
                _context.Users.Remove(user);
                _context.SaveChanges();
                return ServiceResult.Ok();
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail("Erro ao remover usuario: " + ex.Message);
            }
        }
    }
}