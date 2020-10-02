using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class LighteningFilter : PixelFilter
    {
        public override ParametrInfo[] GetParametersInfo()
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

        public override string ToString()
        {
            return "Осветление/затемнение";
        }

        public override Pixel ProcessPixel(Pixel originalPixel, 
            double[] parameters)
        {
            return originalPixel * parameters[0];
        }

     
    }
}
