using AP.BTP.Application;
using AP.BTP.Application.CQRS.Cities;
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

namespace AP.DemoProject.Application.CQRS.Cities {
    public class GetAllCitiesQuery : IRequest<PagedResult<CityDTO>> {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllCitiesQueryHandler : IRequestHandler<GetAllCitiesQuery, PagedResult<CityDTO>> {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCitiesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedResult<CityDTO>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken) {
            return _mapper.ConvertPagedResult<City, CityDTO>(await _unitOfWork.CityRepository.GetAllSortByPopulation(request.PageNumber, request.PageSize));
        }
    }
}
