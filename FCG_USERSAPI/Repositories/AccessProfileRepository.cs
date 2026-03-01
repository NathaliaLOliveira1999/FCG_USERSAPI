using FCG_USERSAPI.Interfaces.Repositories;
using FCG_USERSAPI.Models;
using Microsoft.EntityFrameworkCore;

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

        public ServiceResult Add(AccessProfile profile)
        {
            try
            {
                _context.AccessProfiles.Add(profile);
                _context.SaveChanges();
                return ServiceResult.Ok(profile);
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail("Erro ao inserir profile: " + ex.Message);
            }
        }

        public ServiceResult Update(AccessProfile profile)
        {
            try
            {
                var accessProfile = _context.AccessProfiles.Find(profile.IdAccessProfile);
                if(accessProfile == null)
                {
                    return ServiceResult.Fail("Profile não identificado não encontrado!");
                }
                accessProfile.Name = profile.Name;
                accessProfile.Description = profile.Description;
                accessProfile.DtLastUpdate = DateTime.Now;
                accessProfile.IdUserLastUpdate = profile.IdUserLastUpdate;
                _context.AccessProfiles.Update(accessProfile);
                _context.SaveChanges();
                return ServiceResult.Ok(accessProfile);
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail("Erro ao atualizar profile: " + ex.Message);
            }
        }

        public ServiceResult Delete(int id)
        {
            try
            {
                var accessProfile = _context.AccessProfiles.FirstOrDefault(x => x.IdAccessProfile == id);
                if (accessProfile == null)
                {
                    return ServiceResult.Fail("Profile não identificado não encontrado!");
                }
                _context.AccessProfiles.Remove(accessProfile);
                _context.SaveChanges();
                return ServiceResult.Ok();
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail("Erro ao remover profile: " + ex.Message);
            }
        }
    }
}
