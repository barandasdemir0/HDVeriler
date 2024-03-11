using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HD_Veriler.Models
{
    public class ChangeEquipment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EquipmentId { get; set; }

        [DisplayName("KULLANICISI KİM")]
        public int UserID { get; set; }

        [DisplayName("EKİPMAN İSMİ")]
        public string? EquipmentName { get; set; }

        [DisplayName("DEĞİŞME TARİHİ")]
        public DateTime ChangeDate { get; set; }

        [DisplayName("DEĞİŞEN PARÇA")]
        public string? Property { get; set; }//Özellikler

        [DisplayName("DEĞİŞME SEBEBİ")]
        public string? Reason { get; set; }//sebep
    }
}
