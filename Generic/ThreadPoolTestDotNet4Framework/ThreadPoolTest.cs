using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadPoolTestDotNet4Framework
{
    public class ThreadPoolTest
    {
        public static void Start()
        {
            ////获得最小线程数
            //int minWorkerThread, minPortThread;
            //ThreadPool.GetMinThreads(out minWorkerThread, out minPortThread);
            //Console.WriteLine(minWorkerThread.ToString()+"  "+ minPortThread.ToString());

            ////获得最大线程数
            //int maxWorkerThread, maxPortThread;
            //ThreadPool.GetMaxThreads(out maxWorkerThread, out maxPortThread);
            //Console.WriteLine(maxWorkerThread.ToString() + "  " + maxPortThread.ToString());

            ////获得可以建立的线程数（即最大线程数和线程池中已经存在的线程数的差值）
            //int availableWorkerThread, availablePortThread;
            //ThreadPool.GetAvailableThreads(out availableWorkerThread, out availablePortThread);
            //Console.WriteLine(availableWorkerThread.ToString() + "  " + availablePortThread.ToString());

            // 在这里只设置工作线程
            //根据需要设置
            int appMinThreadCount =5;

            //获得最小线程数
            int minWorkerThread, minPortThread;
            ThreadPool.GetMinThreads(out minWorkerThread, out minPortThread);

            if (appMinThreadCount > minPortThread)
            {
                var result=ThreadPool.SetMinThreads(appMinThreadCount, minPortThread);
                //返回值用来判断是否设置成功
                Console.WriteLine(result);
            }
        }
    }
}
