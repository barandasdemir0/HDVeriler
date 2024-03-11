using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HD_Veriler.Models
{
    public class Departman
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmanID { get; set; }

        [DisplayName("DEPARTMAN ADI")]
        public string? DepartmanName { get; set; }

        [DisplayName("AKTİF/PASİF")]
        public bool Active { get; set; }

		public ICollection<User>? Users { get; set; }
	}
}
