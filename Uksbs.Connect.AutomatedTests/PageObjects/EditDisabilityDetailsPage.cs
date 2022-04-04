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
    public class EditDisabilityDetailsPage : BasePage, IClassFixture<SeleniumDriver>
    {
        private readonly BasePage _basePage;
        private readonly IWebDriver webDriver;
        
        private readonly ScenarioContext _scenarioContext;

        private readonly string _disablityStatus = "//select[contains(@aria-labelledby,'mydisability-disability_status')]";
        private readonly string _reason1 = "//select[contains(@aria-labelledby,'mydisability-reason-1')]";
        private readonly string _reason2 = "//select[contains(@aria-labelledby,'mydisability-reason-2')]";
        private readonly string _reason3 = "//select[contains(@aria-labelledby,'mydisability-reason-3')]";
        private readonly string _grantAccessToManager = "//select[contains(@aria-labelledby,'mydisability-grant')]";
        private readonly string _riskAssessment = "//select[contains(@aria-labelledby,'mydisability-risk')]";
        private readonly string _reasonOther1 = "//input[contains(@aria-labelledby,'mydisability-other-1')]";
        private readonly string _specialRequirement1 = "//input[contains(@aria-labelledby,'mydisability-special-1')]";
        private readonly string _reasonOther2 = "//input[contains(@aria-labelledby,'mydisability-other-2')]";
        private readonly string _specialRequirement2 = "//input[contains(@aria-labelledby,'mydisability-special-2')]";
        private readonly string _reasonOther3 = "//input[contains(@aria-labelledby,'mydisability-other-3')]";
        private readonly string _specialRequirement3 = "//input[contains(@aria-labelledby,'mydisability-special-3')]";
        private readonly string _saveDisabilityDetails = "//div[@aria-label ='My Disability Details Save']";

        public EditDisabilityDetailsPage(IWebDriver webDriver, ScenarioContext scenarioContext) : base(webDriver)
        {
            this.webDriver = webDriver;
            
            _scenarioContext = scenarioContext;
        }


        public void SelectDisabilityStatus(string disabilityStatus)
        {
           
            this.SelectFromDropdown(disabilityStatus, (By.XPath(_disablityStatus)));
        }
        public void SelectReason1(string reason1)
        {
           
            this.SelectFromDropdown(reason1, (By.XPath(_reason1)));
        }
        public void SelectReason2(string reason2)
        {
           
            this.SelectFromDropdown(reason2, (By.XPath(_reason2)));
        }
        public void SelectReason3(string reason3)
        {
           
            this.SelectFromDropdown(reason3, (By.XPath(_reason3)));
        }
        public void SelectGrantAccessToManager(string grantAccessToManager)
        {
           
            this.SelectFromDropdown(grantAccessToManager, (By.XPath(_grantAccessToManager)));
        }
        public void SelectRiskAssessment(string riskAssessment)
        {
           
            this.SelectFromDropdown(riskAssessment, (By.XPath(_riskAssessment)));
        }
        public void UpdateReasonOther1(string reasonOther1)
        {
           
            this.Click(By.XPath(_reasonOther1));
            this.Type(reasonOther1, By.XPath(_reasonOther1));
        }
        public void UpdateSpecialRequirements1(string specialReqmt1)
        {
           
            this.Click(By.XPath(_specialRequirement1));
            this.Type(specialReqmt1, By.XPath(_specialRequirement1));
        }
        public void UpdateReasonOther2(string reasonOther2)
        {
           
            this.Click(By.XPath(_reasonOther2));
            this.Type(reasonOther2, By.XPath(_reasonOther2));
        }
        public void UpdateSpecialRequirements2(string specialReqmt2)
        {
           
            this.Click(By.XPath(_specialRequirement2));
            this.Type(specialReqmt2, By.XPath(_specialRequirement2));
        }
        public void UpdateReasonOther3(string reasonOther3)
        {
           
            this.Click(By.XPath(_reasonOther3));
            this.Type(reasonOther3, By.XPath(_reasonOther3));
        }
        public void UpdateSpecialRequirements3(string specialReqmt3)
        {
           
            this.Click(By.XPath(_specialRequirement3));
            this.Type(specialReqmt3, By.XPath(_specialRequirement3));
        }
        public void ClickSaveDisabilityDetails()
        {
           
            this.Click(By.XPath(_saveDisabilityDetails));
        }

        private WebDriverWait getDriverWait()
        {
            return new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(Constants.DefaultWaitTime));
        }
    }
}
