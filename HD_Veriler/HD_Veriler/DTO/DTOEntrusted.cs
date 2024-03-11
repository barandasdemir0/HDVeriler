using System.ComponentModel;

namespace HD_Veriler.DTO
{
    public class DTOEntrusted
    {
        public int EntrustedId { get; set; }
        public int UserID { get; set; }
        public int? InventoryId { get; set; }
        public int? OtherInventoryId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set; }
    }
}
