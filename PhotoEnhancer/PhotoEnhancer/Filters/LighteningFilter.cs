using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class LighteningFilter : IFilter
    {
        public ParametrInfo[] GetParametersInfo()
        {
            return new[]
            {
                new ParametrInfo() {
                    Name = "Коэффициент",
                    MinValue = 0,
                    MaxValue = 10,
                    DefailtValue = 1,
                    Increment = 0.05
                    }
            };
        }

        public Photo Process(Photo original, double[] parametrs)
        {
            var newPhoto = new Photo(original.Width, original.Height);

            for (int x = 0; x < original.Width; x++)
                for (int y = 0; y < original.Height; y++)
                    newPhoto[x, y] = original[x, y] * parametrs[0];

            return newPhoto;
        }

        public override string ToString()
        {
            return "Осветление/затемнение";
        }
    }
}
