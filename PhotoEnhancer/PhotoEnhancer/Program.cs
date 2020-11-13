using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PhotoEnhancer
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new MainForm();

            mainForm.AddFilter(new PixelFilter<LighteningParameters>(
                "Осветление/затемнение",
                (pixel, parameters) => pixel * parameters.Coefficient
                ));

            mainForm.AddFilter(new PixelFilter<EmptyParameters>(
                "Оттенки серого",
                (pixel, parameters) =>
                {
                    var chanel = 0.3 * pixel.R +
                                0.6 * pixel.G +
                                0.1 * pixel.B;

                    return new Pixel(chanel, chanel, chanel);
                }
                ));

            //mainForm.AddFilter(new TransformFilter(
            //    "Отражение по горизонтали",
            //    size => size,
            //    (point, size) => new Point(size.Width - point.X - 1, point.Y)
            //    ));

            //mainForm.AddFilter(new TransformFilter(
            //    "Поворот на 90° против ч. с.",
            //    size => new Size(size.Height, size.Width),
            //    (point, size) => new Point(size.Width - point.Y - 1, point.X)
            //    ));

            Func<Size, RotationParameters, Size> sizeRotator = (size, parameters) =>
            {
                var angleInRadians = parameters.AngleInDegrees * Math.PI / 180;

                return new Size(
                    (int)(size.Width * Math.Abs(Math.Cos(angleInRadians)) +
                    size.Height * Math.Abs(Math.Sin(angleInRadians))),
                    (int)(size.Width * Math.Abs(Math.Sin(angleInRadians)) +
                    size.Height * Math.Abs(Math.Cos(angleInRadians))));
            };

            Func<Point, Size, RotationParameters, Point?> pointRotator = (point, size, parameters) =>
            {
                var newSize = sizeRotator(size, parameters);
                var angleInRadians = parameters.AngleInDegrees * Math.PI / 180;

                point = new Point(point.X - newSize.Width / 2, point.Y - newSize.Height / 2);

                var cos = Math.Cos(angleInRadians);
                var sin = Math.Sin(angleInRadians);

                var x = (int)(point.X * cos - point.Y * sin + size.Width / 2);
                var y = (int)(point.X * sin + point.Y * cos + size.Height / 2);

                if (x < 0 || x >= size.Width || y < 0 || y >= size.Height)
                    return null;

                return new Point(x, y);
            };

            mainForm.AddFilter(new TransformFilter<RotationParameters>(
                "Свободное вращение", sizeRotator, pointRotator));


            Application.Run(mainForm);
        }
    }
}
