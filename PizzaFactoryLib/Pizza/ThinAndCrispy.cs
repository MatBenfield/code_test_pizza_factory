namespace PizzaFactoryLib.Pizza
{
    public class ThinAndCrispyPizza : IPizza
    {
        public ThinAndCrispyPizza(int baseCookingTime, string incomingTopping)
        {
            GetTopping = incomingTopping;
            BaseCookingTime = baseCookingTime;
        }

        public string GetPizzaName => "Thin and Crispy";
        public double BaseCookingTime { get; }
        public double GetMultiplier => 1;
        public string GetTopping { get; }
        public int ToppingCookingTime => GetTopping.Length * 100;
        public double TotalCookingTime => (int)(BaseCookingTime * GetMultiplier) + ToppingCookingTime;
    }
}