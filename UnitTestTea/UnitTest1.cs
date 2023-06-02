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
            Assert.IsTrue(Checks.checkWorker("even52", "1", out worker)); // юнит тест который при правильном заполнении полей для авторизации работника выведет результатом теста будет являться true

        }
        [TestMethod]
        public void TestNOaVTORIZEHONworker()
        {
            Worker worker = new Worker();
            Assert.IsFalse(Checks.checkWorker("uutgfk", "790", out worker)); // юнит тест который при неправильных значениях в поле для авторизации работника результатом теста которого будет являться false
        }
        /// 
        [TestMethod]
        public void TestAVTORIZEHONmemder()
        {
            Member member = new Member();
            Assert.IsTrue(Checks.checkMember("minnnie73", "1", out member)); // юнит тест который при правильном заполнении полей для авторизации пользователя результатом теста будет являться true
        }
        [TestMethod]
        public void TestNOaVTORIZEHONmember()
        {
            Member member = new Member();
            Assert.IsFalse(Checks.checkMember("nihdsu78", "xopdytj", out member)); // юнит тест который при неправильных значениях в поле для авторизации пользователя результатом теста которого будет являться false
        }
        /// 
        [TestMethod]
        public void TestTIMEDATA()
        {
            string nameMonth = "Январь";
            int numMonth =1;
;            Assert.AreEqual(nameMonth, timeData.giveMonthName(numMonth).Trim()); // юнит тест который проверяет значение (названия месяца и его номер) на равенство и считается выполненным если они равны
        }
        [TestMethod]
        public void TestNOtIMEDATA()
        {
            string nameMonth = "Июнь";
            int numMonth = 11;
            ; Assert.AreEqual(nameMonth, timeData.giveMonthName(numMonth).Trim()); // юнит тест который проверяет значение (названия месяца и его номер) на равенство и выдает тот месяц который должен быть, если они не равны
        }
        /// 
        [TestMethod]
        public void TestThereIsNoOneInAuthorizationWorker()
        {
            Worker worker = new Worker();
            Assert.IsTrue(Checks.checkWorker("", "", out worker)); // юнит тест который проверяет возращает ли метод проверки заполнения логина и пароля true, при не заполненном поле у работника

        }
        [TestMethod]
        public void TestThereIsNoOneInAuthorizationMember()
        {
            Member member = new Member();
            Assert.IsTrue(Checks.checkMember("", "", out member)); // юнит тест который проверяет возращает ли метод проверки заполнения логина и пароля true, при не заполненном поле у пользователя

        }
        ///
        //[TestMethod]
        //public void TestThereIsNoOneInAuthorizationWorker3()
        //{
        //    Worker worker = new Worker();
        //    Assert.IsTrue(Checks.checkWorker("", "", out worker)); // юнит тест который проверяет возращает ли метод проверки заполнения логина и пароля true, при не заполненном поле у пользователя

        //}
    }













}
