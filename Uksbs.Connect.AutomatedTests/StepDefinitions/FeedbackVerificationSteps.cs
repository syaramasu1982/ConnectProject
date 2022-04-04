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
    public sealed class FeedbackVerificationSteps
    {
        private SeleniumContext seleniumContext;
        private IWebDriver webDriver;
        private ScenarioContext _scenarioContext;

        

        private FeedbackVerificationPage _feedbackVerificationPage;

        public FeedbackVerificationSteps(SeleniumContext seleniumContext, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            //save the context so you can use it in your tests
            this.seleniumContext = seleniumContext;
            this.webDriver = seleniumContext.WebDriver;

            

            // Creating selenium specific instance for login page
            _feedbackVerificationPage = new FeedbackVerificationPage(webDriver, _scenarioContext);
        }


        [Then(@"I verify Feedback message")]
        public void ThenIVerifyFeedbackMessage()
        {
            _feedbackVerificationPage.VerifyFeedbackMessage();
        }

        [Then(@"I click UKSBS connect feedback")]
        public void ThenIClickUKSBSConnectFeedback()
        {
            _feedbackVerificationPage.ClickUKSBSConnectFeedback();
        }

        [Then(@"I click service request feedback")]
        public void ThenIClickServiceRequestFeedback()
        {
            _feedbackVerificationPage.ClickServiceRequestFeedback();
        }

    }
}
