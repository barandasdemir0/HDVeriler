namespace HD_Veriler.DTO
{
    public class DTOUser
    {
        public int UserID { get; set; }
        public int DepartmanID { get; set; }
        public string? NameSurname { get; set; }
        public string? IPV4Adress { get; set; }
        public string? Telephone { get; set; }
        public string? EMail { get; set; }
        public bool Active { get; set; }
        public string? Password { get; set; }
        public bool DepartmanLeader { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? LeadingDepartmentID { get; set; } // Yeni eklenen alan
        public string? Role { get; set; }
    }
}
