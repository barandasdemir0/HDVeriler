using Microsoft.EntityFrameworkCore;

namespace HD_Veriler.Models
{
    public class HDVerilerContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:HDVeriConnection"]);
        }

        public HDVerilerContext(DbContextOptions<HDVerilerContext> options)
        : base(options)
        {
        }

        public DbSet<ChangeEquipment> ChangeEquipments { get; set; }
        public DbSet<ComputerDetail> ComputerDetails { get; set; }
        public DbSet<Departman> Departmans { get; set; }
        public DbSet<Entrusted> Entrusteds { get; set; }
        public DbSet<InventoryLaptop> InventoryLaptops { get; set; }
        public DbSet<MonitorDetail> MonitorDetails { get; set; }
        public DbSet<OtherInventory> OtherInventorys { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<UQuestion> uQuestions { get; set; }

        public DbSet<Role> roles { get; set; }
    }
}
