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

        public ServiceResult Update(Access access)
        {
            try
            {
                var accessUpd = _context.Accesses.Find(access.IdAccess);
                if (accessUpd == null)
                {
                    return ServiceResult.Fail("Accesso não identificado não encontrado!");
                }

                accessUpd.Name = access.Name;
                accessUpd.Endpoint = access.Endpoint;
                accessUpd.IdAccessType = access.IdAccessType;
                accessUpd.IsActive = access.IsActive;
                accessUpd.DtLastUpdate = DateTime.Now;
                accessUpd.IdUserLastUpdate = access.IdUserLastUpdate;
                _context.Accesses.Update(accessUpd);
                _context.SaveChanges();
                return ServiceResult.Ok(accessUpd);
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail("Erro ao atualizar acessos: " + ex.Message);
            }
        }

        public ServiceResult Delete(int id)
        {
            try
            {
                var access = _context.Accesses.FirstOrDefault(x => x.IdAccess == id);
                if (access == null)
                {
                    return ServiceResult.Fail("Acesso não identificado não encontrado!");
                }
                _context.Accesses.Remove(access);
                _context.SaveChanges();
                return ServiceResult.Ok();
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail("Erro ao remover acesso: " + ex.Message);
            }
        }
    }
}
