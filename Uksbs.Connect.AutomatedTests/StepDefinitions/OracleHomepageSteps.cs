using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Uksbs.Connect.AutomatedTests.Common;
using Uksbs.Connect.AutomatedTests.SpecFlowFactory;
using Uksbs.Connect.AutomatedTests.PageObjects;
using System.Threading;

namespace Uksbs.Connect.AutomatedTests.StepDefinitions
{
    [Binding]
    public sealed class OracleHomepageSteps
    {
        private SeleniumContext seleniumContext;
        private IWebDriver webDriver;
        private ScenarioContext _scenarioContext;

        

        private OracleHomepagePage _oracleHomepagePage;

        public OracleHomepageSteps(SeleniumContext seleniumContext, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            //save the context so you can use it in your tests
            this.seleniumContext = seleniumContext;
            this.webDriver = seleniumContext.WebDriver;

            

            // Creating selenium specific instance for login page
            _oracleHomepagePage = new OracleHomepagePage(webDriver, _scenarioContext);
        }

        

        [When(@"I click view my responsibilities")]
        public void ThenIClickViewMyResponsibilities()
        {
            _oracleHomepagePage.ClickViewMyResponsibilities();
        }

        [Then(@"New tab will be opened")]
        public void ThenNewTabWillBeOpened()
        {
            Thread.Sleep(1000);
            webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);
        }


        [Then(@"I verify EBS home page")]
        public void ThenIVerifyEBSHomePage()
        {
            _oracleHomepagePage.ValidateOracleHomePage();
        }


    }
}
