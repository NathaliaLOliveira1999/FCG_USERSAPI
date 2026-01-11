using AutoMapper;
using FCG_USERSAPI.Interfaces.Repositories;
using FCG_USERSAPI.Interfaces.Services;
using FCG_USERSAPI.Models;
using FCG_USERSAPI.Models.DTO;

namespace FCG_USERSAPI.Services
{
    public class ClientService : IClientService
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;
        private readonly IUserService _userService;

        public ClientService(IMapper mapper, IClientRepository clientRepository, IUserService userService)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
            _userService = userService;
        }

        public IEnumerable<Client> GetAll()
        {
            return _clientRepository.GetAll();
        }

        public ClientDto? GetById(int id)
        {
            return _mapper.Map<ClientDto>(_clientRepository.GetById(id));
        }

        public ServiceResult Add(ClientDto client)
        {
            try
            {
                if (string.IsNullOrEmpty(client.Name))
                    return ServiceResult.Fail("Preencha o nome!");
                client.Email = client.Email.Trim();
                client.Email = client.Email.ToLower();
                var returnEmail = this.ValiteEmail(client.Email);
                if (!string.IsNullOrEmpty(returnEmail))
                    return ServiceResult.Fail("E-mail Inválido!" + returnEmail);
                var insertedClient = _clientRepository.Add(_mapper.Map<Client>(client));
                if (!insertedClient.Success)
                    return ServiceResult.Fail(insertedClient.Error ?? "Erro ao inserir cliente.");
                var insertedUSer = _userService.Add(client.User, ((Client)insertedClient.Data).IdClient);
                if (!insertedUSer.Success)
                    return ServiceResult.Fail(insertedUSer.Error ?? "Erro ao inserir usuario.");
                return ServiceResult.Ok(client);
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail("Erro ao inserir usuário: " + ex.Message);
            }
        }

        private string ValiteEmail(string email)
        {
            var retorno = "";
            if (_clientRepository.GetListByEmail(email).ToList().Count() > 0)
                retorno += "E-mail já cadastrado.";
            var parts = email.Split('@');
            if (string.IsNullOrEmpty(email))
                retorno += "E-mail precisa ser preenchido.";
            if (!email.Contains("@") || parts.Length != 2 || parts[0].Length == 0 || parts[0].Length > 64 || parts[0].StartsWith(".") || parts[0].EndsWith(".") || parts[0].Contains(".."))
                retorno += "E-mail inválido.";
            return retorno;
        }

    }
}