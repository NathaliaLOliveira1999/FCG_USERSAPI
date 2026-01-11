namespace FCG_USERSAPI.Models.DTO
{
    public class ClientDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public UserDto User { get; set; }
    }
}
