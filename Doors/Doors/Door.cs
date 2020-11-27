using System;

namespace Doors
{
    public class Door : IDoor
    {
        public bool IsOpen { get; private set; }

        public void Lock()
        {
            IsOpen = false;
        }

        public void Unlock()
        {
            IsOpen = true;
        }
    }
}
