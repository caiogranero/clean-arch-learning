using System;
using MediatR;

namespace MyCleanCode.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}