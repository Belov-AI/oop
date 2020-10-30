using System;
using System.Collections.Generic;


namespace Shapes
{
    public class Circle : Shape
    {
        Point center;
        double radius;
        
        public Circle(Point center, double radius)
        {
            this.center = center;
            this.radius = radius;
        }

        public override void Draw()
        {
            //здесь рисуем круг
            throw new NotImplementedException();
        }
    }
}
