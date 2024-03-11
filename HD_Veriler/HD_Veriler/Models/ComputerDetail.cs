using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HD_Veriler.Models
{
    public class ComputerDetail
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ComputerId { get; set; }

        [DisplayName("KULLANICISI KİM")]
        public int UserID { get; set; }

        [DisplayName("RAM")]
        public int Ram { get; set; }

        [DisplayName("İŞLETİM SİSTEMİ")]
        public string? Os { get; set; }

        [DisplayName("İŞLETİM SİSTEMİ SERİ NUMARASI")]
        public string? OsSerialName { get; set; }

        [DisplayName("İŞLEMCİ MODELİ")]
        public string? Cpu { get; set; }

        [DisplayName("HDD VARMI (VARSA BOYUTU)")]
        public string? StorageHDD { get; set; }

        [DisplayName("SSD VARMI (VARSA BOYUTU)")]
        public string? StorageSDD { get; set; }

        [DisplayName("EKRAN KARTI")]
        public string? DisplayCard { get; set; }

        [DisplayName("ANA KART")]
        public string? MotherBoard { get; set; }

        [DisplayName("FORMAT ATILAN TARİH")]
        public DateTime FormatDate { get; set; }

        [DisplayName("AKTİF/PASİF")]
        public bool Active { get; set; }

        
        //[DisplayName("NE ZAMANDAN BERİ KULLANILMIYOR")]
       // public DateTime PasifDate { get; set; }

        //[DisplayName("ESKİ KULLANICISI KİMDİ")]
        //public int? BeforeUser { get; set; }
    }
}
