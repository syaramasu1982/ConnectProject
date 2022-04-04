using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using Uksbs.Connect.AutomatedTests.Common;
using Uksbs.Connect.AutomatedTests.SpecFlowFactory;
using Xunit;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using SeleniumExtras.WaitHelpers;

namespace Uksbs.Connect.AutomatedTests.PageObjects
{
    public class ViewMyProfilePage : BasePage, IClassFixture<SeleniumDriver>
    {
        private readonly IWebDriver webDriver;
        
        private readonly ScenarioContext _scenarioContext;

        private readonly string _profileFullName = "//*[@id='cardface']//div[@class='profile-summary-name-text']";
        private readonly string _profilePositionName = "//*[@id='cardface']//div[@class='profile-summary-job-text']";
        private readonly string _back = "//span[contains(text(),'BACK')]";
        private readonly string _viewMenu = "//*[@id='connect-module']//a[@title='View Menu']";
        private readonly string _maritalStatus = "//*[@id='cardface-backside']//div[contains(@data-bind,'maritalStatus')]";
        private readonly string _niNumber = "//*[@id='cardface-backside']//div[contains(@data-bind,'nationalIdentifier')]";
        private readonly string _dob = "//*[@id='cardface-backside']//div[contains(@data-bind,'dateOfBirth')]";
        private readonly string _employeeNumber = "//*[@id='cardface-backside']//div[contains(@data-bind,'employeeNumber')]";
        private readonly string _costCenterCode = "//*[@id='cardface-backside']//div[contains(@data-bind,'costCentreCode')]";
        private readonly string _supervisorName = "//*[@id='cardface-backside']//div[contains(@data-bind,'supervisorName')]";
        private readonly string _viewMyProfile = "//div[@aria-label='View My Profile']";
        public ViewMyProfilePage(IWebDriver webDriver, ScenarioContext scenarioContext) : base(webDriver)
        {
            this.webDriver = webDriver;
            
            _scenarioContext = scenarioContext;
        }

        public void VerifyProfileNameAndPosition(string expFullName, string expPosition)
        {
            var actualFullName = GetProfileFullName();
            Assert.Equal(expFullName, actualFullName);

            var actualPosition = GetProfilePositionName();
            Assert.Equal(expPosition, actualPosition);
        }
        public string GetProfileFullName()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_profileFullName)));
            this.Find(By.XPath(_profileFullName));
            string result = FindElementXPath(_profileFullName);
            return result;
        }
        public string GetProfilePositionName()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_profilePositionName)));
            this.Find(By.XPath(_profilePositionName));
            string result = FindElementXPath(_profilePositionName);
            return result;
        }
        public void ClickViewMyProfile()
        {
           
            this.Click(By.XPath(_viewMyProfile));
        }

        public string GetMaritalStatus()
        {
            this.Find(By.XPath(_maritalStatus));
            string result = FindElementXPath(_maritalStatus);
            return result;
        }
        public string GetNINumber()
        {
            this.Find(By.XPath(_niNumber));
            string result = FindElementXPath(_niNumber);
            return result;
        }
        public string GetDOB()
        {
            this.Find(By.XPath(_dob));
            string result = FindElementXPath(_dob);
            return result;
        }
        public string GetEmpNumber()
        {
            this.Find(By.XPath(_employeeNumber));
            string result = FindElementXPath(_employeeNumber);
            return result;
        }
        public string GetCostCenterCode()
        {
            this.Find(By.XPath(_costCenterCode));
            string result = FindElementXPath(_costCenterCode);
            return result;
        }
        public string GetSupervisorName()
        {
            this.Find(By.XPath(_supervisorName));
            string result = FindElementXPath(_supervisorName);
            return result;
        }

        public void VerifyProfileInformation(string expMaritalStatus, string expNINumber, string expDOB, string expEmpNumber, string expCostCenterCode, string expSuperVisorName)
        {
            var actualMaritalStatus = GetMaritalStatus();
            var actualNINumber = GetNINumber();
            var actualDOB = GetDOB();
            var actualEmpNumber = GetEmpNumber();
            var actualCostCenterCode = GetCostCenterCode();
            var actualSupervisorName = GetSupervisorName();

            Assert.Equal(expMaritalStatus, actualMaritalStatus);
            Assert.Equal(expNINumber, actualNINumber);
            Assert.Equal(expDOB, actualDOB);
            Assert.Equal(expEmpNumber, actualEmpNumber);
            Assert.Equal(expCostCenterCode, actualCostCenterCode);
            Assert.Equal(expSuperVisorName, actualSupervisorName);
        }
        public void ClickBack()
        {
           
            this.Click(By.XPath(_back));
        }

        private WebDriverWait getDriverWait()
        {
            return new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(Constants.DefaultWaitTime));
        }
    }
}
