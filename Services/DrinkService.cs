using TikiBar.Models;

namespace TikiBar.Services
{
    public class DrinkService
    {
        static List<Drink> Drinks { get; }
        static int nextId = 3;
        static DrinkService()
        {
            Drinks = new List<Drink>()
            {
                new Drink {Id = 1, Name = "Traditional Mai Tai", Ingredients = new List<string> { "rum", "orange curacao", "orgeat syrups", "lime juice" } },
                new Drink {Id = 2, Name = "Pina Colada", Ingredients = new List<string> { "rum", "coconut cream", "frozen pineapple chunks", "pineapple juice"} }
            };
        }

        public static List<Drink> GetAll() => Drinks;

        public static Drink? Get(int id) => Drinks.FirstOrDefault(d => d.Id == id);

        public static void Add(Drink drink)
        {
            drink.Id = nextId++;
            Drinks.Add(drink);
        }

        public static void Delete(int id)
        {
            var drink = Get(id);
            if (drink is null)
                return;

            Drinks.Remove(drink);

        }

        public static void Update(Drink drink)
        {
            var index = Drinks.FindIndex(d => d.Id == drink.Id);
            if (index == -1)
                return;

            Drinks[index] = drink;
        }
    }
}
