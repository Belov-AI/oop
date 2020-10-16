using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copier
{
    public class KeyboardReader : IReader
    {
        public char Read()
        {
            return Keyboard.Read();
        }
    }
}
