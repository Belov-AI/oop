using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : Shape
    {
        public Point TopLeft;

        double width;
        public double Width
        {
            get { return width; }

            set
            {
                if (value < 0)
                    throw new Exception("Ширина не должна быть отрицательной");

                width = value;
            }
        }

        double height;
        double Height
        {
            get { return height; }

            set
            {
                if (value < 0)
                    throw new Exception("Длина не должна быть отрицательной");

                height = value;
            }
        }

        public Rectangle(Point topLeft, double width, double height)
        {
            TopLeft = topLeft;
            Width = width;
            Height = height;
        }

        public override void Draw()
        {
            //здесь рисуем прямоугольник
            throw new NotImplementedException();
        }
    }
}
