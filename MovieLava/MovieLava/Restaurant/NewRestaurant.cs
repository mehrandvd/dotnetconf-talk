using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLava
{
    public class NewRestaurant
    {
        Task<object> GrabEgg() => Task.FromResult(new object());
        Task BreakEgg(object egg) => Task.CompletedTask;
        Task<object> GrabOil() => Task.FromResult(new object());
        Task BoilOil(object oil) => Task.CompletedTask;
        Task<object> CookEggOnOil(object oil, object egg) => Task.FromResult(new object());
        Task<object> BakeSunnySideUp(object oil, object egg) => Task.FromResult(new object());
        Task<object> BakeEgg(object water, object egg) => Task.FromResult(new object());
        Task<object> CookBread() => Task.FromResult(new object());
        Task GetBreadOutOfOven(object cheese) => Task.CompletedTask;
        Task OpenCheese(object cheese) => Task.CompletedTask;
        Task<object> GrabCheese() => Task.FromResult(new object());
        Task<object> PutCheeseOnBread(object bread, object cheese) => Task.FromResult(new object());


        async Task<object> PrepareBreadAndCheese()
        {
            var bread = await CookBread();
            await GetBreadOutOfOven(bread);

            var cheese = await GrabCheese();
            await OpenCheese(cheese);

            var food = await PutCheeseOnBread(bread, cheese);

            return food;
        }

        async Task<object> PrepareSunnySideUp()
        {
            var oil = await GrabOil();
            await BoilOil(oil);

            var egg = await GrabEgg();
            await BreakEgg(egg);

            var food = CookEggOnOil(oil, egg);

            return food;
        }

        async Task PrepareOrders()
        {
            await Task.WhenAll(
                PrepareSunnySideUp(),
                PrepareSunnySideUp(),
                PrepareBreadAndCheese()
                );
        }
    }
}
