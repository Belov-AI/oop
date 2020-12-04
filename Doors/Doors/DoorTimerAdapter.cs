using System;
using TimeLib;

namespace Doors
{
    public class DoorTimerAdapter : ITimerClient
    {
        TimedDoor timedDoor;

        public DoorTimerAdapter(TimedDoor door)
        {
            timedDoor = door;
        }

        public void TimeOut(int requestID)
        {
            timedDoor.DoorTimeOut(requestID);
        }
    }
}
