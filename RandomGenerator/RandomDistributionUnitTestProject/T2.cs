using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomGenerator;

namespace RandomDistributionUnitTestProject
{
    class T2
    {
        [NormalDistributed(-1, 2)]
        public double A { get; set; }

        public double B = 42;

        public double C { get; set; }

        [NormalDistributed]
        public double D { get; set; }
    }
}
