using AutoMapper;
using Pizza.Application.DTOs;
using Pizza.Application.DTOs.Requests;
using Pizza.Application.DTOs.Responses;
using Pizza.Domain.Entities;

namespace Pizza.Application.Mappings;

public class MapperProfile : Profile
{
	public MapperProfile()
	{
		CreateMap<Domain.Entities.Pizza, PizzaDto>().ReverseMap();
        CreateMap<PizzaOrderRequest, PizzaDto>();
        CreateMap<PizzaDto, PizzaResponse>();
        CreateMap<PizzaDto, PizzaOrderResponse>();

        CreateMap<Side, SideDto>().ReverseMap();
        CreateMap<SideOrderRequest, SideDto>();
        CreateMap<SideDto, SideOrderResponse>();
        CreateMap<SideDto, SideResponse>();

        CreateMap<Ingredient, IngredientDto>().ReverseMap();
        CreateMap<IngredientDto, IngredientResponseBase>();
        CreateMap<IngredientDto, IngredientResponse>();
        CreateMap<IngredientDto, IngredientOrderResponse>();
        CreateMap<IngredientOrderRequest, IngredientDto>();

        CreateMap<Order, OrderDto>().ReverseMap();
        CreateMap<OrderDto, OrderResponse>();
        CreateMap<CreateOrderRequest, OrderDto>();
        CreateMap<OrderDto, CreateOrderResponse>();
    }
}
