using System;

namespace Devices
{
    public class Button
    {
        ISwitchableDevice device;

        public Button(ISwitchableDevice device)
        {
            this.device = device;
        }

        public void Press()
        {
            if (device.IsActive)
                device.TurnOff();
            else
                device.TurnOn();
        }
    }
}
