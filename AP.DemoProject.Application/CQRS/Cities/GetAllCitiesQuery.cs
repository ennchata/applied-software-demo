using AP.DemoProject.Application.Interfaces;
using AP.DemoProject.Domain;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DemoProject.Application.CQRS.Cities {
    public class GetAllCitiesQuery : IRequest<IEnumerable<CityDTO>> {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllCitiesQueryHandler : IRequestHandler<GetAllCitiesQuery, IEnumerable<CityDTO>> {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCitiesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CityDTO>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken) {
            return _mapper.Map<IEnumerable<CityDTO>>(await _unitOfWork.CityRepository.GetAllSortByPopulation(request.PageNumber, request.PageSize));
        }
    }
}
