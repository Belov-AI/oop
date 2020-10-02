using System;

namespace PhotoEnhancer
{
    public class GrayscaleFilter : IFilter
    {
        public ParametrInfo[] GetParametersInfo()
        {
            return new ParametrInfo[0];
        }

        public Photo Process(Photo original, double[] parametrs)
        {
            var newPhoto = new Photo(original.Width, original.Height);

            for (int x = 0; x < original.Width; x++)
                for (int y = 0; y < original.Height; y++)
                {
                    var chanel = 0.3 * original[x, y].R +
                        0.6 * original[x, y].G +
                        0.1 * original[x, y].B;

                    newPhoto[x, y] = new Pixel(chanel, chanel, chanel);
                }

            return newPhoto;
        }

        public override string ToString()
        {
            return "Оттенки серого";
        }
    }
}
