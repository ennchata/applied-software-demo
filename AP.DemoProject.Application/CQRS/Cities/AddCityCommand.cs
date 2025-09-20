using AP.DemoProject.Application.Interfaces;
using AP.DemoProject.Domain;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DemoProject.Application.CQRS.Cities {
    public class AddCityCommand : IRequest<CityDTO> {
        [Required(ErrorMessage = "City is required")]
        public City City { get; set; }
    }

    public class AddCityCommandHandler : IRequestHandler<AddCityCommand, CityDTO> {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddCityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CityDTO> Handle(AddCityCommand request, CancellationToken cancellationToken) {
            var createdCity = await _unitOfWork.CityRepository.Create(request.City);
            await _unitOfWork.Commit();
            return _mapper.Map<CityDTO>(createdCity);
        }
    }
}