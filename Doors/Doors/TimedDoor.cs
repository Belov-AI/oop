using System;
using TimeLib;

namespace Doors
{
    public class TimedDoor : IDoor
    {
        Timer timer;
        int timeout;
        int requestID;
        DoorTimerAdapter adapter;

        public bool IsOpen { get; private set; }

        public TimedDoor(int timeoutInSeconds)
        {
            timer = new Timer();
            timeout = timeoutInSeconds;
            requestID = 0;
            adapter = new DoorTimerAdapter(this);
        }

        public void Lock()
        {
            IsOpen = false;
        }

        public void Unlock()
        {
            IsOpen = true;

            adapter = new DoorTimerAdapter(this);
            timer.Register(timeout, adapter, ++requestID);
        }

        public void DoorTimeOut(int id)
        {
            if(id == requestID)
               Lock();
        }
    }
}
