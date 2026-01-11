using FCG_USERSAPI.Interfaces.Repositories;
using FCG_USERSAPI.Models;

namespace FCG_USERSAPI.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Client> GetAll() => _context.Clients.ToList();

        public Client? GetById(int id) => _context.Clients.Find(id);

        public IEnumerable<Client> GetListByEmail(string email)
        {
            var result = _context.Clients.Where(x => x.Email == email.ToLower()).ToList();

            return result ?? Enumerable.Empty<Client>();
        }

        public ServiceResult Add(Client client)
        {
            try
            {
                client.DtCreate = DateTime.Now;
                _context.Clients.Add(client);
                _context.SaveChanges();
                return ServiceResult.Ok(client);
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail("Erro ao inserir cliente: " + ex.Message);
            }
        }
    }
}
