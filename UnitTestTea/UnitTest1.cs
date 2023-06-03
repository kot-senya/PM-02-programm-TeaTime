using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void TestAVTORIZEHONworker()
        {
            Worker worker = new Worker();
            Assert.IsTrue(Checks.checkWorker("even52", "1", out worker)); // юнит тест который при правильном заполнении полей для авторизации работника выведет результатом теста будет являться "true"

        }
        [TestMethod]
        public void TestNOaVTORIZEHONworker()
        {
            Worker worker = new Worker();
            Assert.IsTrue(Checks.checkWorker("uutgfk", "790", out worker)); // юнит тест который при неправильных значениях в поле для авторизации работника выведет результатом теста которого будет являться "false"
        }
        /// 
        [TestMethod]
        public void TestAVTORIZEHONmemder()
        {
            Member member = new Member();
            Assert.IsTrue(Checks.checkMember("minnnie73", "1", out member)); // юнит тест который при правильном заполнении полей для авторизации пользователя выведет результатом теста будет являться "true"
        }
        [TestMethod]
        public void TestNOaVTORIZEHONmember()
        {
            Member member = new Member();
            Assert.IsTrue(Checks.checkMember("nihdsu78", "xopdytj", out member)); // юнит тест который при неправильных значениях в поле для авторизации пользователя выведет результатом теста которого будет являться "false"
        }
        [TestMethod]
        public void TestTIMEDATAQ()
        {
            string nameMonth = "Январь";
            int numMonth = 1;
            Assert.AreEqual(nameMonth, timeData.giveMonthName(numMonth).Trim());
        }
        [TestMethod]
        public void TestNOtIMEDATAQ()
        {
            string nameMonth = "Июнь";
            int numMonth = 11;
            Assert.AreEqual(nameMonth, timeData.giveMonthName(numMonth).Trim());
        }
        [TestMethod]
        public void TestThereIsNoOneInAuthorizationWorker()
        {
            Worker worker = new Worker();
            Assert.IsTrue(Checks.checkWorker("", "", out worker));
        }
        [TestMethod]
        public void TestThereIsNoOneInAuthorizationMember()

        {
            Member member = new Member();
            Assert.IsTrue(Checks.checkMember("", "", out member));

        }
    }
}

