using FCG_USERSAPI.Interfaces.Repositories;
using FCG_USERSAPI.Models;

namespace FCG_USERSAPI.Repositories
{
    public class AccessRepository : IAccessRepository
    {
        private readonly AppDbContext _context;

        public AccessRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Access> GetAll() => _context.Accesses.ToList();

        public Access? GetById(int id) => _context.Accesses.Find(id);

        //public IEnumerable<Profile> GetListByEmail(string email)
        //{
        //    var result = _context.Profiles.Where(x => x.Email == email.ToLower()).ToList();

        //    return result ?? Enumerable.Empty<Profile>();
        //}

        public ServiceResult Add(Access access)
        {
            try
            {
                //client.DtCreate = DateTime.Now;
                _context.Accesses.Add(access);
                _context.SaveChanges();
                return ServiceResult.Ok(access);
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail("Erro ao inserir access: " + ex.Message);
            }
        }
    }
}
