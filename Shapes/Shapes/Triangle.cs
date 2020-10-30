using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Triangle : Shape
    {
        Point a;
        Point b;
        Point c;

        public Triangle(Point a, Point b, Point c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public override void Draw()
        {
            //здесь рисуем треугольник
            throw new NotImplementedException();
        }
    }
}
