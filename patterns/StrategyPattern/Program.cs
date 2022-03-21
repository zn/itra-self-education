using System.Drawing;
using StrategyPattern.Strategies;

namespace StrategyPattern;

class Program
{
    public static void Main()
    {
        var pointA = new Point(1, 2);
        var pointB = new Point(1, 2);
        
        Navigator context = new Navigator(new RoadStrategy());
        context.GetRoute(pointA, pointB);
        
        context.SetStrategy(new WalkingStrategy());
        context.GetRoute(pointA, pointB);
        
        context.SetStrategy(new PublicTransportStrategy());
        context.GetRoute(pointA, pointB);
    }
}
