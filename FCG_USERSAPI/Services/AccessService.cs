using AutoMapper;
using FCG_USERSAPI.Interfaces.Repositories;
using FCG_USERSAPI.Interfaces.Services;
using FCG_USERSAPI.Models;
using FCG_USERSAPI.Models.DTO;

namespace FCG_USERSAPI.Services
{
    public class AccessService : IAccessService
    {
        private readonly IMapper _mapper;
        private readonly IAccessRepository _accessRepository;
        public AccessService(IMapper mapper, IAccessRepository accessRepository)
        {
            _mapper = mapper;
            _accessRepository = accessRepository;
        }

        public IEnumerable<Access> GetAll()
        {
            return _accessRepository.GetAll();
        }

        public AccessDto? GetById(int id)
        {
            return _mapper.Map<AccessDto>(_accessRepository.GetById(id));
        }

        public ServiceResult Add(AccessDto access)
        {
            try
            {
                var insertedAccess = _accessRepository.Add(_mapper.Map<Access>(access));
                if (!insertedAccess.Success)
                    return ServiceResult.Fail(insertedAccess.Error ?? "Erro ao inserir access.");
                return insertedAccess;
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail("Erro ao inserir Access: " + ex.Message);
            }
        }

        public ServiceResult Update(AccessDto access)
        {
            return _accessRepository.Update(_mapper.Map<Access>(access));
        }

        public ServiceResult Delete(int id)
        {
            return _accessRepository.Delete(id);
        }
    }
}