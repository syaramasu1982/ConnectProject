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
    public sealed class AccessPayslipSteps
    {
        private SeleniumContext seleniumContext;
        private IWebDriver webDriver;
        private ScenarioContext _scenarioContext;

        

        private AccessPayslipsPage _accessPayslipsPage;

        public AccessPayslipSteps(SeleniumContext seleniumContext, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            //save the context so you can use it in your tests
            this.seleniumContext = seleniumContext;
            this.webDriver = seleniumContext.WebDriver;
            

            // Creating selenium specific instance for login page
            _accessPayslipsPage = new AccessPayslipsPage(webDriver, _scenarioContext);
        }
        [Then(@"I open most recent payslip")]
        public void ThenIOpenMostRecentPayslip()
        {
            _accessPayslipsPage.ClickMostRecentPayslip();
        }

        [Then(@"I click view all in payslips")]
        public void ThenIClickViewAllInPayslips()
        {
            _accessPayslipsPage.ClickViewAllPayslips();
        }

        [Then(@"I open oldest payslip")]
        public void ThenIOpenOldestPayslip()
        {
            _accessPayslipsPage.ClickOldestPayslip();
        }
    }
}
