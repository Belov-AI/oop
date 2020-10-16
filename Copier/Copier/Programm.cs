using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copier
{
    public class Programm
    {
        public static void Main()
        {
            var keyboardCopier = new Copier();
            keyboardCopier.Copy();

            var streamCopier = new Copier(new StreamReader());
            streamCopier.Copy();

            var dbCopier = new Copier(new DBReader());
            dbCopier.Copy();
        }
    }
}
