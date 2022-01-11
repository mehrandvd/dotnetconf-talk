using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLava
{
    public class FastRestaurant
    {
        Task<object> GrabEgg() { return Task.FromResult(new object()); }
        Task BreakEgg(object egg) { return Task.CompletedTask; }
        Task<object> GrabOil() { return Task.FromResult(new object()); }
        Task BoilOil(object oil) { return Task.CompletedTask; }
        Task<object> CookEggOnOil(object oil, object egg) { return Task.FromResult(new object()); }
        Task<object> CookBread() { return Task.FromResult(new object()); }
        Task GetBreadOutOfOven(object cheese) { return Task.CompletedTask; }
        Task OpenCheese(object cheese) { return Task.CompletedTask; }
        Task<object> GrabCheese() { return Task.FromResult(new object()); }
        Task<object> PutCheeseOnBread(object bread, object cheese) { return Task.FromResult(new object()); }

        Task PrepareBreadAndCheese()
        {
            return Task.WhenAll(
                CookBread()
                    .ContinueWith(t =>
                        {
                            GetBreadOutOfOven(t.Result);
                            return t.Result;
                        })
                ,
                GrabCheese()
                    .ContinueWith((t) =>
                    {
                        OpenCheese(t.Result);
                        return t.Result;
                    })
            ).ContinueWith(t =>
            {
                var bread = t.Result[0];
                var cheese = t.Result[1];
                return PutCheeseOnBread(bread, cheese);
            });
        }

        Task PrepareSunnySideUp()
        {
            return Task.WhenAll(
                GrabOil()
                    .ContinueWith(t =>
                    {
                        BoilOil(t.Result);
                        return t.Result;
                    })
                ,
                GrabEgg()
                    .ContinueWith((t) =>
                    {
                        BreakEgg(t.Result);
                        return t.Result;
                    })
            ).ContinueWith(t =>
            {
                var oil = t.Result[0];
                var egg = t.Result[1];
                return CookEggOnOil(oil, egg);
            });
        }

        Task PrepareOrders()
        {
            return Task.WhenAll
                (
                Task.WhenAll
                (
                    CookBread()
                        .ContinueWith(t =>
                        {
                            GetBreadOutOfOven(t.Result);
                            return t.Result;
                        })  
                        ,
                        GrabCheese()
                            .ContinueWith
                            (
                                (t) =>
                                {
                                    OpenCheese(t.Result);
                                    return t.Result;
                                }
                            )
                )   
                .ContinueWith(t =>
                {
                    var bread = t.Result[0];
                    var cheese = t.Result[1];
                    return PutCheeseOnBread(bread, cheese);
                }),
                Task.WhenAll(
                    CookBread()
                        .ContinueWith(t =>
                        {
                            GetBreadOutOfOven(t.Result);
                            return t.Result;
                        })
                    ,
                    GrabCheese()
                        .ContinueWith((t) =>
                        {
                            OpenCheese(t.Result);
                            return t.Result;
                        })
                ).ContinueWith(t =>
                {
                    var bread = t.Result[0];
                    var cheese = t.Result[1];
                    return PutCheeseOnBread(bread, cheese);
                }),
                Task.WhenAll(
                GrabOil()
                .ContinueWith(t =>
                {
                    BoilOil(t.Result);
                    return t.Result;
                })
                ,
                GrabEgg()
                    .ContinueWith((t) =>
                    {
                        BreakEgg(t.Result);
                        return t.Result;
                    })
            ).ContinueWith(t =>
            {
                var oil = t.Result[0];
                var egg = t.Result[1];
                return CookEggOnOil(oil, egg);
            })

            );
        }
    }
}
