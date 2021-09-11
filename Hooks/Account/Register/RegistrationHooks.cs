using OpenQA.Selenium.Edge;
using ParkTests.Drivers;
using ParkTests.PageModels;
using ParkTests.PageModels.Account.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace ParkTests.Hooks.Account.Register
{
    [Binding]
    public sealed class RegistrationHooks
    {


        [BeforeFeature("Registration")]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            var driver = new DefaultDriver();
            var landingPage = driver.EdgeDriver();
            var registerPage = landingPage.RegisterNewUser();
            featureContext.Add("registerPage", registerPage);
            featureContext.Add("driver", driver);
        }

        [AfterScenario("Registration")]
        public static void AfterScenario(FeatureContext featureContext)
        {
            featureContext.TryGetValue("registerPage", out RegisterPage registerPage);
            registerPage.ReloadPage();

        }

        [AfterFeature("Registration")]
        public static void AfterFeature(FeatureContext featureContext)
        {
            featureContext.TryGetValue("driver", out DefaultDriver driver);
            driver.Quit();
        }

    }
}
