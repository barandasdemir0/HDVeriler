using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using HD_Veriler.Repositories.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HD_Veriler.Repositories.Concretes;
using HD_Veriler.Models;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;

namespace HD_Veriler.Extension
{
    public static class DataLayer
    {
        public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services , IConfiguration config)
        {
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            services.AddScoped<IDependencyService, DependencyService>();

            services.AddDbContext<HDVerilerContext>(options => options.UseSqlServer(config.GetConnectionString("HDVeriConnection")));

			//services.AddDbContext<HDVerilerContext>();  
            services.AddScoped<IRepository<ComputerDetail>, Repository<ComputerDetail>>();
            services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped<IRepository<ChangeEquipment>, Repository<ChangeEquipment>>();
            services.AddScoped<IRepository<Departman>, Repository<Departman>>();
            services.AddScoped<IRepository<Entrusted>, Repository<Entrusted>>();
            services.AddScoped<IRepository<InventoryLaptop>, Repository<InventoryLaptop>>();
            services.AddScoped<IRepository<MonitorDetail>, Repository<MonitorDetail>>();
            services.AddScoped<IRepository<OtherInventory>, Repository<OtherInventory>>();
            services.AddScoped<IRepository<Score>, Repository<Score>>();
            services.AddScoped<IRepository<UQuestion>, Repository<UQuestion>>();
            services.AddScoped<IRepository<Role>, Repository<Role>>();
            services.AddScoped<IRepository<Job>, Repository<Job>>();
            services.AddScoped<IRepository<Project>, Repository<Project>>();
            services.AddScoped<IRepository<ProjectCategory>, Repository<ProjectCategory>>();
            return services;
        }
    }
}
