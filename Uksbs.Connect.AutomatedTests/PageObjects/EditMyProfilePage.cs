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
    public class EditMyProfilePage : BasePage, IClassFixture<SeleniumDriver>
    {
        private readonly IWebDriver webDriver;
        
        private readonly ScenarioContext _scenarioContext;

        private readonly string _editMyProfile = "//oj-button[@id='profile-summary-edit-btn']//div[@aria-label='Edit My Profile']";
        private readonly string _selectTitle = "//*[@id='myprofile-tile-title-field']";
        private readonly string _firstName = "//input[contains(@id,'firstname')]";
        private readonly string _lastName = "//input[contains(@id,'lastname')]";
        private readonly string _selectMaritalStatus = "//select[@aria-labelledby='profile_marital_status_label']";
        private readonly string _effectiveDate = "//input[@aria-label='Effective Date']";
        private readonly string _saveButton = "//div[@aria-label ='My Profile Save']";
        private readonly string _futureDateMessage = "//*[@id='myprofile-myprofile-tile-message']/div";
        private readonly string _selectAddressType = "//*[@id='filmStrip']//select[contains(@data-bind,'addressTypes')]";
        private readonly string _selectCounty = "//*[@id='filmStrip']//select[contains(@data-bind,'countyTypes')]";
        private readonly string _town = "//*[@id='filmStrip']//input[contains(@data-bind,'town')]";
        private readonly string _addressLine1 = "//*[@id='filmStrip']//input[contains(@data-bind,'address_line1')]";
        private readonly string _addressLine2 = "//*[@id='filmStrip']//input[contains(@data-bind,'address_line2')]";
        private readonly string _addressLine3 = "//*[@id='filmStrip']//input[contains(@data-bind,'address_line3')]";
        private readonly string _postCode = "//*[@id='filmStrip']//input[contains(@data-bind,'postal_code')]";
        private readonly string _saveAddress = "//div[@aria-label ='My Addresses Save']";
        private readonly string _addNewAddress = "//oj-button[@title='Add New Address']/button";
        private readonly string _addressStartDate = "//*[@id='myprofile-myaddressdetails-start-date|input']";
        private readonly string _defaultAddressCheckbox = "//input[@type='checkbox' and @aria-label='Make default address']";
        private readonly string _removeNewAddress = "//oj-button[@title='Remove Address']/button";

        public EditMyProfilePage(IWebDriver webDriver, ScenarioContext scenarioContext) : base(webDriver)
        {
            this.webDriver = webDriver;
            
            _scenarioContext = scenarioContext;
        }

        public void ClickEditMyProfile()
        {
           
            this.Click(By.XPath(_editMyProfile));
        }

        public void SelectTitle(string title)
        {
           
            this.SelectFromDropdown(title, (By.XPath(_selectTitle)));
        }

        public void UpdateFirstName(string firstName)
        {
           
            this.Click(By.XPath(_firstName));
            this.Type(firstName, (By.XPath(_firstName)));
        }
        public void UpdateLastName(string lastName)
        {           
            this.Click(By.XPath(_lastName));
            this.Type(lastName, (By.XPath(_lastName)));
        }
        public void VerifyFutureDatePendingValidation()
        {
            var actualValue = GetFutureDatePendingValidation();

            var expectedValue = "A future-dated change is pending for this data and the record is locked. Please wait for the change to be activated, or alternatively contact HR & Payroll via iSupport";

            Assert.Equal(expectedValue, actualValue);
        }
        public string GetFutureDatePendingValidation()
        {
            this.Find(By.XPath(_futureDateMessage));
            string result = FindElementXPath(_futureDateMessage);
            return result;
        }
        public void SelectMaritalStatus(string maritalStatus)
        {
           
            this.SelectFromDropdown(maritalStatus, (By.XPath(_selectMaritalStatus)));
        }
        public void UpdateEffectiveDate(string effectiveDate)
        {
           
            this.Click(By.XPath(_effectiveDate));
            this.Type(effectiveDate, (By.XPath(_effectiveDate)));
            this.ClickEscape(By.XPath(_effectiveDate));
        }
        public void ClickSaveProfile()
        {
           
            this.Click(By.XPath(_saveButton));
        }

        public void ClickAddNewAddress()
        {
           
            this.Click(By.XPath(_addNewAddress));
        }
        public void SelectAddressType(string addressType)
        {
           
            this.SelectFromDropdown(addressType, (By.XPath(_selectAddressType)));
        }

        public void UpdateTown(string town)
        {
           
            this.Click(By.XPath(_town));
            this.Type(town, (By.XPath(_town)));
        }
        public void UpdateAddressLine1(string addressLine1)
        {
           
            this.Click(By.XPath(_addressLine1));
            this.Type(addressLine1, (By.XPath(_addressLine1)));
        }
        public void UpdateAddressLine2(string addressLine2)
        {
           
            this.Click(By.XPath(_addressLine2));
            this.Type(addressLine2, (By.XPath(_addressLine2)));
        }
        public void UpdateAddressLine3(string addressLine3)
        {
           
            this.Click(By.XPath(_addressLine3));
            this.Type(addressLine3, (By.XPath(_addressLine3)));
        }

        public void SelectCounty(string county)
        {
           
            this.SelectFromDropdown(county, (By.XPath(_selectCounty)));
        }

        public void UpdatePostCode(string postCode)
        {
           
            this.Click(By.XPath(_postCode));
            this.Type(postCode, (By.XPath(_postCode)));
        }

        public void AddStartDate(string startDate)
        {
           
            this.Click(By.XPath(_addressStartDate));
            this.Type(startDate, (By.XPath(_addressStartDate)));
            this.ClickEscape(By.XPath(_addressStartDate));
        }

        public void ClickDefaultAddressCheckbox()
        {
           
            this.Click(By.XPath(_defaultAddressCheckbox));
        }
        public void NavigateAddressPages(int pageNo)
        {
            var addressPageXPath = "//*[@id='myprofile-myaddressdetails-paging-control']//*[@title='Go To Page " + pageNo + "']";
           
            this.Click(By.XPath(addressPageXPath));
        }
        public void ClickSaveAddress()
        {
           
            this.Click(By.XPath(_saveAddress));
        }

        public void ClickRemoveAddress()
        {
           
            this.Click(By.XPath(_removeNewAddress));
        }

        private WebDriverWait getDriverWait()
        {
            return new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(Constants.DefaultWaitTime));
        }

    }
}
