namespace PizzaFactoryLib
{
    public interface IPizza
    {
        string GetPizzaName { get; }
        double GetMultiplier { get; }
        string GetTopping { get; }
        int ToppingCookingTime { get; }

        double TotalCookingTime { get; }

    }

}
