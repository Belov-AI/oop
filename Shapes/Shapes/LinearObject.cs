using System;

namespace Shapes
{
    public abstract class LinearObject
    {
        public Point P1;
        public Point P2;

        public double K { get { return (P2.Y - P1.Y) / (P2.X - P1.X); } }

        public double B { get { return P1.Y - K * P1.X; } }

        public LinearObject(Point p1, Point p2)
        {
            if (p1.X == p2.X)
                throw new Exception("Недопустимые точки");

            P1 = p1;
            P2 = p2;
        }

        public abstract bool IsOn(Point p);
    }
}
