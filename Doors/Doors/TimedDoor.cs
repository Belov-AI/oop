using System;
using TimeLib;

namespace Doors
{
    public class TimedDoor : IDoor, ITimerClient
    {
        Timer timer;
        int timeout;
        int requestID;
        public bool IsOpen { get; private set; }

        public TimedDoor(int timeoutInSeconds)
        {
            timer = new Timer();
            timeout = timeoutInSeconds;
            requestID = 0;
        }

        public void Lock()
        {
            IsOpen = false;
        }

        public void Unlock()
        {
            IsOpen = true;
            timer.Register(timeout, this, ++requestID);
        }

        public void TimeOut(int id)
        {
            if(id == requestID)
               Lock();
        }
    }
}
