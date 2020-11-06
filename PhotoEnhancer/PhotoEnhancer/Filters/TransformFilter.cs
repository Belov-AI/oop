using System;
using System.Drawing;

namespace PhotoEnhancer
{
    public class TransformFilter : ParametrizedFilter<EmptyParameters>
    {
        string name;
        Func<Size, Size> sizeTranform;

        // по точке нового изображения и размеру старого изображения 
        // определяет какая точка старого изображения в нее перешла
        Func<Point, Size, Point> pointTransform;

        public TransformFilter(string name, Func<Size, Size> sizeTranform, 
            Func<Point, Size, Point> pointTransform)
        {
            this.name = name;
            this.sizeTranform = sizeTranform;
            this.pointTransform = pointTransform;
        }


        public override Photo Process(Photo original, EmptyParameters parameters)
        {
            var oldSize = new Size(original.Width, original.Height);
            var newSize = sizeTranform(oldSize);
            var result = new Photo(newSize.Width, newSize.Height);

            for(var x = 0; x < newSize.Width; x++)
                for(var y = 0; y < newSize.Height; y++)
                {
                    var oldPoint = pointTransform(new Point(x, y), oldSize);
                    result[x, y] = original[oldPoint.X, oldPoint.Y];
                }

            return result;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
