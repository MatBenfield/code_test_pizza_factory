using System;
using NUnit.Framework;
using PizzaFactoryConsole;

namespace PizzaFactoryLibTests
{
    [TestFixture]
    public class LibraryTests   
    {
        [TestCase("")]
        [TestCase(null)]
        public void GivenBaseNotFoundInFactory_PizzaThrowsException(string input)
        {
            var factory = new PizzaFactoryLib.PizzaFactory();
            var ex = Assert.Throws<NullReferenceException>(() => factory.GetPizzaFactory(input, "topping", 0));
            Assert.That(ex.Message, Is.EqualTo("Pizza base must exist"));
        }

        [TestCase("")]
        [TestCase(null)]
        public void GivenNoToppings_PizzaThrowsException(string input)
        {
            var factory = new PizzaFactoryLib.PizzaFactory();
            var ex = Assert.Throws<NullReferenceException>(() => factory.GetPizzaFactory("Stuffed Crust", input, 0));
            Assert.That(ex.Message, Is.EqualTo("Pizza must have a topping"));
        }

        [TestCase("Deep Pan", 2)]
        [TestCase("Stuffed Crust", 1.5)]
        [TestCase("Thin and Crispy", 1)]
        public void GivenPizza_TotalCookingTimeIsCalculatedCorrectly(string pizzaName, double multiplier)
        {
            const string topping = "topping";
            var factory = new PizzaFactoryLib.PizzaFactory();
            int baseCookingTime = Config.BaseTime;
            var f = factory.GetPizzaFactory(pizzaName, topping, baseCookingTime);
            var toppingLength = "topping".Length * 100;
            Assert.AreEqual((baseCookingTime * multiplier) + toppingLength, f.TotalCookingTime);

        }

        [TestCase("Banana")]
        [TestCase("Kiwi")]
        [TestCase("Double Pineapple")]
        [TestCase("Cheese and Tomato")]
        public void GivenPizza_ToppingCookTimeIsCalculatedCorrectly(string toppingsLength)
        {
            var factory = new PizzaFactoryLib.PizzaFactory();
            var f = factory.GetPizzaFactory("Stuffed Crust", toppingsLength, 1);
            Assert.AreEqual(toppingsLength.Length * 100, f.ToppingCookingTime);
        }

        [Test]
        public void GivenPizza_GetToppingReturnsToppingCorrectly()
        {
            var factory = new PizzaFactoryLib.PizzaFactory();
            var f = factory.GetPizzaFactory("Stuffed Crust", "topping", 0);
            Assert.IsNotNull(f.GetTopping);
            Assert.AreEqual("topping", f.GetTopping);
        }


        [TestCase("Deep Pan", 2)]
        [TestCase("Stuffed Crust", 1.5)]
        [TestCase("Thin and Crispy", 1)]
        public void GivenPizza_MultiplierIsSetCorrectly(string pizza, double multiplier)
        {
            var factory = new PizzaFactoryLib.PizzaFactory();
            var f = factory.GetPizzaFactory(pizza, "topping", Config.BaseTime);
            Assert.IsNotNull(f.GetMultiplier);
            Assert.AreEqual(multiplier, f.GetMultiplier);
        }

        [TestCase("Deep Pan", 2)]
        [TestCase("Stuffed Crust", 1.5)]
        [TestCase("Thin and Crispy", 1)]
        public void GivenPizza_NameIsSetCorrectly(string pizza, double multiplier)
        {
            var factory = new PizzaFactoryLib.PizzaFactory();
            var f = factory.GetPizzaFactory(pizza, "topping", Config.BaseTime);
            Assert.IsNotNull(f.GetPizzaName);
            Assert.AreEqual(pizza, f.GetPizzaName);
        }
    }
}