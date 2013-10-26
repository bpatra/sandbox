using System;
using System.IO;
using System.Runtime.InteropServices;
using log4net;

namespace PowerMerger
{
    public static class Log
    {

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool AllocConsole();
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool FreeConsole();

        public static string FilePath
        {
            get { return _filePath; }
        }

        private static ILog _logger;

        //internal for testing...
        public static ILog Logger { set { _logger = value; } }

        private static string _filePath;
        private const string DefaultConversionPatern = "%date %-5level- %message%newline";

    
        public static void InitLog(string completeLogFile, bool externalConsole)
        {
            _filePath = completeLogFile;

            var hierarchy = (log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository();
            hierarchy.Root.RemoveAllAppenders();

            var pl = new log4net.Layout.PatternLayout { ConversionPattern = DefaultConversionPatern };
            pl.ActivateOptions();
            var fileAppender = new log4net.Appender.FileAppender
            {
                AppendToFile = true,
                LockingModel = new log4net.Appender.FileAppender.MinimalLock(),
                File = _filePath,
                Layout = pl
            };
            fileAppender.ActivateOptions();

            log4net.Config.BasicConfigurator.Configure(fileAppender);

            _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            if (externalConsole)
            {
                AddLogToConsole(false);
            }
                
        }

        public static void AddLogToConsole(bool basicConfig)
        {
            AllocConsole();
            var appender = new log4net.Appender.ConsoleAppender();
            var layout = new log4net.Layout.PatternLayout
            {
                ConversionPattern = DefaultConversionPatern,
                Header = "Time;Level;Description;"
            };
            layout.ActivateOptions();
            appender.Layout = layout;
            appender.ActivateOptions();
            if (basicConfig)
                log4net.Config.BasicConfigurator.Configure(appender);
            else
                ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root.AddAppender(appender);
        }

        public static void Exception(Exception ex)
        {
            _logger.Error(ex.ToString());
        }

        private static string PrepareMessage(string method, string message, params object[] arg)
        {
            message = "[" + method + "] " + message;
            if (arg.Length > 0)
            {
                message = String.Format(message, arg);
            }
            return message;
        }

        public static void Error(String method, String error, params object[] arg)
        {
            error = PrepareMessage(method, error, arg);
            _logger.Error(error);
        }

        public static void Trace( String traceMessage, params object[] arg)
        {
            //traceMessage = PrepareMessage("[TRACE]", traceMessage, arg);
            //_logger.Info(traceMessage);
        }

        public static void Debug(String method, String traceMessage, params object[] arg)
        {
            traceMessage = PrepareMessage(method, traceMessage, arg);
            _logger.Debug(traceMessage);
        }
    }

}
