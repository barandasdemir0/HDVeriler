using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HD_Veriler.Models
{
    public class Project
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Proje ID")]
        public int ProjeID { get; set; }


        [DisplayName("Proje Kategori ID/AD")]
        public int ProjeCategoryID { get; set; }


        [DisplayName("Proje AD")]
        public string? ProjeAd { get; set; }


        [DisplayName("Proje ÜLKESİ")]
        public string? ProjeCountry { get; set; }


        [DisplayName("Proje ŞEHRİ")]
        public string? ProjeCity { get; set; }


        [DisplayName("Proje KODU")]
        public string? ProjeKod { get; set; }


        [DisplayName("Ticari KODU")]
        public string? TradeKod { get; set; }


        [DisplayName("Ticari Sorumlu")]
        public int TradeResponsible { get; set; }


        [DisplayName("Proje Mühendisi")]
        public int ProjeEngineer { get; set; }

      
        [DisplayName("Aktif/Pasif")]
        public bool Active { get; set; }


        [DisplayName("İŞE BAŞLAMA TARİHİ")]
        public DateTime StartDate { get; set; }


        [DisplayName("Proje Süresi * tahminen veya şuan ki durumu")]
        public string? ProjeDuration { get; set; }


        [DisplayName("Müşteri")]
        public string? ProjeCustomer { get; set; }

        
        [DisplayName("Resim")]
        public string? PhotoPath { get; set; }


        [DisplayName("Kurulu Güç")]
        public string? InstalledCapacity { get; set; }


        [DisplayName("Sulama Alanı")]
        public string? IrrigationArea { get; set; }


        [DisplayName("Drenaj Alanı")]
        public string? DrainageArea { get; set; }


        [DisplayName("Açıklama")]
        public string? Description { get; set; }



        //installed capacity=kurulu güç , irrigation area=sulama alanı,drainage area=drenaj alanı,working time,ek Açıklama





    }
}
