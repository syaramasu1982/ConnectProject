using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Uksbs.Connect.AutomatedTests.Common;
using Uksbs.Connect.AutomatedTests.SpecFlowFactory;
using Uksbs.Connect.AutomatedTests.PageObjects;
using Xunit;

namespace Uksbs.Connect.AutomatedTests.StepDefinitions
{
    [Binding]
    public sealed class GDPRSteps
    {
        private SeleniumContext seleniumContext;
        private IWebDriver webDriver;
        private ScenarioContext _scenarioContext;

        

        private GDPRPage _gdprPage;

        public GDPRSteps(SeleniumContext seleniumContext, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            //save the context so you can use it in your tests
            this.seleniumContext = seleniumContext;
            this.webDriver = seleniumContext.WebDriver;

            

            // Creating selenium specific instance for login page
            _gdprPage = new GDPRPage(webDriver, _scenarioContext);
        }


        [Then(@"I click GDPR privacy")]
        public void ThenIClickGDPRPrivacy()
        {
            _gdprPage.ClickGDPRPrivacy();
        }

        [Then(@"I verify GDPR privacy notice")]
        public void ThenIVerifyGDPRPrivacyNotice()
        {
            _gdprPage.VerifyGDPRPrivacyNotice();
        }

        [Then(@"I click privacy notice")]
        public void ThenIClickPrivacyNotice()
        {
            _gdprPage.ClickPrivacyNotice();
        }

        [Then(@"I close new tab")]
        public void ThenICloseNewTab()
        {
            Assert.True(_gdprPage.WaitForNewWindow(10), "New window is not opened");

            webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);
            webDriver.Close();
            webDriver.SwitchTo().Window(webDriver.WindowHandles[0]);
        }

        [Then(@"I click GRPR privacy")]
        public void ThenIClickGRPRPrivacy()
        {
            _gdprPage.ClickGDPRPrivacy();
        }

    }
}
