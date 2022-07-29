using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PlanBetterAutomation.PageObjects;
using System;

namespace PlanBetterAutomation
{
    [TestClass]
    public class LoginTests
    {
        private IWebDriver driver;
        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:4200/login");

        }
        [TestMethod]
        public void AdminTestLogin_SuccessfullyLogin()
        {
            var login = new LoginPage(driver);
            login.Login("email1@facultate.profesor.com", "parola123");
            var admin = new AdminPage(driver);
        }
        [TestMethod]
        public void StudentTestLogin_SuccessfullyLogin()
        {
            var login = new LoginPage(driver);
            login.Login("email2@facultate.student.com", "admin123");
            var student = new StudentPage(driver);
        }
        [TestMethod]
        public void TestLogin_WrongCredentialsLogin()
        {
            var login = new LoginPage(driver);
            login.Login("email1@facultate.profesor.com", "invalid");
            var errorMessage = login.InvalidLoginMessage();
            Assert.AreEqual("Bad email or password.", errorMessage);
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }

    }
}
