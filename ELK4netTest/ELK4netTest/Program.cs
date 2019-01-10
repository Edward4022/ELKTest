using ELK4netTest.Helper;
using log4net.Core;
using log4net.Repository.Hierarchy;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Concurrent;
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
        
        public void a()
        {
            var p = new Person("aaa");
            p = null;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var emp = getEmpInfo();
            Console.WriteLine($"{emp.name}, {emp.age}");

            Console.ReadLine();
            Person s = new Person("");
            Console.WriteLine("Object Created ");
            Console.WriteLine("Press enter to Destroy it");
            Console.ReadLine();
            s = null;
            Person c = new Person("");
            Console.WriteLine("Object Created ");
            Console.WriteLine("Press enter to Destroy it");
            Console.ReadLine();
            c = null;
            //GC.Collect();  
            Console.Read();
        }

        public static (string name, int age) getEmpInfo()
        {
            return ("123", 26);
        }
    }



    class Person
    {
        private static ConcurrentDictionary<int, string> names = new ConcurrentDictionary<int, string>();
        private int id = 0;
        

        public Person(string name) => names.TryAdd(id, name); // constructors
        ~Person() => Console.Write("123");              // destructors
        public string Name
        {
            get => names[id];                                 // getters
            set => names[id] = value;                         // setters
        }
    }

    public class Box
    {
        public int Width { get; private set; }
        public int Hieght { get; private set; }
        public int Long { get; private set; }

        public Box(int w, int h, int l)
        {
            this.Width = w;
            this.Hieght = h;
            this.Long = l;
        }

        public void Deconstruct(out int w, out int h)
        {
            w = this.Width;
            h = this.Hieght;
        }

        public void Deconstruct(out int w, out int h,out int l)
        {
            w = this.Width;
            h = this.Hieght;
            l = this.Long;
        }
    }

    public class Employee
    {
        private string _id;  // 屬性背後的實際欄位（backing field）

        public string ID
        {
            get { return _id; }  // 屬性的讀取方法（getter）
            set { _id = value; } // 屬性的設定方法（setter）
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        } //= "另壺沖"  // 編譯錯誤! 只有自動屬性才允許初始設定式。
    }
}
