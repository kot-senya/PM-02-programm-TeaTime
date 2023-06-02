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
        /// 
        public void TestREGISTRATIONmember()
        {
        //    Regestration page = new Regestration();
        //    page.aLogin.Text = "";
        //    Assert.IsTrue(Checks.check(page)); // юнит тест который при правильном заполнении полей для авторизации пользователя выведет результатом теста будет являться "true"
        //}
        //[TestMethod]
        //public void TestNOrEGISTRATIONmember()
        //{
        //    Regestration page = new Regestration();
        //    Assert.IsTrue(Checks.check("nihdsu78", "xopdytj", out me)); // юнит тест который при неправильных значениях в поле для авторизации пользователя выведет результатом теста которого будет являться "false"
        //}

    }













}
