using AutoMapper;
using Sample.Application.Features.Categories.Commands.CreateCateogry;
using Sample.Application.Features.Categories.Queries.GetCategoriesList;
using Sample.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using Sample.Application.Features.Events.Commands.CreateEvent;
using Sample.Application.Features.Events.Commands.UpdateEvent;
using Sample.Application.Features.Events.Queries.GetEventDetail;
using Sample.Application.Features.Events.Queries.GetEventsExport;
using Sample.Application.Features.Events.Queries.GetEventsList;
using Sample.Application.Features.Orders.Queries.GetOrdersForMonth;
using Sample.Domain.Entities;

namespace Sample.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryListVm>().ReverseMap();
            CreateMap<Category, CategoryEventListVm>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();

            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();

            CreateMap<Order, OrdersForMonthDto>();
        }
    }
}
