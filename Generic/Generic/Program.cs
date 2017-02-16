using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            Test1();
            Console.ReadKey();
        }

        static void Test1()
        {
            Singleton<Apple>.Instance = new Apple() { Name = "1" };
            Singleton<Biscuit>.Instance = new Biscuit();
            Console.WriteLine(Singleton<Apple>.AllSingletons.Count);
        }
    }

    public class Apple
    {
        public string Name { get; set; }
    }

    public class Biscuit
    {

    }
}
