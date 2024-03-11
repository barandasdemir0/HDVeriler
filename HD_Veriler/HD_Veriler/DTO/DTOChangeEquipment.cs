namespace HD_Veriler.DTO
{
    public class DTOChangeEquipment
    {
        public int EquipmentId { get; set; }
        public int UserID { get; set; }
        public string? EquipmentName { get; set; }
        public DateTime ChangeDate { get; set; }
        public string? Property { get; set; }
        public string? Reason { get; set; }

    }
}
