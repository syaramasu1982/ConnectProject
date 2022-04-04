using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Uksbs.Connect.AutomatedTests.PageObjects;
using Uksbs.Connect.AutomatedTests.SpecFlowFactory;

namespace Uksbs.Connect.AutomatedTests.StepDefinitions
{
    [Binding]
    public sealed class LoginDemoSteps
    {
        private SeleniumContext seleniumContext;
        private IWebDriver webDriver;
        private ScenarioContext _scenarioContext;
        private LoginDemoPage _loginDemoPage;

        public LoginDemoSteps(SeleniumContext seleniumContext, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            this.seleniumContext = seleniumContext;
            this.webDriver = seleniumContext.WebDriver;
            _loginDemoPage = new LoginDemoPage(webDriver, _scenarioContext);


        }

        [Given(@"I launch ebs application")]
        public void GivenILaunchEbsApplication()
        {
            _loginDemoPage.LaunchApplication();
        }

        [Given(@"I enter username as ""(.*)""")]
        public void GivenIEnterUsernameAs(string username)
        {
            _loginDemoPage.EnterUserName(username);
        }

        [Given(@"I enter password as ""(.*)""")]
        public void GivenIEnterPasswordAs(string password)
        {
            _loginDemoPage.EntePassword(password);
        }

        [Then(@"I click on login button")]
        public void ThenIClickOnLoginButton()
        {
            _loginDemoPage.ClickLoginButton();
        }

        [Then(@"I should see dashboard items in EBS")]
        public void ThenIShouldSeeDashboardItemsInEBS()
        {
            _loginDemoPage.ValidateDashBoard();
        }


    }
}
