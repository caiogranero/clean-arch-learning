using System;

namespace MyCleanCode.Application.Features.Events.Queries.GetEventsList
{
    public class EventListVm
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; }
    }
}