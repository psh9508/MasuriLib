using MasuriLib.Log.Dependancy;
using MasuriLib.Log.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasuriLib
{
    public static class LogService
    {
        private static readonly ILoggable _logger;

        #region ctor
        //public LogService()
        //{
        //    _logger = null;
        //}

        //public LogService(ILoggable logger)
        //{
        //    _logger = logger;
        //}
        static LogService()
        {
            _logger = new FileLogger();
        }
        #endregion

        #region public funcs
        public static void WriteLog(string message, string prefix = null)
        {
            var logMsg = GetLogMessage(message, prefix);

            _logger.WriteLog(logMsg);
        }

        public static void WriteErrorLog(string message, string prefix = null)
        {
            var logMsg = GetLogMessage(message, prefix);

            _logger.WriteErrorLog(logMsg);
        }
        #endregion

        #region private fucns
        private static string GetLogMessage(string message, string prefix = null)
        {
            // [2018-09-12 PM 3:05:47] :prefix: message;
            // [2018-09-12 PM 3:05:47] message;
            var msg = prefix == null || prefix == string.Empty 
                ? $@"[{GetHeader()}]: {message}" 
                : $@"[{GetHeader()}]:{prefix}: {message}";

            return msg;
        }

        private static string GetHeader()
        {
            return DateTime.Now.ToString();
        }
        #endregion
    }
}
