using AP.BTP.Application;
using AP.BTP.Application.Interfaces;
using AP.BTP.Domain;
using AP.DemoProject.Application.Extensions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DemoProject.Application.CQRS.Countries {
    public class GetAllCountriesQuery : IRequest<PagedResult<CountryDTO>> {
        
    }

    public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQuery, PagedResult<CountryDTO>> {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCountriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedResult<CountryDTO>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken) {
            return _mapper.ConvertPagedResult<Country, CountryDTO>(await _unitOfWork.CountryRepository.GetAll(1, 100));
        }
    }
}
