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
    public class AccessP60sPage : BasePage, IClassFixture<SeleniumDriver>
    {
        private readonly IWebDriver webDriver;
        
        private readonly ScenarioContext _scenarioContext;

        private readonly string _mostRecentP60 = "//div[@class='myp60-summary-list-container']/div[1]//div[contains(@class,'p60-summary-button-text')][1]";
        private readonly string _clickViewAllP60 = "//div[@class='myp60-summary-btn-container oj-flex']//div/span[contains(text(),'VIEW ALL')]";
        private readonly string _oldestP60 = "//div[@id='p60List']//div[contains(text(),'2018')][1]";
        public AccessP60sPage(IWebDriver webDriver, ScenarioContext scenarioContext) : base(webDriver)
        {
            this.webDriver = webDriver;
            
            _scenarioContext = scenarioContext;
        }

        public void ClickMostRecentP60()
        {           
            this.Click(By.XPath(_mostRecentP60));
        }
        public void ClickViewAllP60()
        {           
            this.Click(By.XPath(_clickViewAllP60));
        }
        public void ClickOldestP60()
        {           
            this.Click(By.XPath(_oldestP60));
        }

        private WebDriverWait getDriverWait()
        {
            return new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(Constants.DefaultWaitTime));
        }
    }

}
