using AP.DemoProject.Application.Interfaces;
using AP.DemoProject.Domain;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DemoProject.Application.CQRS.Cities {
    public class AddCityCommand : IRequest<CityDTO> {
        
        public City City { get; set; }
    }

    public class AddCityCommandValidator : AbstractValidator<AddCityCommand>
    {
        public AddCityCommandValidator()
        {
            RuleFor(c => c.City)
                .NotNull()
                .WithMessage("City cannot be NULL");

            RuleFor(c => c.City.Population)
                .GreaterThan(0).WithMessage("Population must be positive.")
                .LessThanOrEqualTo(10000000).WithMessage("Population cannot exceed 10 million.");

            RuleFor(c => c.City.CountryId)
                .NotEmpty()
                .WithMessage("You must choose a country");

        }
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