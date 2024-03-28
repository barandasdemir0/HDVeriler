using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HD_Veriler.Models
{
    public class Role
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Rol ID")]
        public int RolID { get; set; }

        [DisplayName("Rol Adı")]
        public string? RolName { get; set; }

        [DisplayName("Rol Aktifmi")]
        public bool Active { get; set; }
    }
}
