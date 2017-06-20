using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewFunction
{
    public class TaskTest
    {
        public void Start()
        {
            Console.WriteLine("-----主线程启动------");
            Task<int> task = GetStrLengthAsync();
            Console.WriteLine("主线程继续执行");
            Console.WriteLine("Task返回的值" + task.Result);
            Console.WriteLine("-----主线程结束------");
        }

        static async Task<int> GetStrLengthAsync()
        {
            Console.WriteLine("GetStrLengthAsync方法开始执行");
            string str = await GetString();
            Console.WriteLine("GetStrLengthAsync方法执行结束");
            return str.Length;
        }

        static Task<string> GetString()
        {
            return Task<string>.Run(() =>
            {
                Thread.Sleep(2000);
                return "GetString的返回值";
            });

        }
    }
}
