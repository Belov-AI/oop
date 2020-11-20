using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Triangle : Shape
    {
        public Point A;
        public Point B;
        public Point C;

        public Triangle(Point a, Point b, Point c)
        {
            A = a;
            B = b;
            C = c;
        }

        public override double Area 
        { 
            get { return Math.Abs((B.X - A.X) * (C.Y - A.Y) - (B.Y - A.Y) * (C.X - A.X)) / 2; } 
        }

        public override void Draw()
        {
            //здесь рисуем треугольник
            throw new NotImplementedException();
        }
    }
}
