using System;

namespace Devices
{
    public class ElectricMotor : ISwitchableDevice
    {
        public bool IsActive { get; private set; }
        public double RotationalSpeed { get; private set; }
        
        readonly double nominalSpeed;

        public ElectricMotor(double speed)
        {
            nominalSpeed = speed;
            IsActive = false;
            RotationalSpeed = 0;
        }

        public void TurnOn()
        {
            IsActive = true;
            RotationalSpeed = nominalSpeed;
        }

        public void TurnOff()
        {
            IsActive = false;
            RotationalSpeed = 0;
        }

        public void IncreaseRotationalSpeed(double delta)
        {
            if (IsActive && delta > 0)
                RotationalSpeed += delta;
        }

        public void DecreaseRotationalSpeed(double delta)
        {
            if (IsActive && delta > 0)
                RotationalSpeed -= delta;

            if(RotationalSpeed <= 0)
                RotationalSpeed = 0;           
        }


    }
}
