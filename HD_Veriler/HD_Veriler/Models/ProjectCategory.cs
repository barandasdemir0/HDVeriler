using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HD_Veriler.Models
{
    public class ProjectCategory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       
        public int ProjeCategoryID { get; set; }

        [DisplayName("Kategori Adı")]
        public string? ProjeCategoryName { get; set; }

        [DisplayName("Aktif/Pasif")]
        public bool Active { get; set; }
    }
}
