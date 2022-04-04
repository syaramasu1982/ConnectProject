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
    public sealed class SupportLinksSteps
    {
        private SeleniumContext seleniumContext;
        private IWebDriver webDriver;
        private ScenarioContext _scenarioContext;

        

        private SupportLinksPage _supportLinksPage;

        public SupportLinksSteps(SeleniumContext seleniumContext, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            //save the context so you can use it in your tests
            this.seleniumContext = seleniumContext;
            this.webDriver = seleniumContext.WebDriver;

            

            // Creating selenium specific instance for login page
            _supportLinksPage = new SupportLinksPage(webDriver, _scenarioContext);
        }


        [Then(@"I click raise service request")]
        public void ThenIClickRaiseServiceRequest()
        {
            _supportLinksPage.ClickRaiseServiceRequest();            
        }

        [Then(@"I click using UKSBS service")]
        public void ThenIClickUsingUKSBSService()
        {
            _supportLinksPage.ClickUsingUKSBSServices();
        }

        [Then(@"I click guides to using oracle")]
        public void ThenIClickGuidesToUsingOracle()
        {
            _supportLinksPage.ClickGuidesToUsingOracle();
        }


    }
}
