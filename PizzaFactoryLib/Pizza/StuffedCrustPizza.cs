namespace PizzaFactoryLib.Pizza
{
    public class StuffedCrustPizza : IPizza
    {
        public StuffedCrustPizza(int baseCookingTime, string incomingTopping)
        {
            GetTopping = incomingTopping;
            BaseCookingTime = baseCookingTime;
        }

        public string GetPizzaName => "Stuffed Crust";
        public double BaseCookingTime { get; }
        public double GetMultiplier => 1.5;
        public string GetTopping { get; }
        public int ToppingCookingTime => GetTopping.Length * 100;
        public double TotalCookingTime => (BaseCookingTime * GetMultiplier) + ToppingCookingTime;
    
    }
}