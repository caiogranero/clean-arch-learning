using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<EventDetailVm>> GetById(int eventId)
        {
            var @event = await _mediator.Send(new GetEventDetailQuery() {EventId = eventId});

            return Ok(@event);
        }
    }
}