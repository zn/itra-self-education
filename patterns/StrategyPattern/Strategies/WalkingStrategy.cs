using System.Drawing;

namespace StrategyPattern.Strategies;

public class WalkingStrategy : IRouteStrategy
{
    public void BuildRoute(Point pointA, Point pointB)
    {
        Console.WriteLine($"Building the Walking route from {pointA.ToString()} to {pointB.ToString()}");
    }
}