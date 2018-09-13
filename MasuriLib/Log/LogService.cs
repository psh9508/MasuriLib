using MasuriLib.Log.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasuriLib
{
    public class LogService
    {
        private readonly ILoggable _logger;

        #region ctor
        public LogService()
        {
            _logger = null;
        }

        public LogService(ILoggable logger)
        {
            _logger = logger;
        }
        #endregion

        #region public funcs
        public void WriteLog(string message, string prefix = null)
        {
            var logMsg = GetLogMessage(message, prefix);

            _logger.WriteLog(logMsg);
        }
        public void WriteErrorLog(string message, string prefix = null)
        {
            var logMsg = GetLogMessage(message, prefix);

            _logger.WriteErrorLog(logMsg);
        }
        #endregion

        #region private fucns
        private string GetLogMessage(string message, string prefix = null)
        {
            // [2018-09-12 PM 3:05:47] : Header : message;
            var msg = prefix == null ? $@"[{GetHeader()}]: {message}" : $@"[{GetHeader()}]:{prefix}: {message}";

            return msg;
        }

        private string GetHeader()
        {
            return DateTime.Now.ToString();
        }
        #endregion
    }
}
