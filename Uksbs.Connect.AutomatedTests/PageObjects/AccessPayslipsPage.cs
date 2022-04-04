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
    public class AccessPayslipsPage : BasePage, IClassFixture<SeleniumDriver>
    {
        private readonly BasePage _basePage;
        private readonly IWebDriver webDriver;
        
        private readonly ScenarioContext _scenarioContext;

        private readonly string _mostRecentPayslip = "//div[@class='mypayslips-summary-list-container']/div[1]//div[contains(@class,'paypayslips')][1]";
        private readonly string _clickViewAllPayslips = "//div[@class='mypayslips-summary-btn-container oj-flex']//div/span[contains(text(),'VIEW ALL')]";
        private readonly string _oldestPayslip = "//div[@id='payslipList'][last()]/oj-button";
        public AccessPayslipsPage(IWebDriver webDriver, ScenarioContext scenarioContext) : base(webDriver)
        {
            this.webDriver = webDriver;
            
            _scenarioContext = scenarioContext;
        }

        public void ClickMostRecentPayslip()
        {
           
            this.Click(By.XPath(_mostRecentPayslip));
        }
        public void ClickViewAllPayslips()
        {
           
            this.Click(By.XPath(_clickViewAllPayslips));
        }
        public void ClickOldestPayslip()
        {
           
            this.Click(By.XPath(_oldestPayslip));
        }

        private WebDriverWait getDriverWait()
        {
            return new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(Constants.DefaultWaitTime));
        }
    }
}
