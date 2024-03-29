namespace HD_Veriler.DTO
{
    public class DTOProject
    {
        public int ProjeID { get; set; }
        public int ProjeCategoryID { get; set; }
        public string? ProjeAd { get; set; }
        public string? ProjeCountry { get; set; }
        public string? ProjeCity { get; set; }
        public string? ProjeKod { get; set; }
        public string? TradeKod { get; set; }
        public int TradeResponsible { get; set; }
        public int ProjeEngineer { get; set; }
        public bool Active { get; set; }
        public DateTime StartDate { get; set; }
        public string? ProjeDuration { get; set; }
        public string? ProjeCustomer { get; set; }
        public string? PhotoPath { get; set; }
        public string? InstalledCapacity { get; set; }
        public string? IrrigationArea { get; set; }
        public string? DrainageArea { get; set; }
        public string? Description { get; set; }
    }
}
