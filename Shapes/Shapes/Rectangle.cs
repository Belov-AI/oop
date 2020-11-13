using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : Shape
    {
        Point topLeft;
        double width;
        double height;

        public Rectangle(Point topLeft, double width, double height)
        {
            this.topLeft = topLeft;
            this.width = width;
            this.height = height;
        }

        public override void Draw()
        {
            //здесь рисуем прямоугольник
            throw new NotImplementedException();
        }
    }
}
