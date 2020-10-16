using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copier
{
    public class DBReader : IReader
    {
        public char Read()
        {
            return Database.Read();
        }
    }
}
