using AP.DemoProject.Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DemoProject.Application.CQRS.Cities
{
    public class GetCityByIdQuery : IRequest<CityDTO>
    {
        public int Id { get; set; }
    }

    public class GetCityByIdQueryHandler : IRequestHandler<GetCityByIdQuery, CityDTO>
    {
        private readonly ICityRepository _cityRepo;
        private readonly IMapper _mapper;

        public GetCityByIdQueryHandler(ICityRepository cityRepo, IMapper mapper)
        {
            _cityRepo = cityRepo;
            _mapper = mapper;
        }

        public async Task<CityDTO> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        {
            var city = await _cityRepo.GetByIdAsync(request.Id);
            if (city == null)
                throw new KeyNotFoundException($"CITY ID: {request.Id} NOT FOUND!");

            return _mapper.Map<CityDTO>(city);
        }
    }
}
