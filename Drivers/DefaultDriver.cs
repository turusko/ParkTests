using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using ParkTests.PageModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ParkTests.Drivers
{
    public class DefaultDriver
    {
        TestConfiguration _testConfiguration;
        private EdgeDriver _driver;

        public DefaultDriver()
        {

            var configuration = new ConfigurationBuilder()
               .AddJsonFile(
                   Path.Combine(
                       Path.GetDirectoryName(
                           Assembly.GetExecutingAssembly().Location),
                           "config.json"))
               .AddUserSecrets("42713ce2-646d-44d1-9c21-bd09ee5ea19d")
               .Build();

            _testConfiguration = new TestConfiguration
            {
                URL = configuration["Enviroment:URL"],
                Username = configuration["Enviroment:Username"],
                Password = configuration["Enviroment:Password"]
            };

            _driver = new EdgeDriver("C:\\WebDriver\\");
            _driver.Manage().Window.Maximize();


        }

        public LandingPage NavigateToLandingPage()
        {

            _driver.Navigate().GoToUrl($"http://{_testConfiguration.Username}:{_testConfiguration.Password}@{_testConfiguration.URL}");

            return new LandingPage(_driver);
        }

        public void Quit()
        {
            _driver.Quit();
        }
    }
}
