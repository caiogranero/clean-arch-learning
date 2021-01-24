using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyCleanCode.Domain.Entities;
using MyCleanCode.Persistence;

namespace MyCleanCode.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListQueryHandler : IRequestHandler<GetEventsListQuery, List<EventListVm>>
    {
        private readonly IMapper _mapper;
        private readonly CleanCodeContext _cleanCodeContext;

        public GetEventsListQueryHandler(IMapper mapper, CleanCodeContext cleanCodeContext)
        {
            _mapper = mapper;
            _cleanCodeContext = cleanCodeContext;
        }
        public async Task<List<EventListVm>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
        {
            var allEvents = await _cleanCodeContext.Events.ToListAsync(cancellationToken);
            var orderedEvents = allEvents.OrderBy(x => x.Date);
            return _mapper.Map<List<EventListVm>>(orderedEvents);
        }
    }
}