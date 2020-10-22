using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    class RGB2HLS2RGBFilter : PixelFilter
    {
        public RGB2HLS2RGBFilter() : base(new EmptyParameters()) { }

        public override string ToString()
        {
            return "RGB -> HSL -> RGB";
        }

        public override Pixel ProcessPixel(Pixel originalPixel,
            IParameters parameters)
        {
            var origH = Convertors.GetPixelHue(originalPixel);
            var origS = Convertors.GetPixelSaturation(originalPixel);
            var origL = Convertors.GetPixelLightness(originalPixel);


            //var newH = origH < 180 ? origH + 180 : origH - 180;
            //return Convertors.HSL2Pixel(newH, origS, origL);

            return Convertors.HSL2Pixel(origH, origS, origL);
        }
    }
}
