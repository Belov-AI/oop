using System;

namespace Shapes
{
    public class LineSegment : LinearObject
    {
        public double Length
        {
            get
            {
                var deltaX = P2.X - P1.X;
                var deltaY = P2.Y - P1.Y;
                return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            }
        }
        public LineSegment(Point p1, Point p2) : base(p1, p2) { }

        public override bool IsOn(Point p)
        {
            return Math.Abs((p.X - P1.X) * (P2.Y - p.Y) - (p.Y - P1.Y) * (P2.X - p.X)) < 1e-8
                && (p.X - P1.X) * (P2.X - p.X) + (p.Y - P1.Y) * (P2.Y - p.Y) > -1e-8;
        }


    }
}
