namespace HD_Veriler.DTO
{
    public class DTOInventoryLaptop
    {
        public int InventoryId { get; set; }
        public string? BrandName { get; set; }
        public int Ram { get; set; }
        public string? Os { get; set; }
        public string? Cpu { get; set; }
        public string? StorageHDD { get; set; }
        public string? StorageSDD { get; set; }
        public string? Programs { get; set; }
        public bool Active { get; set; }
        public string? Material { get; set; }
    }
}
