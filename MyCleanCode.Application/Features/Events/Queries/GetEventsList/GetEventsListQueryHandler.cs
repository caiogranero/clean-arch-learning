using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyCleanCode.Application.Contracts.Persistence;
using MyCleanCode.Domain.Entities;

namespace MyCleanCode.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListQueryHandler : IRequestHandler<GetEventsListQuery, List<EventListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Event> _eventRepository;

        public GetEventsListQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }
        public async Task<List<EventListVm>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
        {
            var allEvents = await _eventRepository.ListAllAsync();
            var orderedEvents = allEvents.OrderBy(x => x.Date);
            return _mapper.Map<List<EventListVm>>(orderedEvents);
        }
    }
}