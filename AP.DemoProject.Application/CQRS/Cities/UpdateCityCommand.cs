using AP.DemoProject.Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DemoProject.Application.CQRS.Cities
{
    public class UpdateCityCommand : IRequest<CityDTO>
    {
        public int Id { get; set; }
        public int Population { get; set; }
        public int CountryId { get; set; }
    }
    public class UpdateCityValidator : AbstractValidator<UpdateCityCommand>
    {
        public UpdateCityValidator()
        {
            //RuleFor(x => x.Population)
            //    .GreaterThanOrEqualTo(0)
            //    .LessThanOrEqualTo(10000000)
            //    .WithMessage("inwoners aantal mag niet meer dan 10mil zijn");

            //RuleFor(x => x.CountryId)
            //    .GreaterThan(0)
            //    .WithMessage("kies een land aub");
        }
    }

    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, CityDTO>
    {
        private readonly ICityRepository _cityRepo;
        private readonly IMapper _mapper;

        public UpdateCityCommandHandler(ICityRepository cityRepo, IMapper mapper)
        {
            _cityRepo = cityRepo;
            _mapper = mapper;
        }

        public async Task<CityDTO> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _cityRepo.GetByIdAsync(request.Id);
            if (city == null)
                throw new KeyNotFoundException($"City with Id {request.Id} not found");

            //naam mag niet aangepast worden, alleen population encountryId
            city.Population = request.Population;
            city.CountryId = request.CountryId;

            await _cityRepo.UpdateAsync(city);

            return _mapper.Map<CityDTO>(city);
        }
    }
}
