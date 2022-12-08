using Pizza.Domain.Entities;
using Pizza.Domain.Enums;

namespace Pizza.Infrastructure.Persistence;

public class DataSeeder
{
    private readonly AppDbContext _dbContext;

    public DataSeeder(AppDbContext dbContext)
	{
        _dbContext = dbContext;
    }

    public void Seed()
    {
        _dbContext.Database.EnsureDeleted();
        _dbContext.Database.EnsureCreated();

        var ingredients = new List<Ingredient>
            {
                new Ingredient { Name = "Marinara", IngredientType = IngredientType.Sauce, Price = 50 },
                new Ingredient { Name = "Cheese", IngredientType = IngredientType.Sauce, Price = 50 },
                new Ingredient { Name = "Ranch", IngredientType = IngredientType.Sauce, Price = 50 },
                new Ingredient { Name = "Cheese", IngredientType = IngredientType.Cheese, Price = 50 },
                new Ingredient { Name = "Tomato", IngredientType = IngredientType.Topping, Price = 20 },
                new Ingredient { Name = "Onions", IngredientType = IngredientType.Topping, Price = 20 },
                new Ingredient { Name = "Corn", IngredientType = IngredientType.Topping, Price = 30 },
                new Ingredient { Name = "Mushrooms", IngredientType = IngredientType.Topping, Price = 40 },
                new Ingredient { Name = "Olives", IngredientType = IngredientType.Topping, Price = 30 },
                new Ingredient { Name = "Paneer", IngredientType = IngredientType.Topping, Price = 50 },
                new Ingredient { Name = "Chicken", IngredientType = IngredientType.Topping, Price = 60 },
            };

        var pizzas = new List<Domain.Entities.Pizza>
        {
            new Domain.Entities.Pizza { Name = "Margerita", Description = "Cheesy pizza with extra cheese", Ingredients = new List<Ingredient> { ingredients[1], ingredients[3] } },
            new Domain.Entities.Pizza { Name = "Onion and Corns", Description = "Pizza with onions and corn toppings", Ingredients = new List<Ingredient> { ingredients[0], ingredients[5], ingredients[6] } },
            new Domain.Entities.Pizza { Name = "Veg Loaded", Description = "Pizza with all vegetable toppings", Ingredients = new List<Ingredient> { ingredients[1], ingredients[4], ingredients[5], ingredients[6], ingredients[7], ingredients[8], ingredients[9] } },
            new Domain.Entities.Pizza { Name = "Non-veg Loaded", Description = "Cheesy pizza with extra cheese", Ingredients = new List<Ingredient> { ingredients[1], ingredients[4], ingredients[5], ingredients[6], ingredients[7], ingredients[8], ingredients[10] } },
        };

        var sides = new List<Side>
        {
            new Side { Name = "Garlic Bread", Description = "Plain garlic bread", Price = 120 },
            new Side { Name = "Stuffed Garlic Bread", Description = "Plain garlic bread", Price = 180 },
        };

        _dbContext.Ingredients.AddRange(ingredients);
        _dbContext.Pizzas.AddRange(pizzas);
        _dbContext.Sides.AddRange(sides);

        _dbContext.SaveChanges();
    }
}
