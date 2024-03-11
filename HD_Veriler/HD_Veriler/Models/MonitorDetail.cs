using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HD_Veriler.Models
{
    public class MonitorDetail
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MonitorId { get; set; }

        [DisplayName("KULLANICISI KİM")]
        public int UserID { get; set; }

        [DisplayName("KAÇ İNÇ")]
        public string? Screen { get; set; }

        [DisplayName("GİRİŞİ NASIL")]
        public string? Input { get; set; }

        [DisplayName("EKRAN ÇÖZÜNÜRLÜĞÜ")]
        public string? Resolution { get; set; }

        [DisplayName("SERİ NO")]
        public string? Serino { get; set; }

        [DisplayName("AKTİF/PASİF")]
        public bool Durum { get; set; }

      
    }
}
