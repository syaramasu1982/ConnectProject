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
    public class SupportLinksPage : BasePage, IClassFixture<SeleniumDriver>
    {
        private readonly IWebDriver webDriver;
        
        private readonly ScenarioContext _scenarioContext;

        private readonly string _raiseServiceRequest = "//span[contains(text(),'Raise Service Request')]";
        private readonly string _usingUKSBSServices = "//span[contains(text(),'Using UK SBS Services')]";
        private readonly string _guidesToUsingOracle = "//span[contains(text(),'Guides to using Oracle')]";

        public SupportLinksPage(IWebDriver webDriver, ScenarioContext scenarioContext) : base(webDriver)
        {
            this.webDriver = webDriver;
            
            _scenarioContext = scenarioContext;
        }
        public void ClickRaiseServiceRequest()
        {           
            this.Click(By.XPath(_raiseServiceRequest));
        }
        public void ClickUsingUKSBSServices()
        {
           
            this.Click(By.XPath(_usingUKSBSServices));
        }
        public void ClickGuidesToUsingOracle()
        {
           
            this.Click(By.XPath(_guidesToUsingOracle));
        }

        private WebDriverWait getDriverWait()
        {
            return new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(Constants.DefaultWaitTime));
        }
    }
}
