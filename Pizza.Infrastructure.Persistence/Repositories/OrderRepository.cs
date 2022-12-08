using Microsoft.EntityFrameworkCore;
using Pizza.Domain.Entities;
using Pizza.Infrastructure.Persistence.Interfaces;

namespace Pizza.Infrastructure.Persistence.Repositories;

public class OrderRepository : BaseRepository, IOrderRepository
{
    private readonly AppDbContext _dbContext;

    public OrderRepository(AppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IList<Order>> GetOrdersAsync()
    {
        var entities = await _dbContext.Orders?
            .Include(o => o.Pizzas)
            .ThenInclude(p => p.Ingredients)
            .Include(o => o.Sides)
            .ToListAsync();

        return entities;
    }

    public async Task<Order> AddOrderAsync(Order order)
    {
        var entityToInsert = new Order
        {
            Pizzas = new List<Domain.Entities.Pizza>(),
            Sides = new List<Side>()
        };

        if (order.Pizzas?.Any() ?? false)
        {
            foreach(var pizza in order.Pizzas)
            {
                var pizzaToAdd = new Domain.Entities.Pizza
                {
                    IsCustom = true,
                    Quantity = pizza.Quantity,
                    Ingredients = new List<Ingredient>()
                };
                foreach(var ingredient in pizza.Ingredients!)
                {
                    var ingEntity = _dbContext.Ingredients.First(i => i.Id == ingredient.Id);
                    pizzaToAdd.Ingredients.Add(ingEntity);
                }
                entityToInsert.Pizzas.Add(pizzaToAdd);
            }
        }

        if (order.Sides?.Any() ?? false)
        {
            foreach (var side in order.Sides)
            {
                var sideEntity = _dbContext.Sides.First(i => i.Id == side.Id);
                entityToInsert.Sides.Add(new Side
                {
                    Name = sideEntity.Name,
                    Description = sideEntity.Description,
                    Quantity = side.Quantity,
                    IsCustom = true
                });
            }
        }

        var entityEntry = await _dbContext.Orders.AddAsync(entityToInsert);
        await _dbContext.SaveChangesAsync();
        return entityEntry.Entity;
    }
}
