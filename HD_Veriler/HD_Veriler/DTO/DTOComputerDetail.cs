namespace HD_Veriler.DTO
{
    public class DTOComputerDetail
    {
        public int ComputerId { get; set; }
        public int UserID { get; set; }
        public int Ram { get; set; }
        public string? Os { get; set; }
        public string? OsSerialName { get; set; }
        public string? Cpu { get; set; }
        public string? StorageHDD { get; set; }
        public string? StorageSDD { get; set; }
        public string? DisplayCard { get; set; }
        public string? MotherBoard { get; set; }
        public DateTime FormatDate { get; set; }
        public bool Active { get; set; }
      
    }
}
