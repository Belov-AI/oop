using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public class ShooterCommand : IShooterMoveCommand
    {
        public Point Destination
        {
            get; set;
        }

        public bool Shoot { get; set; }
        public bool ShouldHide { get; set; }

        public static ShooterCommand ForCounter(int counter)
        {
            return new ShooterCommand
            {
                Destination = new Point { X = counter * 2, Y = counter * 3 },
                Shoot = counter % 5 == 0,
                ShouldHide = counter % 3 == 0
            };
        }
    }
}
