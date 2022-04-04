using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using Uksbs.Connect.AutomatedTests.Common;
using Uksbs.Connect.AutomatedTests.SpecFlowFactory;
using Xunit;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using System.Threading;
using System.Linq;
using SeleniumExtras.WaitHelpers;

namespace Uksbs.Connect.AutomatedTests.WebTests.PageObjects
{
    public class LoginPage : BasePage, IClassFixture<SeleniumDriver>
    {
        private readonly BasePage _basePage;
        private readonly IWebDriver webDriver;
        
        private readonly ScenarioContext _scenarioContext;

        private readonly string _username = "//input[@id='username'] | //input[@name='username']";
        private readonly string _password = "//input[@id='password'] | //input[@name='password']";
        private readonly string _nextButton = "//input[@value='Next']";
        private readonly string _loginButton = "//*[@id='loginData']//input[@value='Login'] | //input[@value='Sign In']";
        private readonly string _navigationMenu = "//nav[@aria-label='Product navigation']";
        private readonly string _viewMenu = "//nav[@aria-label='Product navigation']//button[@title='View Menu']";
        private readonly string _homePage = "//nav[@aria-label='Product navigation']//button[@title='Go to Homepage']";
        private readonly string _myProfile = "//nav[@aria-label='Product navigation']//button[@title='Go to My Profile']";
        private readonly string _notification = "//nav[@aria-label='Product navigation']//button[@title='Notifications']";
        private readonly string _logout = "//nav[@aria-label='Product navigation']//button[@title='Logout']";
        private readonly string _myProfileTitle = "//h2[contains(text(),'My profile')]";
        private readonly string _myContactDetails = "//h2[contains(text(),'My contact details')]";
        private readonly string _myPayslips = "//h2[contains(text(),'My payslips')]";
        private readonly string _myAbsences = "//h2[contains(text(),'My Absences')]";
        private readonly string _myAnnualLeave = "//h2[contains(text(),'My Annual Leave')]";
        private readonly string _myTeam = "//div[contains(text(),'My team')]/div[contains(text(),'Only displays staff with active Oracle User Accounts')]";
        private readonly string _myOvertime = "//h2[contains(text(),'My Overtime')]";
        private readonly string _myExpenses = "//h2[contains(text(),'My Expenses')]";
        private readonly string _myP60s = "//h2[contains(text(),'MY P60s')]";
        private readonly string _myOracleHomePage = "//h2[contains(text(),'My Oracle homepage')]";
        private readonly string _supportLinks = "//h2[contains(text(),'Support links')]";
        private readonly string _feedback = "//h2[contains(text(),'Feedback')]";
        private readonly string _logoutSuccess = "//*[contains(text(),'User logged out successfully')]";

        public LoginPage(IWebDriver webDriver, ScenarioContext scenarioContext) : base(webDriver)
        {
            this.webDriver = webDriver;
            
            _scenarioContext = scenarioContext;
        }
        public void LoginAsEmployee()
        {
            webDriver.Navigate().GoToUrl(Settings.ConnectWebUrl);
            this.LoadEntirePage();

                this.Click(By.XPath(_username));
                this.Type(Settings.EmpUserName, By.XPath(_username));

                if (this.IsElementExists(By.XPath(_nextButton))){
                    this.Click(By.XPath(_nextButton));
                }
                
                this.Click(By.XPath(_password));
                this.Type(Settings.EmpPassword, By.XPath(_password));
                this.Click(By.XPath(_loginButton));
                this.LoadEntirePage();
            
        }

        public void LoginAsManager()
        {
            webDriver.Navigate().GoToUrl(Settings.ConnectWebUrl);
            this.LoadEntirePage();

            this.Click(By.XPath(_username));
            this.Type(Settings.MgrUserName, By.XPath(_username));
            if (this.IsElementExists(By.XPath(_nextButton)))
            {
                this.Click(By.XPath(_nextButton));
            }
            this.Click(By.XPath(_password));
            this.Type(Settings.MgrPassword, By.XPath(_password));

            this.Click(By.XPath(_loginButton));
            this.LoadEntirePage();
        }

        public void LaunchConnectApplication(IWebDriver webDriver)
        {
            this.webDriver.Manage().Cookies.DeleteAllCookies();
            webDriver.Navigate().GoToUrl(Settings.ConnectWebUrl);            
            this.LoadEntirePage();
        }
        public void EnterLoginCredentials(IWebDriver webDriver, string username, string password)
        {
            this.Click(By.XPath(_username));
            this.Type(username,By.XPath(_username));
            this.Click(By.XPath(_password));
            this.Type(password, By.XPath(_password));
        }
        public void ClickLoginButton()
        {
            this.webDriver.Manage().Cookies.DeleteAllCookies();
            this.Click(By.XPath(_loginButton));
            this.LoadEntirePage();
        }
        public void ValidateConnectDashboard()
        {
            this.LoadEntirePage();
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_navigationMenu)));

            Assert.True(this.IsElementPresent(By.XPath(_navigationMenu)));
            Assert.True(this.IsElementPresent(By.XPath(_viewMenu)));
            Assert.True(this.IsElementPresent(By.XPath(_homePage)));
            Assert.True(this.IsElementPresent(By.XPath(_myProfile)));
            Assert.True(this.IsElementPresent(By.XPath(_notification)));
            Assert.True(this.IsElementPresent(By.XPath(_logout)));

            Assert.True(this.IsElementPresent(By.XPath(_myProfileTitle)));
            Assert.True(this.IsElementPresent(By.XPath(_myContactDetails)));
            Assert.True(this.IsElementPresent(By.XPath(_myPayslips)));
            Assert.True(this.IsElementPresent(By.XPath(_myAbsences)));
            Assert.True(this.IsElementPresent(By.XPath(_myAnnualLeave)));
            Assert.True(this.IsElementPresent(By.XPath(_myTeam)));
            Assert.True(this.IsElementPresent(By.XPath(_myP60s)));
            Assert.True(this.IsElementPresent(By.XPath(_myOvertime)));
            Assert.True(this.IsElementPresent(By.XPath(_myExpenses)));
            Assert.True(this.IsElementPresent(By.XPath(_myOracleHomePage)));
            Assert.True(this.IsElementPresent(By.XPath(_supportLinks)));
            Assert.True(this.IsElementPresent(By.XPath(_feedback)));
        }

        public void ClickLogoutButton()
        {           
            var wait = getDriverWait();

            bool staleElement = true;
            while (staleElement)
            {
                try
                {
                    this.Click(By.XPath(_logout));
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_logoutSuccess)));
                    this.webDriver.Manage().Cookies.DeleteAllCookies();
                    staleElement = false;
                }
                catch (StaleElementReferenceException e)
                {
                    staleElement = true;
                    this.webDriver.Manage().Cookies.DeleteAllCookies();
                }
            }
           // this.LoadEntirePage();
        }

        public void ClickHomeButton()
        {
            this.Click(By.XPath(_homePage));
        }

        public void SwitchNewBrowser()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
            js.ExecuteScript("window.open();");
            webDriver.SwitchTo().Window(this.WebDriver.WindowHandles.Last()); 
        }
       
        private WebDriverWait getDriverWait()
        {
            return new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(Constants.DefaultWaitTime));
        }
    }
}
