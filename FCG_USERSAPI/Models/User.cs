using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCG_USERSAPI.Models
{
    [Table("APP_USER")]
    public class User
    {
        [Key]
        [Column("IDUSER")]
        public int IdUser { get; set; }

        [Column("IDCLIENT")]
        [ForeignKey(nameof(Client))]
        public int? IdClient { get; set; }

        [Column("USERNAME")]
        public string UserName { get; set; }

        [Column("PASSWORDHASH")]
        public string PasswordHash { get; set; }

        [Column("CREATEDAT")]
        public DateTime CreatedAt { get; set; }
        [Column("IDACCESSPROFILE")]
        public int IdAccessProfile { get; set; }
    }
}
