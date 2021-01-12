using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public class BuilderCommand : IMoveCommand
    {
        public Point Destination { get; set; }
        public bool Build { get; set; }

        public static BuilderCommand ForCounter(int counter)
        {
            return new BuilderCommand
            {
                Destination = new Point { X = counter, Y = counter },
                Build = counter % 10 == 0
            };
        }
    }
}
