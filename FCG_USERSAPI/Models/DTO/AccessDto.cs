namespace FCG_USERSAPI.Models.DTO
{
    public class AccessDto
    {
        public int IdAccess { get; set; }
        public string Name { get; set; }
        public string Endpoint { get; set; }
        public int IdAccessType { get; set; }
        public bool IsActive { get; set; }
    }
}
