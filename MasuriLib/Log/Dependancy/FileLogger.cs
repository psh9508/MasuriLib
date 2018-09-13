using MasuriLib.Log.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MasuriLib.Log.Dependancy
{
    public class FileLogger : ILoggable
    {
        private const string PATH = @"C:\@Pharm\log\"; // CHANGE, WHRE YOU WANT TO SAVE LOG FILE.
        private string _fileName = string.Empty;

        public void WriteErrorLog(string message)
        {
            if (Validation())
                WriteLine($@"[ERROR] { message }");
        }

        public void WriteLog(string message)
        {
            if (Validation())
                WriteLine(message);
        }

        private void WriteLine(string message)
        {
            try
            {
                //if (_fileName == string.Empty)
                //    return;

                using (var writer = new System.IO.StreamWriter(PATH + _fileName, true, System.Text.Encoding.UTF8))
                {
                    if (message != "")
                    {
                        writer.WriteLine("\r\n" + message);
                    }
                }
            }
            catch
            {
            }
        }

        private bool Validation()
        {
            try
            {
                if (!HasLogFile())
                    CreateFile();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool HasLogFile()
        {
            if (_fileName == string.Empty)
                SetFileName();

            if (LogFileExist())
                return true;

            return false;
        }

        private bool LogFileExist()
        {
            if (File.Exists(PATH + _fileName))
                return true;

            return false;
        }

        private void CreateFile()
        {
            var file = File.Create(PATH + _fileName);
            file.Close();
        }

        private void SetFileName()
        {
            _fileName = DateTime.Today.ToShortDateString() + ".txt";
        }
    }
}
