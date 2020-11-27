using System;
using TimeLib;

namespace Doors
{
    public interface IDoor
    {
        bool IsOpen { get; }
        void Lock();
        void Unlock();
    }
}
