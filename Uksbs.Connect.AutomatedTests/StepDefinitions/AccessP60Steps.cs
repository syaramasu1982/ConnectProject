using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Uksbs.Connect.AutomatedTests.Common;
using Uksbs.Connect.AutomatedTests.SpecFlowFactory;
using Uksbs.Connect.AutomatedTests.PageObjects;

namespace Uksbs.Connect.AutomatedTests.StepDefinitions
{
    [Binding]
    public sealed class AccessP60Steps
    {
        private SeleniumContext seleniumContext;
        private IWebDriver webDriver;
        private ScenarioContext _scenarioContext;

        

        private AccessP60sPage _accessP60sPage;

        public AccessP60Steps(SeleniumContext seleniumContext, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            //save the context so you can use it in your tests
            this.seleniumContext = seleniumContext;
            this.webDriver = seleniumContext.WebDriver;
            

            // Creating selenium specific instance for login page
            _accessP60sPage = new AccessP60sPage(webDriver, _scenarioContext);
        }

        [Then(@"I open most recent p60")]
        public void ThenIOpenMostRecentP60()
        {
            _accessP60sPage.ClickMostRecentP60();
        }

        [Then(@"I click view all in p60")]
        public void ThenIClickViewAllInP60()
        {
            _accessP60sPage.ClickViewAllP60();
        }

        [Then(@"I open oldest p60")]
        public void ThenIOpenOldestP60()
        {
            _accessP60sPage.ClickOldestP60();
        }

    }
}
