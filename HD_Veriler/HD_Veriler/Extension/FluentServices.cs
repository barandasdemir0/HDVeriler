using FluentValidation.AspNetCore;
using HD_Veriler;
using HD_Veriler.Models;

namespace HD_Veriler.Extension
{
    public static class FluentServices
    {
        public static void AddFluentValidation(this IMvcBuilder builder)
        {
            //builder.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ComputerDetail>());
            //builder.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ChangeEquipment>());
            //builder.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Departman>());
            //builder.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Entrusted>());
            //builder.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<InventoryLaptop>());
            //builder.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<MonitorDetail>());
            //builder.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<OtherInventory>());
            //builder.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<User>());
        }
    }
}
