using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ParkTests.PageModels.Account.Register
{
    public class RegisterPage
    {
        private IWebDriver _driver;
        private IWebElement MobileNumberTextField => _driver.FindElement(By.Id("field-Member_CLI"));
        private IWebElement EmailTextField => _driver.FindElement(By.Id("field-Member_Email"));
        private IWebElement PasswordTextField => _driver.FindElement(By.Id("field-MemberPassword"));
        private IWebElement TermsCheckBox => _driver.FindElement(By.CssSelector("input[name='terms']"));
        private IWebElement NextButton => _driver.FindElement(By.Id("labyrinth_UserDetails_next"));

        public RegisterPage(IWebDriver driver)
        {
            _driver = driver;
        }


        public void SetPassword(string password)
        {
            PasswordTextField.SendKeys(password);
            PasswordTextField.SendKeys(Keys.Tab);
        }


        public void ReloadPage()
        {
            _driver.Navigate().GoToUrl(_driver.Url);
        }

        public bool IsErrorMessageVisibile(string errorMessage)
        {

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var messages = wait.Until(e => e.FindElement(By.CssSelector("span.error")));

            return _driver.FindElements(By.CssSelector("span.error"))
                .Any(message => message.GetProperty("innerText") == errorMessage);


        }

        public void SelectNext()
        {
            NextButton.Click();
        }

        public void SetEmailAddress(string emailAddress)
        {
            EmailTextField.SendKeys(emailAddress);
        }

        public void SetMovbileNumber(string mobileNumber)
        {
            MobileNumberTextField.SendKeys(mobileNumber);
        }

        public bool IsPasswordMustTicked(string passwordMust)
        {
            switch (passwordMust)
            {
                case "Have at least 8 characters":
                    return IsConditionMet("length");

                case "Include an uppercase letter":
                    return IsConditionMet("uppercase");

                case "Include a lowercase letter":
                    return IsConditionMet("lowercase");

                case "Include a number":
                    return IsConditionMet("number");

                default:
                    throw new SystemException($"{passwordMust} is not a valid password requirement");
            }
                
        }
        private bool IsConditionMet(string condition)
        {
            return _driver.FindElement(By.CssSelector($"li.{condition}"))
                .FindElement(By.TagName("Span")).GetAttribute("Class").Contains("condition-met");
        }
    }
}
