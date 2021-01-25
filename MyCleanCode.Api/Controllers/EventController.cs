using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCleanCode.Application.Features.Events.Commands.CreateEvent;
using MyCleanCode.Application.Features.Events.Queries.GetEventDetail;

namespace MyCleanCode.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{eventId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<EventDetailVm>> GetById(int eventId)
        {
            var @event = await _mediator.Send(new GetEventDetailQuery() {EventId = eventId});

            return Ok(@event);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreateEventCommand command)
        {
            var eventId = await _mediator.Send(command);

            return Ok(eventId);
        }
    }
}