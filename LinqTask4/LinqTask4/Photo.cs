using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace LinqTask4
{
    public class Photo
    {
        public int Width
        {
            get { return data.GetLength(0); }
        }

        public int Height
        {
            get { return data.GetLength(1); }
        }

        private Pixel[,] data;

        public Photo(int width, int height)
        {
            data = new Pixel[
                CheckSize(width, "ширина"),
                CheckSize(height, "высота")
                ];
        }

        public Pixel this[int x, int y]
        {
            get { return data[x, y]; }
            set { data[x, y] = value; }
        }



        private int CheckSize(int val, string name)
        {
            if (val <= 0)
                throw new Exception($"Неверная {name} {val}. Размер должен быть положительный");

            return val;
        }

        public List<Pixel> GetNeighbours(Point p)
        {
            var d = new[] { -1, 0, 1 };

            return d
                .SelectMany(dx => d.Select(dy => new Point(p.X + dx, p.Y + dy)))
                .Where(point => point.X >= 0 && point.X < Width
                                && point.Y >= 0 && point.Y < Height
                                && (point.X != p.X || point.Y != p.Y))
                .Select(point => data[point.X, point.Y])
                .ToList();
        }

    }
}
