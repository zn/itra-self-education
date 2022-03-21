using System.Drawing;

namespace StrategyPattern.Strategies;

public class RoadStrategy : IRouteStrategy
{
    public void BuildRoute(Point pointA, Point pointB)
    {
        Console.WriteLine($"Building the Road route from {pointA.ToString()} to {pointB.ToString()}");
    }
}