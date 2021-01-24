using MediatR;

namespace MyCleanCode.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQuery : IRequest<EventDetailVm>
    {
        public int EventId { get; set; }
    }
}