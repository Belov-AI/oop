using System;

namespace Shapes
{
    public class Line : LinearObject
    {
        public Line(Point p1, Point p2) : base(p1, p2) { }       

        public override bool IsOn(Point p)
        {
            return Math.Abs(p.Y - K * p.X - B) < 1e-8;
        }
    }
}
