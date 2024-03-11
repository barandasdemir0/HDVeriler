using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HD_Veriler.Models
{
    public class Score
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
        public int ScoreID { get; set; }

        [DisplayName("Puanlayacağın Kişi")]
        public int UserID { get; set; }

        [DisplayName("Soru")]
        public int QuestionID { get; set; }

        [DisplayName("Cevap")]
        public string? Answer { get; set; }

        [DisplayName("Puan")]
        public int Point { get; set; }
    }
}
