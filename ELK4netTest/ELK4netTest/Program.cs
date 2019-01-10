using ELK4netTest.Helper;
using log4net.Core;
using log4net.Repository.Hierarchy;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        

        private static int d(int x, int y)
        {
            return x + y;
        }

        private static int b(int x, int y)
        {
            return x - y;
        }
        class employee
        {
            private string m_date;
            private string m_name;
            private int m_score;
            public employee(string cdate, string name, int score)
            {
                m_date = cdate;
                m_name = name;
                m_score = score;
            }
            public override string ToString()
            {
                return m_date + "," + m_name;
            }
        }
        static void Main(string[] args)
        {
            List<employee> employees = new List<employee>
            {
                new employee("2012/1/18","龍龍一",100),
                new employee("2012/1/18","龍龍二",100),
                new employee("2012/1/18","龍龍三",100),
                new employee("2012/1/19","龍龍一",100),
                new employee("2012/1/19","龍龍二",100),
                new employee("2012/1/19","龍龍三",100),
                new employee("2012/1/18","龍龍三",100),
                new employee("2012/1/18","龍龍一",100),
            };
            var q =
from p in employees
group p by p.ToString() into g
where g.Count() > 1 //只顯示超過一次以上的
select new
{
    g.Key,
    count = g.Count()
};
            string stremp = "";
            foreach (var x in q)
            {
                stremp += x.ToString() + Environment.NewLine;
            }
            Console.WriteLine(stremp);

            using (StreamWriter sw  = new StreamWriter(@"d:\test.txt", false, new UTF8Encoding(false)))
            {
                sw.WriteLine("123");
            }


            Console.WriteLine("解法1");
            DateTime cdate = new DateTime(2012, 1, 5);
            for (int i = 1; i < 12; i++)
            {
                DateTime FirstDay = new DateTime(cdate.Year, cdate.Month, 1);//本月初1號
                DateTime LastDay = new DateTime(cdate.AddMonths(1).Year, cdate.AddMonths(1).Month, 1).AddDays(-1);//下月初1號減一天=本月底
                Console.WriteLine(FirstDay.ToString("yyyy/MM/dd"));
                Console.WriteLine(LastDay.ToString("yyyy/MM/dd"));
                cdate = cdate.AddMonths(1);//加一個月
            }
            Console.WriteLine("解法2");
            DateTime startdate = new DateTime(2012, 1, 5);
            for (int i = 1; i < 12; i++)
            {
                //本月初
                DateTime TheMonthStart = new DateTime(startdate.Year, startdate.Month, 1);//本月初1號
                Console.WriteLine(TheMonthStart.ToString("yyyy/MM/dd"));
                //本月底
                DateTime TheMonthEnd = new DateTime(startdate.Year, startdate.Month, DateTime.DaysInMonth(startdate.Year, startdate.Month));//本月初月底
                Console.WriteLine(TheMonthEnd.ToString("yyyy/MM/dd"));
                startdate = startdate.AddMonths(1);//加一個月
            }
            Console.Read();

            //foreach(var item in test_yield(9, 2))
            //{
            //    Console.WriteLine($"{item}");
            //}
            //Console.WriteLine();

            //SpyPrinterToner toner = null;
            //toner = new SpyPrinterToner();
            //toner.OnSendMessage += new Action<string>(new MessageController().SendMessage);
            //toner.CheckPrinterTonerIsLower();

            //var a = 0;
            //var str = "w";
            //myFunction test = (string i) => { i += "s";  Console.WriteLine(i); };
            //test(str);
            //Console.WriteLine(str);
            //Func<int, int, int> DoAdd = d;
            //DoAdd += b;
            //a = DoAdd(a, 2);
            //Console.WriteLine(a);
            //DoAdd doAdd = (int x, int y) =>
            //{
            //    return = x + y;
            //};
        }

        public static IEnumerable<int> test_yield(int max, int divide)
        {
            for(int currentNum = 1; currentNum<= max; currentNum ++)
            {
                if (currentNum % divide == 1) continue;
                yield return currentNum;
            }
        }

        public class SpyPrinterToner
        {
            public Action<string> OnSendMessage;

            public void CheckPrinterTonerIsLower()
            {
                PhysicalPrinterAction action = new PhysicalPrinterAction();
                int remainToner = action.SelectPrinterToner();
                if (remainToner < 50)
                {
                    if (this.OnSendMessage != null)
                    {
                        this.OnSendMessage("Printer Name");
                    }
                }
            }
        }

        public class MessageController
        {
            public void SendMessage(string printerName)
            {
                //TODO: SendMessage
            }
        }

        public class PhysicalPrinterAction
        {
            public int SelectPrinterToner()
            {
                return 40;
            }
        }
    }
}
