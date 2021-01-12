using System;
using System.Timers;

namespace Devices
{
    public class CofeeMaker
    {
        public int Temperature { get; private set; }
        Thermometer thermometer;
        readonly int power = 10; // мощность: увеличение температуры кофеварки (град./с)
        Timer heatTimer;
        Timer coolingTimer;
        public bool IsWorking;

        public bool IsCofeeReady;

        public CofeeMaker(Thermometer thermometr)
        {
            this.thermometer = thermometr;
            Temperature = thermometr.Measure();
            IsWorking = false;
            heatTimer = new Timer(1000);
            heatTimer.Stop();
            heatTimer.Elapsed += Heat;
            coolingTimer = new Timer(1000);
            coolingTimer.Stop();
            coolingTimer.Elapsed += CoolOut;
            IsCofeeReady = false;

        }

        public void MakeCofee()
        {
            IsCofeeReady = false;
            SwitchOn();
        }

        public void SwitchOn()
        {
            IsWorking = true;
            coolingTimer.Stop();
            heatTimer.Start();
        }

        public void SwitchOff()
        {

            if (IsCofeeReady)
            {
                IsWorking = false;
                heatTimer.Stop();
                coolingTimer.Start();
            }
        }

        void Heat(object obj, ElapsedEventArgs e)
        {

            Temperature += power;
            if (Temperature >= 100)
            {
                IsCofeeReady = true;
                SwitchOff();
                PrintInfo("Кофе готов: ");
            }
            else
                PrintInfo("Нагрев");
        }

        void CoolOut(object obj, ElapsedEventArgs e)
        {
            var t = thermometer.Measure();
            Temperature = t + (int)((Temperature - t) * 0.75);
            if (Temperature == t)
            {
                coolingTimer.Stop();
                PrintInfo("Кофеварка остыла до температуры окружающей среды");
            }
            else
                PrintInfo("Остывание");
        }

        void PrintInfo(string message)
        {
            Console.Write(message);
            Console.WriteLine($": температура кофеварки {Temperature}°");
        }
    }
}