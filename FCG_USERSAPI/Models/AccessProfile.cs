using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCG_USERSAPI.Models
{
    [Table("ACCESSPROFILE")]
    public class AccessProfile
    {
        [Key]
        [Column("IDACCESSPROFILE")]
        public int IdAccessProfile { get; set; }

        [Column("NAME")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column("DESCRIPTION")]
        [StringLength(255)]
        public string Description { get; set; }

        [Column("DTLASTUPDATE")]
        [Required]
        public DateTime DtLastUpdate { get; set; }

        [Column("IDUSERLASTUPDATE")]
        [Required]
        public int IdUserLastUpdate { get; set; }

        //// 🔗 Navigation Property (FK)
        //[ForeignKey("IdUserLastUpdate")]
        //public virtual AppUser UserLastUpdate { get; set; }
    }
}
