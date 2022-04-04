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
    public class EditContactDetailsPage : BasePage, IClassFixture<SeleniumDriver>
    {
        private readonly BasePage _basePage;
        private readonly IWebDriver webDriver;
        
        private readonly ScenarioContext _scenarioContext;

        private readonly string _addNewContactDetails = "//oj-button[@title='Add New Contact Detail']/button";
        private readonly string _saveContactDetails = "//div[@aria-label='My Phone Numbers Save']";

        public EditContactDetailsPage(IWebDriver webDriver, ScenarioContext scenarioContext) : base(webDriver)
        {
            this.webDriver = webDriver;
            
            _scenarioContext = scenarioContext;
        }

        public void ClickAddNewContactDetails()
        {
           
            this.Click(By.XPath(_addNewContactDetails));
        }
        public void AddContactInput(int position, string contact)
        {
            var addContactInput = "//div[contains(@class,'oj-filmstrip-item-container')][position()=" + position + "]//input[@aria-label='Contact Details']";
           
            this.Click(By.XPath(addContactInput));
            this.Type(contact, (By.XPath(addContactInput)));
        }

        public void SelectContactMethod(int position, string contactMethod)
        {
            var selectContactMethod = "//div[contains(@class,'oj-filmstrip-item-container')][position()=" + position + "]//select[@id='myprofile-myphonedetails-phone-type']";
           
            this.SelectFromDropdown(contactMethod, (By.XPath(selectContactMethod)));
        }
        public void RemoveContactDetails(int position)
        {
            var removeContact = "//div[contains(@class,'oj-filmstrip-item-container')][position()=" + position + "]//button[@title='Remove Contact Details']";
           
            this.Click(By.XPath(removeContact));
        }
        public void SaveContactDetails()
        {
           
            this.Click(By.XPath(_saveContactDetails));
        }

        private WebDriverWait getDriverWait()
        {
            return new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(Constants.DefaultWaitTime));
        }

    }
}
