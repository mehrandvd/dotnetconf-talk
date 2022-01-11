using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLava
{
    public class SlowRestaurant
    {
        object GrabEgg() { return new object(); }
        void BreakEgg(object egg) { }
        object GrabOil() { return new object(); }
        void BoilOil(object oil) { }
        object CookEggOnOil(object oil, object egg) { return new object(); }
        object CookBread() { return new object(); }
        void GetBreadOutOfOven(object cheese) { }
        void OpenCheese(object cheese) { }
        object GrabCheese() { return new object(); }
        object PutCheeseOnBread(object bread, object cheese) { return new object(); }

        object PrepareBreadAndCheese()
        {
            var bread = CookBread();
            GetBreadOutOfOven(bread);

            var cheese = GrabCheese();
            OpenCheese(cheese);

            var food = PutCheeseOnBread(bread, cheese);

            return food;
        }

        object PrepareSunnySideUp()
        {
            var oil = GrabOil();
            BoilOil(oil);

            var egg = GrabEgg();
            BreakEgg(egg);

            var food = CookEggOnOil(oil, egg);

            return food;
        }

        void PrepareOrders()
        {
            var order1 = PrepareSunnySideUp();
            var order2 = PrepareSunnySideUp();
            var order3 = PrepareBreadAndCheese();

        }
    }
}
