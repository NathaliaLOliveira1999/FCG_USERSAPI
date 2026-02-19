using AutoMapper;
using FCG_USERSAPI.Interfaces.Repositories;
using FCG_USERSAPI.Interfaces.Services;
using FCG_USERSAPI.Models;
using FCG_USERSAPI.Models.DTO;

namespace FCG_USERSAPI.Services
{
    public class AccessProfileService : IAccessProfileService
    {
        private readonly IMapper _mapper;
        private readonly IAccessProfileRepository _profileRepository;

        public AccessProfileService(IMapper mapper, IAccessProfileRepository profileRepository)
        {
            _mapper = mapper;
            _profileRepository = profileRepository;
        }

        public IEnumerable<AccessProfile> GetAll()
        {
            return _profileRepository.GetAll();
        }

        public AccessProfileDto? GetById(int id)
        {
            return _mapper.Map<AccessProfileDto>(_profileRepository.GetById(id));
        }

        public ServiceResult Add(AccessProfileDto accessProfile)
        {
            try
            {
                //if (string.IsNullOrEmpty(client.Name))
                //    return ServiceResult.Fail("Preencha o nome!");
                //client.Email = client.Email.Trim();
                var insertedAccessProfile = _profileRepository.Add(_mapper.Map<AccessProfile>(accessProfile));
                if (!insertedAccessProfile.Success)
                    return ServiceResult.Fail(insertedAccessProfile.Error ?? "Erro ao inserir access profile.");
                return insertedAccessProfile;
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail("Erro ao inserir Access Profile: " + ex.Message);
            }
        }
    }
}