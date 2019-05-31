using System.Collections.Generic;
using System.Configuration;

namespace PizzaFactoryConsole
{
    public static class Config
    {

        public static int BaseTime => int.Parse(ConfigurationManager.AppSettings["BaseTime"]);

        public static int NumberOfPizzas => int.Parse(ConfigurationManager.AppSettings["NumberOfPizzas"]);

        public static int Interval => int.Parse(ConfigurationManager.AppSettings["WaitIntervalTime"]);

        public static List<string> PizzaList = new List<string> { "Stuffed Crust", "Deep Pan", "Thin and Crispy" };

        public static List<string> ToppingList = new List<string> { "Ham and Mushroom", "Pepperoni", "Vegetable" };


    }
}