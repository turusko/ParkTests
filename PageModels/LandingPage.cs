using OpenQA.Selenium;
using ParkTests.PageModels.Account.Register;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkTests.PageModels
{
    public class LandingPage
    {
        private IWebDriver _driver;
        public LandingPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public RegisterPage RegisterNewUser()
        {
            _driver.FindElement(By.LinkText("Register")).Click();
            return new RegisterPage(_driver);
        }
    }
}
