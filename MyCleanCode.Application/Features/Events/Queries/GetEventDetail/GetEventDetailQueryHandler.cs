using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyCleanCode.Application.Contracts.Persistence;
using MyCleanCode.Domain.Entities;

namespace MyCleanCode.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQueryHandler : IRequestHandler<GetEventDetailQuery, EventDetailVm>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Event> _eventRepository;

        public GetEventDetailQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }
        public async Task<EventDetailVm> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
        {
            var @event = await _eventRepository.GetByIdAsync(request.EventId);
            var eventDetailDto = _mapper.Map<EventDetailVm>(@event);

            return eventDetailDto;
        }
    }
}