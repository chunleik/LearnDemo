using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Generic.Asyncawait
{
    public class AsyncAwaitTest
    {
        internal sealed class Type1 { }

        internal sealed class Type2 { }

        private static async Task<Type1> Method1Async()
        {
            Type1 t = null;
            await Task.Run(new Action(() =>
            {
                t = new Type1();
                Thread.Sleep(1000);
            }));
            return t;
        }

        private static async Task<Type2> Method2Async()
        {
            Type2 t = null;
            await Task.Run(new Action(() =>
            {
                t = new Type2();
                Thread.Sleep(1000);
            }));
            return t;
        }

        public static async Task<string> MyMethodAsync(int argument)
        {
            int local = argument;
            try
            {
                Type1 result1 = await Method1Async();
                for(int x = 0; x < 3; x++)
                {
                    Type2 result2 = await Method2Async();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Catch");
            }
            finally
            {
                Console.WriteLine("Finally");
            }
            return "Done";
        }
    }
}
