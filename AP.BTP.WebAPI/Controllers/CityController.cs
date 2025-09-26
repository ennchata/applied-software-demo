using AP.BTP.Application.CQRS.Cities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AP.DemoProject.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int? pageNumber, [FromQuery] int? pageSize)
        {
            return Ok(await _mediator.Send(new GetAllCitiesQuery()
            {
                PageNumber = pageNumber ?? 1,
                PageSize = pageSize ?? 20
            }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CityDTO dto)
        {
            return Ok(await _mediator.Send(new AddCityCommand() { City = dto }));
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetCityByIdQuery { Id = id });
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteCityCommand() { Id = id }));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] CityDTO dto)
        {
            if (dto == null || dto.Id != id)
            {
                return BadRequest("City ID mismatch");
            }

            var result = await _mediator.Send(new UpdateCityCommand
            {
                Id = dto.Id,
                Population = dto.Population,
                CountryId = dto.CountryId
            });

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}