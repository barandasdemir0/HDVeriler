using AutoMapper;
using HD_Veriler.Models;

namespace HD_Veriler.Repositories.Abstractions
{
    public interface IDependencyService
    {
        IRepository<ComputerDetail> GetComputerRepository();
        IRepository<User> GetUserRepository();
        IRepository<ChangeEquipment> GetChangeEquipment();
        IRepository<Departman> GetDepartmanRepository();
        IRepository<Entrusted> GetEntrustedRepository();
        IRepository<InventoryLaptop> GetInventoryLaptopRepository();
        IRepository<MonitorDetail> GetMonitorDetailRepository();
        IRepository<OtherInventory> GetOtherInventoryRepository();
        IRepository<Score> GetScoreRepository();
        IRepository<UQuestion> GetQuestionRepository();
        IMapper GetMapper();
    }
}
