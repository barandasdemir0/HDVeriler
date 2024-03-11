using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HD_Veriler.Models
{
    public class UQuestion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionID { get; set; }
        [DisplayName("Soru")]
        public string? Question { get; set; }
        public bool Active { get; set; }
    }
}
