using System.Drawing;

namespace StrategyPattern;

public class Navigator
{
    private IRouteStrategy _strategy;

    public Navigator(IRouteStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(IRouteStrategy strategy)
    {
        _strategy = strategy;
    }

    public void GetRoute(Point a, Point b)
    {
        Console.WriteLine($"Building route using {_strategy.ToString()} strategy");
        _strategy.BuildRoute(a, b);
        Console.WriteLine("The route is build successfully");
    }
}