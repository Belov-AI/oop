using System;

namespace Devices
{
    public interface ISwitchableDevice
    {
        bool IsActive { get; }

        void TurnOn();

        void TurnOff();
    }
}
