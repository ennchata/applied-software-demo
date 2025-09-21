using AP.DemoProject.Application.Exceptions;
using AP.DemoProject.Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.DemoProject.Application.CQRS.Cities
{
    public class DeleteCityCommand : IRequest<CityDTO>
    {
        public int Id { get; set; }

        private readonly IUnitOfWork uow;

    }

    public class DeleteCityValidator : AbstractValidator<DeleteCityCommand>
    {
        public DeleteCityValidator(IUnitOfWork unitOfWork)
        {

        }
    }

    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, CityDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public DeleteCityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailService)
        {
            uow = unitOfWork;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<CityDTO> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var city = await uow.CityRepository.GetByIdAsync(request.Id);
            if (city == null)
            {
                throw new KeyNotFoundException($"City with id {request.Id} not found");
            }

            var citiesAmt = await uow.CityRepository.CountAsync();
            if (citiesAmt == 1)
            {
                throw new LastCityException("City cannot be deleted as it is the last city in the database");
            }
            
            uow.CityRepository.Delete(city);
            
            await uow.Commit();

            await _emailService.SendEmail(
                "admin@email.com",
                "City Deletion",
                $"The city {city.Name} has been deleted."
            );
            
            return _mapper.Map<CityDTO>(city);
        }
    }
}