using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomGenerator;

namespace RandomDistributionUnitTestProject
{
    class T1
    {
        [NormalDistributed(1, 2)]
        public double A { get; set; }
    }
}
