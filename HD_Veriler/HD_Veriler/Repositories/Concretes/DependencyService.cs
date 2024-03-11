using AutoMapper;
using HD_Veriler.Models;
using HD_Veriler.Repositories.Abstractions;

namespace HD_Veriler.Repositories.Concretes
{
    public class DependencyService : IDependencyService
    {
        private readonly IRepository<ComputerDetail> _computerRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<ChangeEquipment> _changeEquipment;
        private readonly IRepository<Departman> _departman;
        private readonly IRepository<Entrusted> _entrusted;
        private readonly IRepository<InventoryLaptop> _inventoryLaptop;
        private readonly IRepository<MonitorDetail> _monitorDetail;
        private readonly IRepository<OtherInventory> _otherInventory;
        private readonly IRepository<Score> _scoreRepository;
        private readonly IRepository<UQuestion> _uquestionRepository;
        private readonly IMapper _mapper;

        public DependencyService(
            IRepository<ComputerDetail> computerRepository,
            IRepository<User> userRepository,
            IRepository<ChangeEquipment> changeEquipment,
            IRepository<Departman> departman,
            IRepository<Entrusted> entrusted,
            IRepository<InventoryLaptop> inventoryLaptop,
            IRepository<MonitorDetail> monitorDetail,
            IRepository<OtherInventory> otherInventory,
            IRepository<Score> scoreRepository,
             IRepository<UQuestion> uquestionRepository,
            IMapper mapper)
        {
            _computerRepository = computerRepository;
            _userRepository = userRepository;
            _changeEquipment = changeEquipment;
            _departman = departman;
            _entrusted = entrusted;
            _inventoryLaptop = inventoryLaptop;
            _monitorDetail = monitorDetail;
            _otherInventory = otherInventory;
            _scoreRepository = scoreRepository;
            _uquestionRepository = uquestionRepository;
            _mapper = mapper;
        }

        public IRepository<ComputerDetail> GetComputerRepository()
        {
            return _computerRepository;
        }

        public IRepository<User> GetUserRepository()
        {
            return _userRepository;
        }

        public IRepository<ChangeEquipment> GetChangeEquipment()
        {
            return _changeEquipment;
        }

        public IRepository<Departman> GetDepartmanRepository()
        {
            return _departman;
        }

        public IRepository<Entrusted> GetEntrustedRepository()
        {
            return _entrusted;
        }

        public IRepository<InventoryLaptop> GetInventoryLaptopRepository()
        {
            return _inventoryLaptop;
        }

        public IRepository<MonitorDetail> GetMonitorDetailRepository()
        {
            return _monitorDetail;
        }

        public IRepository<OtherInventory> GetOtherInventoryRepository()
        {
            return _otherInventory;
        }

        public IRepository<Score> GetScoreRepository()
        {
            return _scoreRepository;
        }

        public IRepository<UQuestion> GetQuestionRepository()
        {
            return _uquestionRepository;
        }

        public IMapper GetMapper()
        {
            return _mapper;
        }
    }
}
