using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class Computation
    {
        private long number { get; set; }
        private long threads { get; set; }

        private long result { get; set; }
        private double time { get; set; }
    }
}
