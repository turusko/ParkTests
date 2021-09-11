using FluentAssertions;
using ParkTests.PageModels.Account.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;


namespace ParkTests.Steps.Account.Register
{
    [Binding]
    public sealed class RegistrationStepDefinition
    {


        private FeatureContext _featurecontext;
        private RegisterPage _registerPage;

        public RegistrationStepDefinition(FeatureContext featurecontext)
        {
            _featurecontext = featurecontext;
            _featurecontext.TryGetValue("registerPage", out _registerPage);
        }

        [When(@"the user provides a password ""(.*)""")]
        public void WhenTheUserProcidesAPassword(string password)
        {
            _registerPage.SetPassword(password);
        }

        [Then(@"error appears with the text ""(.*)""")]
        [When(@"error appears with the text ""(.*)""")]
        [Given(@"error appears with the text ""(.*)""")]
        public void ThenErrorAppearsWithTheText(string errorMessage)
        {
            _registerPage.IsErrorMessageVisibile(errorMessage).Should().BeTrue();
        }

        [Given(@"User select next")]
        [When(@"user select Next")]
        public void WhenUserSelectNext()
        {
            _registerPage.SelectNext();
        }

        [When(@"the user provides mobile number ""(.*)""")]
        public void WhenTheUserProvidesMobileNumber(string mobileNumber)
        {
            _registerPage.SetMovbileNumber(mobileNumber);
        }

        [When(@"the user provides email address ""(.*)""")]
        public void WhenTheUserProvidesEmailAddress(string emailAddress)
        {
            _registerPage.SetEmailAddress(emailAddress);
        }

        [Then(@"error with the text ""(.*)"" disappears")]
        public void ThenErrorWithTheTextDisappears(string errorMessage)
        {
            _registerPage.IsErrorMessageVisibile(errorMessage).Should().BeFalse();
        }

        [Then(@"password requirement ""(.*)"" is not ticked")]
        public void ThenPasswordRequirementIsNotTicked(string passwordMust)
        {
            _registerPage.IsPasswordMustTicked(passwordMust).Should().BeFalse();
        }

        [Then(@"password requirement ""(.*)"" is ticked")]
        public void ThenPasswordRequirementIsTicked(string passwordMust)
        {
            _registerPage.IsPasswordMustTicked(passwordMust).Should().BeTrue();
        }



    }
}
