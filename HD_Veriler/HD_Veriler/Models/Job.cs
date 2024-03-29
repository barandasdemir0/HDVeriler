using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HD_Veriler.Models
{
    public class Job
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Mesleği ID")]
        public int JobID { get; set; }

        [DisplayName("Meslek AD")]
        public int JobName { get; set; }

        [DisplayName("Aktif/Pasif")]
        public bool Active { get; set; }

    }
}
