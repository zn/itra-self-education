using System.Drawing;

namespace StrategyPattern;

public interface IRouteStrategy
{
    void BuildRoute(Point pointA, Point pointB);
}