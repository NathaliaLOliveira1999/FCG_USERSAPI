namespace FCG_USERSAPI.Models.DTO
{
    public class AccessProfileDto
    {
        public int IdAccessProfile { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DtLastUpdate { get; set; }
        public int IdUserLastUpdate { get; set; }
    }
}
