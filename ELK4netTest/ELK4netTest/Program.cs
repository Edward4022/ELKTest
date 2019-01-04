using ELK4netTest.Helper;
using log4net.Core;
using log4net.Repository.Hierarchy;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ELK4netTest
{
    public class Test : LogHelper
    { 
        public static void T()
        {
            String strHostName = string.Empty;
            strHostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(Test));
            log.Error("11111111111111111111111111111111111111111");
            LogHelper l = new LogHelper();
            l.Log(typeof(Test), LoggerLevel.Fatal, "ip", addr.Last().ToString(), "11111111111111111111111111111111111111111");
        }
    }
    public class Program
    {
        bool done;
        static void Main(string[] args)
        {
            var a = new List<int>();
            //a.GetRange(1, 3).Add(1);

            var i = 0;
            while(i == 0)
            {
                //i = 1;
                LogHelper.WriteLog(typeof(string), "测试Log4Net日志是否写入");
                Test.T();
            }
            //for (int x = 1; x < 5; x++)
            //{
            //    Thread back = new Thread(Go);      // 在新线程执行Go()
            //    back.Start(x);                   // 在主线程执行Go()
            //}
            //ParallelLoopResult result = Parallel.For(0, 100, i => {
            //    Console.WriteLine("{0}, task: {1} , thread: {2}", i, Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
            //});

            //Console.WriteLine("主线程ID：" + Thread.CurrentThread.ManagedThreadId);
            //Task<string> task = Task.Run(() =>
            //{
            //    return Thread.CurrentThread.ManagedThreadId.ToString();
            //});
            //Console.WriteLine("创建Task对应的线程ID：" + task.Result);
            //Console.ReadLine();

            ////主线程调用AsyncCaller方法，被async标记的方法将会在合适的时候异步执行
            //var task = AsyncCaller();
            ////主线程调用task.Result等待异步执行结果
            //Console.WriteLine(task.Result);       //3
            //Console.ReadKey();

            //Console.WriteLine("主线程ID：" + Thread.CurrentThread.ManagedThreadId);
            //Task.Run(() => Console.WriteLine("Task对应线程ID：" + Thread.CurrentThread.ManagedThreadId));
            //Console.ReadLine();
            //Console.WriteLine("主线程启动，当前线程为：" + Thread.CurrentThread.ManagedThreadId);
            //var task = GetLengthAsync();

            //Console.WriteLine("回到主线程，当前线程为：" + Thread.CurrentThread.ManagedThreadId);

            //Console.WriteLine("线程[" + Thread.CurrentThread.ManagedThreadId + "]睡眠5s:");
            //Thread.Sleep(5000); //将主线程睡眠5s

            //var timer = new Stopwatch();
            //timer.Start(); //开始计算时间

            //Console.WriteLine("task的返回值是" + task.Result);

            //timer.Stop(); //结束点，另外stopwatch还有Reset方法，可以重置。
            //Console.WriteLine("等待了：" + timer.Elapsed.TotalSeconds + "秒"); //显示时间

            //Console.WriteLine("主线程结束，当前线程为：" + Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
        }

        private static async Task<int> GetLengthAsync()
        {
            Console.WriteLine("GetLengthAsync()开始执行，当前线程为：" + Thread.CurrentThread.ManagedThreadId);

            var str = await GetStringAsync();

            Console.WriteLine("GetLengthAsync()执行完毕，当前线程为：" + Thread.CurrentThread.ManagedThreadId);

            return str.Length;
        }

        private static Task<string> GetStringAsync()
        {
            Console.WriteLine("GetStringAsync()开始执行，当前线程为：" + Thread.CurrentThread.ManagedThreadId);
            return Task.Run(() =>
            {
                Console.WriteLine("异步任务开始执行，当前线程为：" + Thread.CurrentThread.ManagedThreadId);

                Console.WriteLine("线程[" + Thread.CurrentThread.ManagedThreadId + "]睡眠10s:");
                Thread.Sleep(10000); //将异步任务线程睡眠10s

                Console.WriteLine("GetStringAsync()执行完毕，当前线程为：" + Thread.CurrentThread.ManagedThreadId);
                return "GetStringAsync()执行完毕";
            });
        }

        private static void Task1()
        {
            Thread.Sleep(3000);//模拟耗时操作，睡眠1s
            Console.WriteLine("前台线程被调用！");
        }

        private static void Task2(object data)
        {
            Thread.Sleep(2000);//模拟耗时操作，睡眠2s
            Console.WriteLine("后台线程被调用！" + data);
        }
        
        private static async Task<string> AsyncCaller()
        {
            //await标记了一个等待点
            var str = await AsyncFunction();      //2
            return str;
        }
        private static Task<string> AsyncFunction()
        {
            //下面就是将要被异步执行的任务，主线程到这里就会返回
            return Task.Run(() =>           //1
            {
                return "AsyncFunction()执行完毕";
            });
        }

        static void Go(object obj)
        {
            // 定义和使用局部变量 - 'cycles'
            for (int cycles = 0; cycles < 1000; cycles++)
            {
                Console.Write(obj + Thread.CurrentThread.ManagedThreadId.ToString() + "     ");
            }
        }
    }
    public class ThreadDemoClass
    {
        public void Run(object obj)
        {
            Console.WriteLine("Child thread working...");
            Console.WriteLine("Child thread ID is:" + Thread.CurrentThread.ManagedThreadId.ToString());
        }
    }
}
