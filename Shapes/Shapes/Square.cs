using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Square : Shape
    {
        Point topLeft;
        double side;

        public Square(Point topLeft, double side)
        {
            this.topLeft = topLeft;
            this.side = side;
        }

        public override void Draw()
        {
            //здесь рисуем квадрат
            throw new NotImplementedException();
        }
    }
}
