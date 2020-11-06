using System;
using System.Drawing;

namespace PhotoEnhancer
{
    public class TransformFilter<TParameters> : ParametrizedFilter<TParameters>
        where TParameters : IParameters, new()
    {
        string name;
        Func<Size, TParameters, Size> sizeTranform;

        // по точке нового изображения и размеру старого изображения 
        // определяет какая точка старого изображения в нее перешла
        Func<Point, Size, TParameters, Point?> pointTransform;

        public TransformFilter(string name, Func<Size, TParameters, Size> sizeTranform, 
            Func<Point, Size, TParameters, Point?> pointTransform)
        {
            this.name = name;
            this.sizeTranform = sizeTranform;
            this.pointTransform = pointTransform;
        }


        public override Photo Process(Photo original, TParameters parameters)
        {
            var oldSize = new Size(original.Width, original.Height);
            var newSize = sizeTranform(oldSize, parameters);
            var result = new Photo(newSize.Width, newSize.Height);

            for(var x = 0; x < newSize.Width; x++)
                for(var y = 0; y < newSize.Height; y++)
                {
                    var oldPoint = pointTransform(new Point(x, y), oldSize, parameters);
                    if(oldPoint.HasValue)
                        result[x, y] = original[oldPoint.Value.X, oldPoint.Value.Y];
                }

            return result;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
