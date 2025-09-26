using AP.BTP.Application.CQRS.Cities;
using AP.BTP.Application.Interfaces;
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
            RuleFor(x => x.Id)
                //.GreaterThan(0).WithMessage("City Id must be greater than 0")
                .MustAsync(async (id, ct) => await unitOfWork.CityRepository.GetByIdAsync(id) != null)
                .WithMessage("City not found");

            RuleFor(x => x.Id)
                .MustAsync(async (id, ct) =>
                {
                    var count = await unitOfWork.CityRepository.CountAsync();
                    return count > 1;
                })
                .WithMessage("City cannot be deleted as it is the last city");
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
            
            uow.CityRepository.Delete(city);
            
            await _emailService.SendEmail(
                "admin@email.com",
                "City Deletion",
                $"The city {city.Name} has been deleted."
            );
            
            await uow.Commit();
            
            return _mapper.Map<CityDTO>(city);
        }
    }
}