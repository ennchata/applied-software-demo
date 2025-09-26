using AP.BTP.Application.Interfaces;
using AP.DemoProject.Domain;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.Cities
{
    public class AddCityCommand : IRequest<CityDTO> {
        
        public CityDTO City { get; set; }
    }

    public class AddCityCommandValidator : AbstractValidator<AddCityCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddCityCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.City)
                .NotNull()
                .WithMessage("City cannot be NULL");

            RuleFor(c => c.City.Name)
                .NotEmpty()
                .WithMessage("City name is required")
                .MustAsync(CityNameIsUnique)
                .WithMessage("The city name must be unique");

            RuleFor(c => c.City.Population)
                .GreaterThan(0).WithMessage("Population must be positive.")
                .LessThanOrEqualTo(10000000).WithMessage("Population cannot exceed 10 million.");

            RuleFor(c => c.City.CountryId)
                .NotEmpty()
                .WithMessage("You must choose a country")
                .MustAsync(CountryExists)
                .WithMessage("The specified country does not exist");
        }

        private async Task<bool> CityNameIsUnique(string cityName, CancellationToken cancellationToken)
        {
            City? city = await _unitOfWork.CityRepository.GetByName(cityName);
            return city == null;
        }

        private async Task<bool> CountryExists(int countryId, CancellationToken cancellationToken)
        {
            var country = await _unitOfWork.CountryRepository.GetById(countryId);
            return country != null;
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
            var createdCity = await _unitOfWork.CityRepository.Create(_mapper.Map<City>(request.City));
            await _unitOfWork.Commit();
            return _mapper.Map<CityDTO>(createdCity);
        }
    }


}