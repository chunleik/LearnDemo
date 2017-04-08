using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreadPoolTestDotNet4Framework
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPoolTest.Start();
            Console.ReadKey();
        }
    }
}
