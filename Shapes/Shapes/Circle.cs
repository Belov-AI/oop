using System;
using System.Collections.Generic;


namespace Shapes
{
    public class Circle : Shape
    {
        public Point Center;

        double radius;
        public double Radius
        {
            get { return radius; }

            set
            {
                if (value < 0)
                    throw new Exception("Радиус не должен быть отрицательным");

                radius = value;
            }
        }

        public override double Area { get { return Math.PI * Radius * Radius; } }

        public Circle(Point center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        public override void Draw()
        {
            //здесь рисуем круг
            throw new NotImplementedException();
        }
    }
}
