using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Uksbs.Connect.AutomatedTests.Common;
using Uksbs.Connect.AutomatedTests.SpecFlowFactory;
using Uksbs.Connect.AutomatedTests.WebTests.PageObjects;

namespace Uksbs.Connect.AutomatedTests.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private SeleniumContext seleniumContext;
        private IWebDriver webDriver;
        private ScenarioContext _scenarioContext;        

        private LoginPage _loginPage;

        public LoginSteps(SeleniumContext seleniumContext, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            //save the context so you can use it in your tests
            this.seleniumContext = seleniumContext;
            this.webDriver = seleniumContext.WebDriver;
          //  webDriver.Manage().Window.Maximize();            

            // Creating selenium specific instance for login page
            _loginPage = new LoginPage(webDriver, _scenarioContext);
        }

        [Given(@"I launch the application")]
        public void GivenILaunchTheApplication()
        {
            _loginPage.LaunchConnectApplication(webDriver);
        }

        [Given(@"I enter the following details")]
        public void GivenIEnterTheFollowindDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _loginPage.EnterLoginCredentials(webDriver, (string)data.UserName, (string)data.Password);
        }

        [Given(@"I click login button")]
        public void GivenIClickLoginButton()
        {
            _loginPage.ClickLoginButton();
        }

        [Then(@"I should see the Dashboard Items")]
        public void ThenIShouldSeeTheDashboardItems()
        {
            _loginPage.ValidateConnectDashboard();
        }

        [Then(@"I click on logout button")]
        public void ThenIClickOnLogoutButton()
        {
            _loginPage.ClickLogoutButton();
        }

        [Given(@"I click on home button")]
        public void GivenIClickOnHomeButton()
        {
            _loginPage.ClickHomeButton();
        }

        [Then(@"I click on new tab")]
        public void ThenIClickOnNewTab()
        {
            _loginPage.SwitchNewBrowser();
        }

        [Given(@"I login as an employee")]
        public void GivenILoginAsAnEmployee()
        {
            _loginPage.LoginAsEmployee();
        }

        [Given(@"I login as manager")]
        public void GivenILoginAsManager()
        {
            _loginPage.LoginAsManager();
        }

    }
}
