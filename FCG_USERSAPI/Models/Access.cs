using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCG_USERSAPI.Models
{
    [Table("ACCESS")]
    public class Access
    {
        [Key]
        [Column("IDACCESS")]
        public int IdAccess { get; set; }

        [Column("NAME")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Column("ENDPOINT")]
        [Required]
        [StringLength(255)]
        public string Endpoint { get; set; }

        [Column("IDACCESSTYPE")]
        [Required]
        public int IdAccessType { get; set; }

        [Column("ISACTIVE")]
        [Required]
        public bool IsActive { get; set; }

        [Column("DTCREATE")]
        [Required]
        public DateTime DtCreate { get; set; }
    }
}
