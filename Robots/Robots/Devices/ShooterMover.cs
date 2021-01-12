using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public class ShooterMover
    {
        public string ExecuteCommand(object order)
        {
            var command = order as IShooterMoveCommand;
            if (command == null)
                throw new ArgumentException();
            var hide = command.ShouldHide ? "YES" : "NO";
            var shoot = command.Shoot ? "YES" : "NO";
            return $"MOV {command.Destination.X}, {command.Destination.Y}, FIRE {shoot}, USE COVER {hide}";
        }
    }
}
