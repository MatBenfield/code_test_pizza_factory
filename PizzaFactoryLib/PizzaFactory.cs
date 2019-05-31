using System;
using System.Collections.Generic;
using System.Linq;
using PizzaFactoryLib.Pizza;

namespace PizzaFactoryLib
{
    public class PizzaFactory
    {
        public IPizza GetPizzaFactory(string name, string topping, int baseCookingTime)
        {
            if (string.IsNullOrEmpty(topping))
            {
                throw new NullReferenceException("Pizza must have a topping");
            }

            var factory = new Dictionary<string, IPizza>
            {
                {"Stuffed Crust", new StuffedCrustPizza(baseCookingTime, topping)},
                {"Deep Pan", new DeepPanPizza(baseCookingTime, topping)},
                {"Thin and Crispy", new ThinAndCrispyPizza(baseCookingTime, topping)}
            };

            return factory.FirstOrDefault(n => n.Key == name).Value ?? throw new NullReferenceException("Pizza base must exist");
        }
    }
}