using System.Drawing;

namespace StrategyPattern.Strategies;

public class PublicTransportStrategy : IRouteStrategy
{
    public void BuildRoute(Point pointA, Point pointB)
    {
        Console.WriteLine($"Building the Public transport route from {pointA.ToString()} to {pointB.ToString()}");
    }
}