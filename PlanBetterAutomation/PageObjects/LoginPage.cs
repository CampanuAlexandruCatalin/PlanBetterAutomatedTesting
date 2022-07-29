using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanBetterAutomation.PageObjects
{
    public class LoginPage
    {
        private IWebDriver Driver { get; }

        public LoginPage(IWebDriver browser)
        {
            Driver = browser;
            PageFactory.InitElements(Driver, this);
        }
        private readonly By username = By.Id("email");
        private IWebElement TxtUsername => Driver.FindElement(username);

        private readonly By password = By.Id("password");
        private IWebElement TxtPassword => Driver.FindElement(password);

        private readonly By login = By.ClassName("button1");
        private IWebElement BtnLogin => Driver.FindElement(login);


        private readonly By error = By.XPath("");
        private IWebElement TxtError => Driver.FindElement(error);

        public void Login(string username, string password)
        {
            TxtUsername.SendKeys(username);
            TxtPassword.SendKeys(password);
            BtnLogin.Click();
        }

        public string InvalidLoginMessage()
        {
            return TxtError.Text;
        }

    }
}
