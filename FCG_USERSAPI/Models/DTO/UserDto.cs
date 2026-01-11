namespace FCG_USERSAPI.Models.DTO
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public int IdAccessProfile { get; set; }
        public int? IdClient { get; set; }
    }
}
