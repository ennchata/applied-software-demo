using AP.DemoProject.Application.Interfaces;
using AP.DemoProject.Infrastructure.Contexts;
using AP.DemoProject.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DemoProject.Infrastructure.Extensions {
    public static class Registrator {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services) {
            services.AddDbContext<DemoContext>(options => options.UseSqlServer("name=ConnectionStrings:Database"));

            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
