using System.Collections.Generic;
using MediatR;

namespace MyCleanCode.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListQuery : IRequest<List<EventListVm>>
    {
        
    }
}