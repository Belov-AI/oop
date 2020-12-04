using System;

namespace Devices
{
    public class Lamp : ISwitchableDevice
    {
        public bool IsActive { get; private set; }

        public void TurnOn()
        {
            IsActive = true;
        }

        public void TurnOff()
        {
            IsActive = false;
        }
    }
}
