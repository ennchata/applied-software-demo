using AP.BTP.Application.CQRS.Cities;
using AP.BTP.Domain;
using AP.DemoProject.Application.CQRS.Countries;
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
