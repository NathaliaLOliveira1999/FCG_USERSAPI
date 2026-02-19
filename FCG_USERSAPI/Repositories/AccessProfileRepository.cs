using FCG_USERSAPI.Interfaces.Repositories;
using FCG_USERSAPI.Models;

namespace FCG_USERSAPI.Repositories
{
    public class AccessProfileRepository : IAccessProfileRepository
    {
        private readonly AppDbContext _context;

        public AccessProfileRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AccessProfile> GetAll() => _context.AccessProfiles.ToList();

        public AccessProfile? GetById(int id) => _context.AccessProfiles.Find(id);

        //public IEnumerable<Profile> GetListByEmail(string email)
        //{
        //    var result = _context.Profiles.Where(x => x.Email == email.ToLower()).ToList();

        //    return result ?? Enumerable.Empty<Profile>();
        //}

        public ServiceResult Add(AccessProfile profile)
        {
            try
            {
                //client.DtCreate = DateTime.Now;
                _context.AccessProfiles.Add(profile);
                _context.SaveChanges();
                return ServiceResult.Ok(profile);
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail("Erro ao inserir profile: " + ex.Message);
            }
        }
    }
}
