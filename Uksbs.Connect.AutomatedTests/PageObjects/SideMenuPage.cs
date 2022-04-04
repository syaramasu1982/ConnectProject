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
using SeleniumExtras.WaitHelpers;

namespace Uksbs.Connect.AutomatedTests.PageObjects
{
    public class SideMenuPage : BasePage, IClassFixture<SeleniumDriver>
    {
        private readonly IWebDriver webDriver;
        
        private readonly ScenarioContext _scenarioContext;

        private readonly string _viewMenu = "//nav[@aria-label='Product navigation']//button[@title='View Menu']";
        private readonly string _myOracleHomepage = "//button[@id='my-ebs-responsibilities-link']";
        private readonly string _profQualifications = "//*[@id='other-professional-qualifications-link']//a[contains(text(),'Professional Qualifications')]";
        private readonly string _profQualificationPageTitle = "//h1[contains(text(),'Other Professional Qualifications')]";
        private readonly string _expenseHomepageTitle = "//h1[contains(text(),'My Expense Claims')]";
        private readonly string _absencePageTitle = "//h1[contains(text(),'My Absences')]";
        private readonly string _teamAbsencesPageTitle = "//h1[contains(text(),'Team Absences')]";
        private readonly string _myDirectReportsTitle = "//h2[contains(text(),'My Direct Reports')]";
        private readonly string _notificationPageTitle = "//h1[contains(text(),'Notification Centre')]";
        private readonly string _teamPageTitle = "//h1[contains(text(),'Team View')]";
        private readonly string _iSupportTitle = "//h2[contains(text(),'Support Resources')]";
        private readonly string _expenses = "//button[@id='expenses-link']";
        private readonly string _absence = "//button[@id='absence-link']";
        private readonly string _managerAbsenceView = "//button[@id='manager-absence-link']";
        private readonly string _CreateViewAbsences = "//span[contains(text(),'CREATE/VIEW ABSENCES')]";
        private readonly string _notifications = "//button[@title='Notifications']";
        private readonly string _team = "//button[@id='team-link']";
        private readonly string _iSupport = "//button[@id='iSupport-link']";


        public SideMenuPage(IWebDriver webDriver, ScenarioContext scenarioContext) : base(webDriver)
        {
            this.webDriver = webDriver;
            
            _scenarioContext = scenarioContext;
        }

        public void ClickViewMenu()
        {           
            this.Click(By.XPath(_viewMenu));
        }
        public void RefreshPage()
        {
            webDriver.Navigate().Refresh();
            this.LoadEntirePage();
            Thread.Sleep(5000);
        }

        public void ClickMyOracleHomepage()
        {
           
            this.Click(By.XPath(_myOracleHomepage));
            Thread.Sleep(2000);
        }
        public void ClickProfQualifications()
        {
           
            this.Click(By.XPath(_profQualifications));
        }
        public void ValidateProfQualifications()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_profQualificationPageTitle)));
            Assert.True(this.IsElementPresent(By.XPath(_profQualificationPageTitle)));
        }
        public void ClickIExpenses()
        {
           
            this.Click(By.XPath(_expenses));
        }
        public void ValidateExpenseHomepage()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_expenseHomepageTitle)));
            Assert.True(this.IsElementPresent(By.XPath(_expenseHomepageTitle)));
        }
        public void ClickAbsence()
        {
           
            this.Click(By.XPath(_absence));
        }
        public void ValidateAbsenceDetails()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_absencePageTitle)));
            Assert.True(this.IsElementPresent(By.XPath(_absencePageTitle)));
        }
        public void ClickManagerAbsenceView()
        {
           
            this.Click(By.XPath(_managerAbsenceView));
        }
        public void ClickCreateORViewAbsences()
        {
           
            this.Click(By.XPath(_CreateViewAbsences));
        }
        public void ClickNotifications()
        {
           
            this.Click(By.XPath(_notifications));
        }
        public void ValidateNotifications()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_notificationPageTitle)));
            Assert.True(this.IsElementPresent(By.XPath(_notificationPageTitle)));
        }

        public void ClickTeam()
        {
           
            this.Click(By.XPath(_team));
        }
        public void ValidateTeamView()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_teamPageTitle)));
            Assert.True(this.IsElementPresent(By.XPath(_teamPageTitle)));
        }
        public void ClickISupport()
        {
           
            this.Click(By.XPath(_iSupport));
        }

        public void ValidateISupport()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_iSupportTitle)));
            Assert.True(this.IsElementPresent(By.XPath(_iSupportTitle)));
        }
        public void ValidateManagerAbsenceView()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_teamAbsencesPageTitle)));
            Assert.True(this.IsElementPresent(By.XPath(_teamAbsencesPageTitle)));
            Assert.True(this.IsElementPresent(By.XPath(_myDirectReportsTitle)));
        }

        private WebDriverWait getDriverWait()
        {
            return new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(Constants.DefaultWaitTime));
        }
    }
}
