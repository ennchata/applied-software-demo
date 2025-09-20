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
        private readonly IUnitOfWork uow;
        public UpdateCityValidator(IUnitOfWork unitOfWork)
        {
            uow = unitOfWork;
            RuleFor(x => x.Population)
                .GreaterThanOrEqualTo(0)
                .WithMessage("inwoners aantal moet positief getal zijn")
                .LessThanOrEqualTo(10000000)
                .WithMessage("inwoners aantal mag niet meer dan 10mil zijn");

            RuleFor(x => x.CountryId)
                .GreaterThan(-4)
                .WithMessage("kies een land aub");
        }
    }

    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, CityDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper _mapper;

        public UpdateCityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            uow = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CityDTO> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var city = await uow.CityRepository.GetByIdAsync(request.Id);
            if (city == null)
                throw new KeyNotFoundException($"City with Id {request.Id} not found");

            //naam mag niet aangepast worden, alleen population encountryId
            city.Population = request.Population;
            city.CountryId = request.CountryId;

            uow.CityRepository.Update(city);
            await uow.Commit();

            return _mapper.Map<CityDTO>(city);
        }
    }
}
