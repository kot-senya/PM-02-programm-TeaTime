﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeaTime;
using teaTime;
using System;
using System.Net;
using Microsoft.Rest.ClientRuntime.Azure.Authentication.Utilities;

namespace teaTime
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTOREGISTRATION()
        {
            Worker worker = new Worker();
            Assert.IsTrue(Checks.checkWorker("even52", "1", out worker));
        }
    }
}
