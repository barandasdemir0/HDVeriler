using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HD_Veriler.Models
{
    public class User
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("KULLANICISI KİM")]
        public int UserID { get; set; }

        [DisplayName("BULUNDUĞU DEPARTMAN")]
        public int DepartmanID { get; set; }

        [DisplayName("ADI SOYADI")]
        public string? NameSurname { get; set; }

        [DisplayName("İP ADRESİ")]
        public string? IPV4Adress { get; set; }

        [DisplayName("TELEFON NUMARASI")]
        public string? Telephone { get; set; }

        [DisplayName("EMAİL ADRESİ")]
        public string? EMail { get; set; }

        [DisplayName("HALA BİZİMLE ÇALIŞIYORMU?")]
        public bool Active { get; set; }

        [DisplayName("ŞİFRE")]
        public string? Password { get; set; }

        [DisplayName("DEPARTMAN LİDER Mİ?")]
        public bool DepartmanLeader { get; set; }

        [DisplayName("İŞE BAŞLADIĞI TARİH")]
        public DateTime StartDate { get; set; }
  
        [DisplayName("BİTİRDİĞİ TARİH")]
        public DateTime EndDate { get; set; }

        [DisplayName("LİDERLİK ETTİĞİ DEPARTMAN")]
        public int? LeadingDepartmentID { get; set; } // Yeni eklenen alan

        [DisplayName("ROL")]
        public int RolID { get; set; }// Kullanıcı rolü (örneğin: Admin, User, Editor)
    }
}
