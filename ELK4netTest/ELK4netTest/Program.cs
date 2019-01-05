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
        delegate void myFunction(string text);
        static event myFunction readKeyEvent;

        static void Main(string[] args)
        {
            readKeyEvent += new myFunction(myFunction1);
            Console.WriteLine("請輸入一字串");
            string text = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("第一次觸發事件");
            readKeyEvent.Invoke(text);
            Console.WriteLine();
            
            readKeyEvent += new myFunction(myFunction2);
            Console.WriteLine("請輸入一字串");
            text = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("第二次觸發事件");
            readKeyEvent.Invoke(text);
            Console.WriteLine();


            readKeyEvent += new myFunction(myFunction2);
            Console.WriteLine("第二次觸發事件");
            readKeyEvent.Invoke(text);
            Console.WriteLine();

            Console.WriteLine("按任意鍵離開");
            Console.ReadKey();
        }

        static void myFunction1(string text)
        {
            Console.WriteLine("這次第一次執行的函數");
            Console.WriteLine("參數=" + text);
        }


        static void myFunction2(string text)
        {
            Console.WriteLine("這次第二次執行的函數");
            Console.WriteLine("參數=" + text);
        }
    }
}
