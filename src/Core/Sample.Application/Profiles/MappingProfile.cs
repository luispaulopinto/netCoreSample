using System.Data;
using AutoMapper;
using Sample.Application.Features.Categories.Commands.CreateCateogry;
using Sample.Application.Features.Categories.Queries.GetCategoriesList;
using Sample.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using Sample.Application.Features.Clients.Commands.CreateClient;
using Sample.Application.Features.Clients.Commands.UpdateClient;
using Sample.Application.Features.Clients.Queries.GetClientDetail;
using Sample.Application.Features.Clients.Queries.GetClientWithSubClients;
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
            CreateMap<Event, CategoryEventDto>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryListVm>().ReverseMap();
            CreateMap<Category, CategoryEventListVm>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();

            CreateMap<Order, OrdersForMonthDto>();

            CreateMap<Client, ClientListWithSubClientsVm>()
                .ForMember(
                    dest => dest.ChildrenClient,
                    opt =>
                    {
                        opt.Condition(src => src.ChildrenClient is not null);
                    }
                )
                .ReverseMap();
            CreateMap<Client, ClientDetailVm>()
                .ForMember(dest => dest.ParentId, input => input.MapFrom(i => i.ParentClientId))
                .ReverseMap();

            CreateMap<Client, CreateClientDto>().ReverseMap();
            CreateMap<Client, CreateClientCommand>().ReverseMap();
            CreateMap<Client, UpdateClientCommand>().ReverseMap();
        }
    }
}
