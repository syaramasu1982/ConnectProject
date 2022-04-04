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
    public class OracleHomepagePage : BasePage, IClassFixture<SeleniumDriver>
    {
        private readonly BasePage _basePage;
        private readonly IWebDriver webDriver;
        
        private readonly ScenarioContext _scenarioContext;

        private readonly string _viewMyResponsibilities = "//span[contains(text(),'VIEW MY RESPONSIBILITIES')]";
        private readonly string _oracleHomePageTitle = "//h1[contains(text(),'Oracle Applications Home Page')]";
        private readonly string _ebsMainMenu = "//h2[contains(text(),'Main Menu')]";
        public OracleHomepagePage(IWebDriver webDriver, ScenarioContext scenarioContext) : base(webDriver)
        {
            this.webDriver = webDriver;
            
            //  _basePage = new BasePage(webDriver);
            _scenarioContext = scenarioContext;
        }

        public void ClickViewMyResponsibilities()
        {
           
            this.Click(By.XPath(_viewMyResponsibilities));
        }
        public void ValidateOracleHomePage()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_oracleHomePageTitle)));

            Assert.True(this.IsElementPresent(By.XPath(_oracleHomePageTitle)));
            Assert.True(this.IsElementPresent(By.XPath(_ebsMainMenu)));
        }

        private WebDriverWait getDriverWait()
        {
            return new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(Constants.DefaultWaitTime));
        }

    }
}
