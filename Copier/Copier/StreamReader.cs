using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copier
{
    class StreamReader : IReader
    {
        public char Read()
        {
            return Streamer.Read();
        }
    }
}
