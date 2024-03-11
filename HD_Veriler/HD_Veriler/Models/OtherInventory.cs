using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HD_Veriler.Models
{
    public class OtherInventory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OtherInventoryId { get; set; }

        [DisplayName("ENVANTER ADI")]
        public string? InventoryName { get; set; }

        [DisplayName("VAR İSE KULLANILAN DEPARTMAN")]
        public int DepartmanID { get; set; }

        [DisplayName("VAR İSE KULLANICISI KİM")]
        public int UserID { get; set; }

        [DisplayName("MARKASI")]
        public string? BrandName { get; set; }

        [DisplayName("EKLENME TARİHİ")]
        public DateTime AddDate { get; set; }

        [DisplayName("AKTİF/PASİF")]
        public bool Active { get; set; }

        [DisplayName("EK MALZEMESİ")]
        public string? Feature { get; set; }//özellikleri
    }
}
