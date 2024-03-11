using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HD_Veriler.Models
{
    public class Entrusted //emanet
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EntrustedId { get; set; }

        [DisplayName("EMANET VERİLEN KİŞİ")]
        public int UserID { get; set; }

        [DisplayName("ALINAN EKİPMAN ADI")]
        public int? InventoryId { get; set; }

        [DisplayName("ALINAN EKİPMAN ADI")]
        public int? OtherInventoryId { get; set; }

        [DisplayName("EKİPMAN VERİLEN TARİH")]
        public DateTime StartDate { get; set; }

        [DisplayName("EKİPMANIN ALINDIĞI TARİH")]
        public DateTime EndDate { get; set; }

        [DisplayName("AKTİF/PASİF")]
        public bool Active { get; set; }
    }
}
