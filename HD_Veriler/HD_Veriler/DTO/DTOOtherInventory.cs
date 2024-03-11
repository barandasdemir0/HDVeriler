namespace HD_Veriler.DTO
{
    public class DTOOtherInventory
    {
        public int OtherInventoryId { get; set; }
        public string? InventoryName { get; set; }
        public int DepartmanID { get; set; }
        public int UserID { get; set; }
        public string? BrandName { get; set; }
        public DateTime AddDate { get; set; }
        public bool Active { get; set; }
        public string? Material { get; set; }
    }
}
