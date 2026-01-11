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
    }
}