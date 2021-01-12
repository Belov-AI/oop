using System;
using System.Timers;

namespace Devices

{
    public class Regulator
    {
        Oven oven;
        Timer timer;
        int minT, maxT, timeRemained;
        public Regulator(Oven oven)
        {
            this.oven = oven;
            timer = new Timer(500);
            timer.Stop();
            timer.Elapsed += Control;
        }

        public void Regulate(int minTemperature, int maxTemperature, int timeInSeconds)
        {
            minT = minTemperature;
            maxT = maxTemperature;
            timeRemained = timeInSeconds;
            timer.Start();
        }

        void Control(object obj, ElapsedEventArgs e)
        {
            if (oven.Temperature <= minT && !oven.IsEngaged)
                oven.Engage();
            else if(oven.Temperature >= maxT && oven.IsEngaged)
                oven.Disengage();
            timeRemained = (int)((timeRemained * 1000 - timer.Interval) / 1000);
            if(timeRemained <= 0)
            {
                timer.Stop();
                oven.Disengage();
                Console.WriteLine("Регулятор: время истекло");
            }
        }

    }
}
