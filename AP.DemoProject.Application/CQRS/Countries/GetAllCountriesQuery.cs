using AP.DemoProject.Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DemoProject.Application.CQRS.Countries {
    public class GetAllCountriesQuery : IRequest<IEnumerable<CountryDTO>> {
        
    }

    public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQuery, IEnumerable<CountryDTO>> {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCountriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CountryDTO>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken) {
            return _mapper.Map<IEnumerable<CountryDTO>>(await _unitOfWork.CountryRepository.GetAll(1, 100));
        }
    }
}
