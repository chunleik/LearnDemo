using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.CtorTest
{
    public class CtorTest
    {
        public static void Start()
        {
            var apple = new Apple();
            apple.Dispose();
            apple = null;
            GC.Collect();
        }
    }

    public class Apple:IDisposable
    {
        public Apple()
        {
            Console.WriteLine("Ctor Apple");
        }

        ~Apple()
        {
            DisposeFin(false);
        }

        private void DisposeFin(bool dis)
        {
            if (dis)
            {
                GC.SuppressFinalize(this);
            }
            Console.WriteLine("~ Apple");
        }

        public void Dispose()
        {
            DisposeFin(true);
        }
    }
}
