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
    public class GDPRPage : BasePage, IClassFixture<SeleniumDriver>
    {
        private readonly IWebDriver webDriver;
        
        private readonly ScenarioContext _scenarioContext;

        private readonly string _GDPRPrivacyStmt = "//*[@id='oj-collapsible-gdprC1-header']/a";
        private readonly string _privacyNotice = "//a[@id='privacy-notice']";
        private readonly string _privacyStmtNotice = "//*[@id='gdprC1-text']";
        public GDPRPage(IWebDriver webDriver, ScenarioContext scenarioContext) : base(webDriver)
        {
            this.webDriver = webDriver;
            
            _scenarioContext = scenarioContext;
        }

        public void ClickGDPRPrivacy()
        {
           
            this.Click(By.XPath(_GDPRPrivacyStmt));
        }

        public void ClickPrivacyNotice()
        {           
            this.Click(By.XPath(_privacyNotice));
        }
        public void VerifyGDPRPrivacyNotice()
        {
            var expectedPrivacyStmtNotice = "UK SBS respects your privacy and we want you to know exactly how your personal data is collected and used. As part of our commitment to protecting your data you can be confident:\r\nWe will keep your data safe\r\nYour data will not be sold onwards\r\nWe will only share your data where there is a legitimate service requirement to do so or, where you have provided us with explicit consent\r\nFor further information on how UK SBS will use and manage your personal data please see our Privacy Notice";
            var actualPrivacyStmtNotice = GetPrivacyStmtNotice();
            Assert.Equal(expectedPrivacyStmtNotice, actualPrivacyStmtNotice);
        }
        public string GetPrivacyStmtNotice()
        {

            this.Find(By.XPath(_privacyStmtNotice));
            string result = FindElementXPath(_privacyStmtNotice);
            return result;
        }

        private WebDriverWait getDriverWait()
        {
            return new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(Constants.DefaultWaitTime));
        }
    }
}
