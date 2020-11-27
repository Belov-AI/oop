using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLib
{
    public interface ITimerClient
    {
        void TimeOut(int requestID);
    }
}
