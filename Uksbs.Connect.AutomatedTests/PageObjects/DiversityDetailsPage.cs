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
    public class DiversityDetailsPage : BasePage, IClassFixture<SeleniumDriver>
    {
        private readonly BasePage _basePage;
        private readonly IWebDriver webDriver;
        
        private readonly ScenarioContext _scenarioContext;

        private readonly string _gender = "//select[contains(@aria-labelledby,'mydiversity-gender')]";
        private readonly string _nationality = "//select[contains(@aria-labelledby,'nationality')]";
        private readonly string _nationalitySecondary = "//select[contains(@aria-labelledby,'nationality-secondary')]";
        private readonly string _nationalityIdentity = "//select[contains(@aria-labelledby,'mydiversity-national-identity')]";
        private readonly string _ethnicity = "//select[contains(@aria-labelledby,'mydiversity-ethnicity')]";
        private readonly string _sexualOrientation = "//select[contains(@aria-labelledby,'mydiversity-sexual')]";
        private readonly string _religiousbelief = "//select[contains(@aria-labelledby,'mydiversity-religious')]";
        private readonly string _saveDiversityDetails = "//div[@aria-label ='My Diversity Details Save']";
        public DiversityDetailsPage(IWebDriver webDriver, ScenarioContext scenarioContext) : base(webDriver)
        {
            this.webDriver = webDriver;
            
            _scenarioContext = scenarioContext;
        }

        public void SelectGender(string gender)
        {
           
            this.SelectFromDropdown(gender, (By.XPath(_gender)));
        }
        public void SelectNationality(string nationality)
        {
           
            this.SelectFromDropdown(nationality, (By.XPath(_nationality)));
        }
        public void SelectNationalitySecondary(string nationalitySecondary)
        {
           
            this.SelectFromDropdown(nationalitySecondary, (By.XPath(_nationalitySecondary)));
        }
        public void SelectNationalIdentity(string nationalityIdentity)
        {
           
            this.SelectFromDropdown(nationalityIdentity, (By.XPath(_nationalityIdentity)));
        }
        public void SelectEthnicity(string ethnicity)
        {
           
            this.SelectFromDropdown(ethnicity, (By.XPath(_ethnicity)));
        }
        public void SelectSexualOrientation(string sexualOrientation)
        {
           
            this.SelectFromDropdown(sexualOrientation, (By.XPath(_sexualOrientation)));
        }
        public void SelectReligiousBelief(string religiousBelief)
        {
           
            this.SelectFromDropdown(religiousBelief, (By.XPath(_religiousbelief)));
        }
        public void ClickSaveDiversityDetails()
        {
           
            this.Click(By.XPath(_saveDiversityDetails));
        }
        private WebDriverWait getDriverWait()
        {
            return new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(Constants.DefaultWaitTime));
        }
    }
}
