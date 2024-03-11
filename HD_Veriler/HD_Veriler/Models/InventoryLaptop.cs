using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HD_Veriler.Models
{
    public class InventoryLaptop //envanter laptop
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InventoryId { get; set; }

        [DisplayName("MARKA ADI")]
        public string? BrandName { get; set; }

        [DisplayName("RAM")]
        public int Ram { get; set; }

        [DisplayName("İŞLETİM SİSTEMİ")]
        public string? Os { get; set; }

        [DisplayName("İŞLEMCİ MODELİ")]
        public string? Cpu { get; set; }

        [DisplayName("HDD VARMI (VAR İSE BOYUTU)")]
        public string? StorageHDD { get; set; }

        [DisplayName("SSD VARMI (VAR İSE BOYUTU)")]
        public string? StorageSDD { get; set; }

        [DisplayName("YÜKLENEN PROGRAMLAR")]
        public string? Programs { get; set; }

        [DisplayName("AKTİF KULLANIDAMI YOKSA PASİF Mİ")]
        public bool Active { get; set; }

        [DisplayName("YANINDA VERİLEN EK MALZEMELER")]
        public string? Material { get; set; }//ek malzemeler
    }
}
