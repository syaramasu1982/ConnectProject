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
    public class FeedbackVerificationPage : BasePage, IClassFixture<SeleniumDriver>
    {
        private readonly IWebDriver webDriver;
        
        private readonly ScenarioContext _scenarioContext;

        private readonly string _feedbackMessage = "//*[@id='global-body-container']//dashboard-feedback-tile//div[@class='dashboard-feedback-text']";
        private readonly string _uksbsConnectFeedback = "//span[contains(text(),'UK SBS Connect Feedback')]";
        private readonly string _serviceRequestFeedback = "//span[contains(text(),'Service Request Feedback')]";
        public FeedbackVerificationPage(IWebDriver webDriver, ScenarioContext scenarioContext) : base(webDriver)
        {
            this.webDriver = webDriver;
            
            _scenarioContext = scenarioContext;
        }


        public void VerifyFeedbackMessage()
        {
            var expectedFeebbackMessage = "We welcome your feedback on using UK SBS Connect and your experience of using our services.";
            var actualFeebbackMessage = GetFeedbackMessage();
            Assert.Equal(expectedFeebbackMessage, actualFeebbackMessage);
        }
        public string GetFeedbackMessage()
        {
           
            this.Find(By.XPath(_feedbackMessage));
            string result = FindElementXPath(_feedbackMessage);
            return result;
        }
        public void ClickUKSBSConnectFeedback()
        {
           
            this.Click(By.XPath(_uksbsConnectFeedback));
        }
        public void ClickServiceRequestFeedback()
        {
           
            this.Click(By.XPath(_serviceRequestFeedback));
        }

        private WebDriverWait getDriverWait()
        {
            return new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(Constants.DefaultWaitTime));
        }
    }
}
