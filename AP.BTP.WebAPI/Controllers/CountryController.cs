using AP.DemoProject.Application.CQRS.Countries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AP.DemoProject.WebApp.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase {
        private readonly IMediator _mediator;

        public CountryController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            return Ok(await _mediator.Send(new GetAllCountriesQuery()));
        }
    }
}