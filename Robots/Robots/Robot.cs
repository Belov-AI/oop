using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public class Robot
    {
        private readonly object ai;
        private readonly object device;

        public Robot(object ai, object executor)
        {
            this.ai = ai;
            this.device = executor;
        }

        public IEnumerable<string> Start(int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                object command;
                if(ai is ShooterAI)
                    command = (ai as ShooterAI).GetCommand();
                else
                    command = (ai as BuilderAI).GetCommand();

                if (command == null)
                    break;

                if(device is Mover)
                    yield return (device as Mover).ExecuteCommand(command);
                else
                    yield return (device as ShooterMover).ExecuteCommand(command);

            }
        }

        public static Robot Create<TCommand>(object ai, object executor)
        {
            return new Robot(ai, executor);
        }
    }
}
