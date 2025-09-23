using AP.DemoProject.Application.CQRS.Cities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AP.DemoProject.WebApp.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int? pageNumber, [FromQuery] int? pageSize) {
            return Ok(await _mediator.Send(new GetAllCitiesQuery() {
                PageNumber = pageNumber ?? 1,
                PageSize = pageSize ?? 20
            }));
        }
    }
}
