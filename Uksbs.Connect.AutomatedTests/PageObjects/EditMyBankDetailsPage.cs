using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using Uksbs.Connect.AutomatedTests.Common;
using Uksbs.Connect.AutomatedTests.SpecFlowFactory;
using Xunit;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Uksbs.Connect.AutomatedTests.PageObjects
{
    public class EditMyBankDetailsPage : BasePage, IClassFixture<SeleniumDriver>
    {
       // private readonly BasePage this;
        private readonly IWebDriver webDriver;
        
        private readonly ScenarioContext _scenarioContext;

        private readonly string _bankName = "//select[contains(@aria-labelledby,'myemergencycontacts-bank')]";
        private readonly string _branchName = "//input[contains(@aria-labelledby,'myemergencycontacts-branch')]";
        private readonly string _sortCode = "//input[contains(@aria-labelledby,'myemergencycontacts-sortcode')]";
        private readonly string _accountNumber = "//input[contains(@aria-labelledby,'myemergencycontacts-account-number')]";
        private readonly string _accountName = "//input[contains(@aria-labelledby,'myemergencycontacts-account-name')]";
        private readonly string _buildingSociety = "//input[contains(@aria-labelledby,'bs-account')]";
        private readonly string _saveBankDetails = "//div[@aria-label ='My Salary Bank Details Save']";

        public EditMyBankDetailsPage(IWebDriver webDriver, ScenarioContext scenarioContext) : base(webDriver)
        {
            this.webDriver = webDriver;
            
            _scenarioContext = scenarioContext;
        }


        public void SelectBankName(string bankName)
        {
           
            this.SelectFromDropdown(bankName, (By.XPath(_bankName)));
        }
        public void UpdateBranchName(string branchName)
        {
           
            this.Click(By.XPath(_branchName));
            this.Type(branchName, By.XPath(_branchName));
        }
        public void UpdateSortCode(string sortCode)
        {
           
            this.Click(By.XPath(_sortCode));
            this.Type(sortCode, By.XPath(_sortCode));
        }
        public void UpdateAccountNumber(string accountNumber)
        {
           
            this.Click(By.XPath(_accountNumber));
            this.Type(accountNumber, By.XPath(_accountNumber));
        }
        public void UpdateAccountName(string accountName)
        {
           
            this.Click(By.XPath(_accountName));
            this.Type(accountName, By.XPath(_accountName));
        }
        public void UpdateBuildingSociety(string buildingSociety)
        {
           
            this.Click(By.XPath(_buildingSociety));
            this.Type(buildingSociety, By.XPath(_buildingSociety));
        }
        public void ClickSaveBankDetails()
        {
           
            this.Click(By.XPath(_saveBankDetails));
        }

        private WebDriverWait getDriverWait()
        {
            return new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(Constants.DefaultWaitTime));
        }

    }
}
