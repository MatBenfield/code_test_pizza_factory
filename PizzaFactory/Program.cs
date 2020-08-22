using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using log4net;
using PizzaFactoryLib;
using static System.Console;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace PizzaFactoryConsole
{

    public class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            WriteLine("Pizza Factory");

            var numberOfPizzas = Config.NumberOfPizzas;
            var pizzaList = Config.PizzaList;
            var toppingList = Config.ToppingList;

            var i = 1;
            string last = null; // set default starting topping.
            while (i <= numberOfPizzas)
            {

                var randomPizza = GetRandomItemFromList(pizzaList);
                var randomTopping = GetRandomItemFromList(toppingList);
                var pizza = GenerateNewPizza(randomPizza, randomTopping);
                if (pizza.GetTopping == last) continue;
                GenerateItemInformation(i, pizza);
                last = pizza.GetTopping;
                i++;

            }

            WriteLine("order complete");
        }

        public static IPizza GenerateNewPizza(string randomPizza, string randomTopping)
        {
            if (string.IsNullOrEmpty(randomPizza))
            {
                throw new NullReferenceException("Pizza base must exist");
            }

            if (string.IsNullOrEmpty(randomTopping))
            {
                throw new NullReferenceException("Pizza must have a topping");
            }

            var ngp = new PizzaFactory();
            return ngp.GetPizzaFactory(randomPizza,randomTopping, Config.BaseTime);
        }

        public static string GetRandomItemFromList(List<string> workingList)
        {
            var random = new Random();
            return workingList.ElementAt(random.Next(workingList.Count));
        }

        private static void GenerateItemInformation(int counter, IPizza pizza)
        {
            var startItem = $"Pizza {counter}: {pizza.GetPizzaName} with {pizza.GetTopping} with {pizza.TotalCookingTime}ms cooking time!";
            WritePizzaLog(startItem, pizza.TotalCookingTime);
        }

        private static void WritePizzaLog(string startItem, double waitingTime)
        {
            WriteLine("---");
            WriteLine(startItem);
            Log.Info(startItem);
            Thread.Sleep((int)waitingTime);
            Log.Info($"Waiting {Config.Interval} before next pizza");
            Thread.Sleep(Config.Interval);
        }


    }

}
