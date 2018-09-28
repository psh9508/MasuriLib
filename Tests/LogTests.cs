using MasuriLib;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests
{
    [TestFixture]
    public class LogTests
    {
        [Test]
        public void CanGetLogInstance()
        {
            LogService.WriteLog("meesage", "prefix");
        }
    }
}
