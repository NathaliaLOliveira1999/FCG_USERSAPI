using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCG_USERSAPI.Models
{
    [Table("CLIENT")]
    public class Client
    {
        [Key]
        [Column("IDCLIENT")]
        public int IdClient { get; set; }
        [Column("NAME")]
        public string Name { get; set; }
        [Column("DTCREATE")]
        public DateTime DtCreate { get; set; }
        [Column("EMAIL")]
        public string Email { get; set; }
        [Column("TELEFONE")]
        public string Telefone { get; set; }
    }
}
