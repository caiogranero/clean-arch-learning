using AutoMapper;
using MyCleanCode.Application.Features.Categories.Queries.GetCategoriesList;
using MyCleanCode.Application.Features.Events;
using MyCleanCode.Application.Features.Events.Commands.CreateEvent;
using MyCleanCode.Application.Features.Events.Queries.GetEventDetail;
using MyCleanCode.Application.Features.Events.Queries.GetEventsList;
using MyCleanCode.Domain.Entities;

namespace MyCleanCode.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Event, CreateEventCommand>();
        }
    }
}