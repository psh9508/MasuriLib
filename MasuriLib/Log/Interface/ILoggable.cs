using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasuriLib.Log.Interface
{
    public interface ILoggable
    {
        void WriteLog(string message);
        void WriteErrorLog(string message);
    }
}
