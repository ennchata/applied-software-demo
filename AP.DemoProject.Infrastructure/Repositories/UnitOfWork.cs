using AP.BTP.Application.Interfaces;
using AP.DemoProject.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DemoProject.Infrastructure.Repositories {
    public class UnitOfWork : IUnitOfWork {
        private readonly DemoContext _context;
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;

        public UnitOfWork(DemoContext context, ICityRepository cityRepository, ICountryRepository countryRepository) {
            _context = context;
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
        }

        public ICityRepository CityRepository => _cityRepository;
        public ICountryRepository CountryRepository => _countryRepository;

        public async Task Commit() {
            await _context.SaveChangesAsync();
        }
    }
}
