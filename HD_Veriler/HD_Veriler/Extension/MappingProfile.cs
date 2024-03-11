using AutoMapper;
using HD_Veriler.DTO;
using HD_Veriler.Models;

namespace HD_Veriler.Extension
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ComputerDetail, DTOComputerDetail>().ReverseMap();
            CreateMap<ChangeEquipment, DTOChangeEquipment>().ReverseMap();
            CreateMap<Departman, DTODepartman>().ReverseMap();
            CreateMap<Entrusted, DTOEntrusted>().ReverseMap();
            CreateMap<InventoryLaptop, DTOInventoryLaptop>().ReverseMap();
            CreateMap<MonitorDetail, DTOMonitorDetail>().ReverseMap();
            CreateMap<OtherInventory, DTOOtherInventory>().ReverseMap();
            CreateMap<User, DTOUser>().ReverseMap();
            CreateMap<Score, DTOScore>().ReverseMap();
            CreateMap<UQuestion, DTOUQestion>().ReverseMap();

        }
    }
}
