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

namespace Uksbs.Connect.AutomatedTests.PageObjects
{
    public class LoginDemoPage :BasePage, IClassFixture<SeleniumDriver>
    {
        private readonly BasePage _basePage;
        private readonly IWebDriver webDriver;

        private readonly ScenarioContext _scenarioContext;



        public LoginDemoPage(IWebDriver webDriver, ScenarioContext scenarioContext) : base(webDriver)
        {
            this.webDriver = webDriver;

            _scenarioContext = scenarioContext;
        }

        public void LaunchApplication()
        {
            string url = "https://ebs.sit.ssc.rcuk.ac.uk/OA_HTML/RF.jsp?function_id=28716&resp_id=-1&resp_appl_id=-1&security_group_id=0&lang_code=US&oas=iOLLTnSfKdLU-3G5C54FsA..&params=bzlXt873p9iCQTeHTpuI-Q";
            webDriver.Navigate().GoToUrl(url);
            this.LoadEntirePage();
        }

        public void EnterUserName(string username)
        {
            this.Click(By.XPath("//input[@id='unamebean']"));
            this.Type(username,By.XPath("//input[@id='unamebean']"));
        }
        public void EntePassword(string password)
        {
            this.Click(By.XPath("//input[@id='pwdbean']"));
            this.Type(password, By.XPath("//input[@id='pwdbean']"));
        }
        public void ClickLoginButton()
        {
            this.Click(By.XPath("//button[@id='SubmitButton']"));            
        }

        public void ValidateDashBoard()
        {
            string abc = "//h1[contains(text(),'Oracle Application')]";
            this.LoadEntirePage();
            this.WaitUntilVisible(By.XPath(abc));
            Assert.True(this.IsElementPresent(By.XPath(abc)));           
        }
    }
   
}
