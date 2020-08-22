using System;
using System.CodeDom;
using NUnit.Framework;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using PizzaFactoryConsole;
using PizzaFactoryLib;
using PizzaFactoryLib.Pizza;

namespace PizzaFactoryLibTests
{
    [TestFixture]
    class ProgramTests
    {
        [Test]
        public void GetRandomItemFromList_ReturnsItemFromList()
        {
            var pizzaList = new List<string> {"Stuffed Crust", "Deep Pan", "Thin and Crispy"};
            var item = Program.GetRandomItemFromList(pizzaList);
            Assert.IsTrue(pizzaList.Contains(item));
        }

        [TestCase("")]
        [TestCase(null)]
        public void GivenNoBase_GenerateNewPizzaThrowsException(string input)
        {
            var ex = Assert.Throws<NullReferenceException>(() => Program.GenerateNewPizza(input, "topping"));
            Assert.That(ex.Message, Is.EqualTo("Pizza base must exist"));
        }

        [TestCase("")]
        [TestCase(null)]
        public void GivenNoTopping_GenerateNewPizzaThrowsException(string input)
        {
            var ex = Assert.Throws<NullReferenceException>(() => Program.GenerateNewPizza("Deep Pan", input));
            Assert.That(ex.Message, Is.EqualTo("Pizza must have a topping"));
        }

        [Test]
        public void GivenPizzaAndTopping_GenerateNewPizzaReturnsCorrectTypeAndName()
        {
            const string name = "Deep Pan";
            var pizza = Program.GenerateNewPizza(name, "Topping");
            Assert.IsNotNull(pizza);
            Assert.AreEqual(pizza.GetType(), typeof(DeepPanPizza));
            Assert.AreEqual(pizza.GetPizzaName, name);

        }

        [Test]
        public void GivenStuffedCrust_GenerateNewPizzaReturnsCorrectTypeAndName()
        {
            const string name = "Stuffed Crust";
            var pizza = Program.GenerateNewPizza(name, "Topping");
            Assert.IsNotNull(pizza);
            Assert.AreEqual(pizza.GetType(), typeof(StuffedCrustPizza));
            Assert.AreEqual(pizza.GetPizzaName, name);

        }

        [Test]
        public void GivenThinAndCrispy_GenerateNewPizzaReturnsCorrectTypeAndName()
        {
            const string name = "Thin and Crispy";
            var pizza = Program.GenerateNewPizza(name, "Topping");
            Assert.IsNotNull(pizza);
            Assert.AreEqual(pizza.GetType(), typeof(ThinAndCrispyPizza));
            Assert.AreEqual(pizza.GetPizzaName, name);

        }

    }
}
