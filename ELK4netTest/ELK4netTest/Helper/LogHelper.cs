using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace ELK4netTest.Helper
{ 
    public enum LoggerLevel
    {
        Fatal,
        Error,
        Warning,
        Info,
        Debug
    }
    public class LogHelper
    {

        static LogHelper()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="ex"></param>
        #region static void WriteLog(Type t, Exception ex)

        public static void WriteLog(Type t, Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            log.Error("Error", ex);
        }

        #endregion

        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="msg"></param>
        #region static void WriteLog(Type t, string msg)

        public static void WriteLog(Type t, string msg)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            log.Error(msg);
        }

        #endregion

        public void Log(Type t, LoggerLevel level, params object[] messages)
        {
            ILog log = LogManager.GetLogger(t);
            string message = string.Empty;
            foreach (object m in messages) message += ((m == null) ? "" : m.ToString()) + " ";
            switch (level)
            {
                case LoggerLevel.Fatal: log.Fatal(message) ; break;
                case LoggerLevel.Warning: log.Warn(message); break;
                case LoggerLevel.Error: log.Error(message); break;
                case LoggerLevel.Info: log.Info(message); break;
                case LoggerLevel.Debug: log.Debug(message); break;
            }
        }



    }
}
