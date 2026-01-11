using AutoMapper;
using FCG_USERSAPI.Interfaces.Repositories;
using FCG_USERSAPI.Interfaces.Services;
using FCG_USERSAPI.Models;
using FCG_USERSAPI.Models.DTO;
using FCG_USERSAPI.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

namespace FCG_USERSAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IConfiguration config, IMapper mapper)
        {
            _mapper = mapper;
            _config = config;
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public UserDto? GetById(int id)
        {
            return _mapper.Map<UserDto>(_userRepository.GetById(id));
        }

        public UserDto? GetByUser(string user)
        {
            return _mapper.Map<UserDto>(_userRepository.GetByUser(user));
        }

        public List<UserDto> GetListByUser(string user)
        {
            return _mapper.Map<List<UserDto>>(_userRepository.GetListByUser(user));
        }

        public ServiceResult Add(UserDto user, int? idCliente)
        {
            try
            {
                if (string.IsNullOrEmpty(user.UserName))
                    return ServiceResult.Fail("Preencha o usuário!");
                user.UserName = user.UserName.ToUpper();
                var existing = _userRepository.GetListByUser(user.UserName).ToList();
                if (existing.Count() > 0)
                    return ServiceResult.Fail("Usuário já existe!");
                if (user.IdAccessProfile == 0)
                    return ServiceResult.Fail("Preencha o perfil do usuário!");
                var returnPassword = this.ValitePassword(user.PasswordHash);
                if (!string.IsNullOrEmpty(returnPassword))
                    return ServiceResult.Fail("Senha Inválida!" + returnPassword);

                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
                _userRepository.Add(_mapper.Map<User>(user), idCliente);
                return ServiceResult.Ok(user);
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail(ex.Message);
            }
        }

        public string GenerateToken(UserDto user)
        {
            var userComplete = _userRepository.GetByUser(user.UserName);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userComplete.IdUser.ToString()),
                new Claim(ClaimTypes.Actor, userComplete.UserName)
              };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string ValitePassword(string password)
        {
            var retorno = "";
            if (string.IsNullOrEmpty(password) || password.Length < 8)
                retorno += "Senha deve conter 8 caracteres ou mais.";
            if (Regex.Matches(password, @"[^\p{L}\p{Nd}\s]").Count == 0)
                retorno += "Senha deve conter ao menos um caracter especial.";
            if (Regex.Matches(password, @"\p{Lu}").Count == 0 || Regex.Matches(password, @"\p{Ll}").Count == 0)
                retorno += "Senha deve conter letras maiusculas e minusculas.";
            if (Regex.Matches(password, @"\p{Nd}").Count == 0)
                retorno += "Senha deve conter ao menos um número.";
            return retorno;
        }
    }
}