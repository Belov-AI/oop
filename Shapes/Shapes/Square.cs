using System;

namespace Shapes
{
    public class Square : Shape
    {
        public Point TopLeft;
        
        double side;
        public double Side
        {
            get { return side; }

            set
            {
                if (value < 0)
                    throw new Exception("Сторона не может быть отрицательной");

                side = value;
            }
        }

        public override double Area { get { return Side * Side; } }

        public Square(Point topLeft, double side)
        {
            this.TopLeft = topLeft;
            this.side = side;
        }

        public override void Draw()
        {
            //здесь рисуем квадрат
            throw new NotImplementedException();
        }
    }
}