using Pizza.Application.DTOs.Requests;

namespace Pizza.Application.DTOs.Responses;

public class OrderResponse
{
    public int Id { get; set; }

    public IList<PizzaOrderResponse>? Pizzas { get; set; }

    public IList<SideOrderResponse>? Sides { get; set; }
}
