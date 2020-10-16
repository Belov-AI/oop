using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copier
{
    public class Copier
    {
        private IReader reader;
        
        public Copier()
        {
            reader = new KeyboardReader();
        }

        public Copier(IReader r)
        {
            reader = r;
        }
        public void Copy()
        {
            char ch;

            while ((ch = reader.Read()) != '\n')
                Printer.Write(ch);               
        }
    }
}
