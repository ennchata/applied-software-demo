using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DemoProject.Application.Interfaces {
    public interface IUnitOfWork {
        public ICityRepository CityRepository { get; }
        public ICountryRepository CountryRepository { get; }
        Task Commit();
    }
}
