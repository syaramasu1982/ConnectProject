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
    public class EditMyEmergencyContactsPage : BasePage, IClassFixture<SeleniumDriver>
    {
        private readonly IWebDriver webDriver;
        
        private readonly ScenarioContext _scenarioContext;

        private readonly string _addEmergencyContact = "//oj-button[@title='Add new emergency contact']/button";
        private readonly string _selectMyEmergencyTitle = "//select[@aria-labelledby='myprofile-myemergencycontacts-title-label']";
        private readonly string _firstNameEmergency = "//input[contains(@aria-labelledby,'first-name')]";
        private readonly string _lastNameEmergency = "//input[contains(@aria-labelledby,'last-name')]";
        private readonly string _relationshipEmergency = "//select[contains(@aria-labelledby,'relationship')]";
        private readonly string _homePhoneEmergency = "//input[contains(@aria-labelledby,'home-phone')]";
        private readonly string _mobilePhoneEmergency = "//input[contains(@aria-labelledby,'mobile-phone')]";
        private readonly string _workPhoneEmergency = "//input[contains(@aria-labelledby,'work-phone')]";
        private readonly string _primaryContactEmergency = "//input[contains(@aria-labelledby,'primary-contact')]";
        private readonly string _useMyAddressEmergency = "//input[@class='myemergencycontacts-shared-residence-input' and @checked]";
        private readonly string _saveEmergencyContacts = "//div[@aria-label ='My Emergency Contacts Save']//ancestor::button";
        private readonly string _addressLine1Emergency = "//input[contains(@aria-labelledby,'myemergencycontacts-address-line1')]";
        private readonly string _addressLine2Emergency = "//input[contains(@aria-labelledby,'myemergencycontacts-address-line2')]";
        private readonly string _addressLine3Emergency = "//input[contains(@aria-labelledby,'myemergencycontacts-address-line3')]";
        private readonly string _townEmergency = "//input[contains(@aria-labelledby,'myemergencycontacts-town')]";
        private readonly string _countyEmergency = "//select[contains(@aria-labelledby,'myemergencycontacts-county')]";
        private readonly string _postCodeEmergency = "//input[contains(@aria-labelledby,'myemergencycontacts-postcode')]";

        public EditMyEmergencyContactsPage(IWebDriver webDriver, ScenarioContext scenarioContext) : base(webDriver)
        {
            this.webDriver = webDriver;
            
            _scenarioContext = scenarioContext;
        }


        public void ClickAddNewEmergencyContact()
        {
           
            this.Click(By.XPath(_addEmergencyContact));
        }

        public void SelectECTitle(string title)
        {
           
            this.SelectFromDropdown(title, (By.XPath(_selectMyEmergencyTitle)));
        }
        public void UpdateECFirstName(string firstName)
        {
           
            this.Click(By.XPath(_firstNameEmergency));
            this.Type(firstName, (By.XPath(_firstNameEmergency)));
        }
        public void UpdateECLastName(string lastName)
        {
           
            this.Click(By.XPath(_lastNameEmergency));
            this.Type(lastName, (By.XPath(_lastNameEmergency)));
        }
        public void SelectECRelationship(string relationship)
        {
           
            this.SelectFromDropdown(relationship, (By.XPath(_relationshipEmergency)));
        }
        public void UpdateECHomePhone(string homePhone)
        {
           
            this.Click(By.XPath(_homePhoneEmergency));
            this.Type(homePhone, By.XPath(_homePhoneEmergency));
        }
        public void UpdateECMobilePhone(string mobilePhone)
        {
           
            this.Click(By.XPath(_mobilePhoneEmergency));
            this.Type(mobilePhone, By.XPath(_mobilePhoneEmergency));
        }
        public void UpdateECWorkPhone(string workPhone)
        {
           
            this.Click(By.XPath(_workPhoneEmergency));
            this.Type(workPhone, By.XPath(_workPhoneEmergency));
        }
        public void ClickECPrimaryContact()
        {           
            this.Click(By.XPath(_primaryContactEmergency));
        }
        public void ClickECUseMyAddress()
        {
            var isChecked = this.IsElementPresent(By.XPath(_useMyAddressEmergency));
            if (isChecked)
            {
                this.Click(By.XPath(_useMyAddressEmergency));
            }
            
        }
        public void AddECAddressLine1(string addressLine1)
        {
           
            this.Click(By.XPath(_addressLine1Emergency));
            this.Type(addressLine1, By.XPath(_addressLine1Emergency));
        }
        public void AddECAddressLine2(string addressLine2)
        {
           
            this.Click(By.XPath(_addressLine2Emergency));
            this.Type(addressLine2, By.XPath(_addressLine2Emergency));
        }
        public void AddECAddressLine3(string addressLine3)
        {
           
            this.Click(By.XPath(_addressLine3Emergency));
            this.Type(addressLine3, By.XPath(_addressLine3Emergency));
        }
        public void AddECTown(string town)
        {
           
            this.Click(By.XPath(_townEmergency));
            this.Type(town, By.XPath(_townEmergency));
        }
        public void SelectECCounty(string ecCounty)
        {
           
            this.SelectFromDropdown(ecCounty, (By.XPath(_countyEmergency)));
        }
        public void AddECPostCode(string postCode)
        {
           
            this.Click(By.XPath(_postCodeEmergency));
            this.Type(postCode, By.XPath(_postCodeEmergency));
        }
        public void ClickECSave()
        {           
            this.Click(By.XPath(_saveEmergencyContacts));
        }

        private WebDriverWait getDriverWait()
        {
            return new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(Constants.DefaultWaitTime));
        }

    }
}
