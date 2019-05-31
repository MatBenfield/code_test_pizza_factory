namespace PizzaFactoryLib.Pizza
{
    public class DeepPanPizza : IPizza
    {
        public DeepPanPizza(int baseCookingTime, string incomingTopping)
        {
            GetTopping = incomingTopping;
            BaseCookingTime = baseCookingTime;
        }

        public string GetPizzaName => "Deep Pan";
        public double BaseCookingTime { get; }
        public double GetMultiplier => 2;
        public string GetTopping { get; }
        public int ToppingCookingTime => GetTopping.Length * 100;
        public double TotalCookingTime => (int)(BaseCookingTime * GetMultiplier) + ToppingCookingTime;
    }
}