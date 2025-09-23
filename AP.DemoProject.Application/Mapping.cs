using AP.DemoProject.Application.CQRS.Cities;
using AP.DemoProject.Application.CQRS.Countries;
using AP.DemoProject.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DemoProject.Application {
    public class Mapping : Profile {
        public Mapping() {
            CreateMap<City, CityDTO>().ReverseMap();
            CreateMap<Country, CountryDTO>();
        }
    }
}
