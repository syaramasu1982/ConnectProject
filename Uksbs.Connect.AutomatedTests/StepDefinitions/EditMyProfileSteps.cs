using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Uksbs.Connect.AutomatedTests.Common;
using Uksbs.Connect.AutomatedTests.SpecFlowFactory;
using Uksbs.Connect.AutomatedTests.PageObjects;
using System;
using System.Globalization;

namespace Uksbs.Connect.AutomatedTests.StepDefinitions
{
    [Binding]
    public sealed class EditMyProfileSteps
    {
        private SeleniumContext seleniumContext;
        private IWebDriver webDriver;
        private ScenarioContext _scenarioContext;
        private string _startDate;

        

        private EditMyProfilePage _editMyProfilePage;

        public EditMyProfileSteps(SeleniumContext seleniumContext, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            //save the context so you can use it in your tests
            this.seleniumContext = seleniumContext;
            this.webDriver = seleniumContext.WebDriver;

            

            // Creating selenium specific instance for login page
            _editMyProfilePage = new EditMyProfilePage(webDriver, _scenarioContext);
        }


        [Given(@"I click on edit my profile")]
        public void GivenIClickOnEditMyProfile()
        {
            _editMyProfilePage.ClickEditMyProfile();
        }

        [Given(@"I can update title as ""(.*)""")]
        public void GivenICanUpdateTitleAs(string title)
        {
            _editMyProfilePage.SelectTitle(title);
        }

        [Given(@"I can update first name as ""(.*)""")]
        public void GivenICanUpdateFirstNameAs(string firstName)
        {
            _editMyProfilePage.UpdateFirstName(firstName);
        }

        [Given(@"I can update last name as ""(.*)""")]
        public void GivenICanUpdateLastNameAs(string lastName)
        {
            _editMyProfilePage.UpdateLastName(lastName);

        }

        [Given(@"I can update marital status as ""(.*)""")]
        public void GivenICanUpdateMaritalStatusAs(string maritalStatus)
        {
            _editMyProfilePage.SelectMaritalStatus(maritalStatus);
        }

        [Given(@"I can update effective date as ""(.*)""")]
        public void GivenICanUpdateEffectiveDateAs(string effectiveDate)
        {
            _editMyProfilePage.UpdateEffectiveDate(effectiveDate);
        }

        [Given(@"I click save")]
        public void GivenIClickSave()
        {
            _editMyProfilePage.ClickSaveProfile();
        }

        [Given(@"I verify success message alert as ""(.*)""")]
        public void GivenIVerifySuccessMessageAlertAs(string ExpectedValue)
        {
            ScenarioContext.Current.Pending();

        }

        [Given(@"I verify future date validation")]
        public void GivenIVerifyFutureDateValidation()
        {
            _editMyProfilePage.VerifyFutureDatePendingValidation();
        }

        [Given(@"I update the effective date to past date")]
        public void GivenIUpdateTheEffectiveDateToPastDate()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I can select address type as ""(.*)""")]
        public void GivenICanSelectAddressTypeAs(string addressType)
        {
            _editMyProfilePage.SelectAddressType(addressType);
        }

        [Given(@"I can update address line (.*) as ""(.*)""")]
        public void GivenICanUpdateAddressLineAs(int line, string addressLine)
        {
            if (line == 1)
            {
                _editMyProfilePage.UpdateAddressLine1(addressLine);
            }
            else if (line == 2)
            {
                _editMyProfilePage.UpdateAddressLine2(addressLine);
            }
            else
            {
                _editMyProfilePage.UpdateAddressLine3(addressLine);
            }
        }


        [Given(@"I can update town as ""(.*)""")]
        public void GivenICanUpdateTownAs(string town)
        {
            _editMyProfilePage.UpdateTown(town);
        }

        [Given(@"I can select county as ""(.*)""")]
        public void GivenICanSelectCountyAs(string countyName)
        {
            _editMyProfilePage.SelectCounty(countyName);
        }

        [Given(@"I select start date as ""(.*)""")]
        public void GivenISelectStartDateAs(string startDate)
        {
            DateTime currentDateTime = DateTime.Now;
            if (startDate.ToUpper().Contains("FUTURE"))
            {
                currentDateTime = currentDateTime.AddDays(35);
                _startDate = currentDateTime.ToString("dd/MM/yyyy", new CultureInfo("en-US"));
            }
            else if (startDate.ToUpper().Contains("PAST"))
            {
                currentDateTime = currentDateTime.AddDays(-35);
                _startDate = currentDateTime.ToString("dd/MM/yyyy", new CultureInfo("en-US"));
            }
            else
            {
                _startDate = currentDateTime.ToString("dd/MM/yyyy", new CultureInfo("en-US"));
            }
            _editMyProfilePage.AddStartDate(_startDate);
        }        

        [Given(@"I add start date in my address as ""(.*)""")]
        public void GivenIAddStartDateInMyAddressAs(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I can update postcode as ""(.*)""")]
        public void GivenICanUpdatePostcodeAs(string postCode)
        {
            _editMyProfilePage.UpdatePostCode(postCode);
        }

        [Given(@"I click address save")]
        public void GivenIClickAddressSave()
        {
            _editMyProfilePage.ClickSaveAddress();
        }

        [Given(@"I click add new address")]
        public void GivenIClickAddNewAddress()
        {
            _editMyProfilePage.ClickAddNewAddress();
        }

        [Given(@"I add start date as ""(.*)""")]
        public void GivenIAddStartDateAs(string startDate)
        {
            DateTime currentDateTime = DateTime.Now;
            if (startDate.ToUpper().Contains("FUTURE"))
            {
                currentDateTime = currentDateTime.AddDays(35);
                _startDate = currentDateTime.ToString("dd.MM.yy", new CultureInfo("en-US"));
            }
            else if (startDate.ToUpper().Contains("PAST"))
            {
                currentDateTime = currentDateTime.AddDays(-35);
                _startDate = currentDateTime.ToString("dd.MM.yy", new CultureInfo("en-US"));
            }
            else
            {
                _startDate = currentDateTime.ToString("dd.MM.yy", new CultureInfo("en-US"));
            }
            _editMyProfilePage.AddStartDate(_startDate);

        }

        [Given(@"I click checkbox to make default address")]
        public void GivenIClickCheckboxToMakeDefaultAddress()
        {
            _editMyProfilePage.ClickDefaultAddressCheckbox();
        }

        [Given(@"I go to secondary address page")]
        public void GivenIGoToSecondaryAddressPage()
        {
            _editMyProfilePage.NavigateAddressPages(2);
        }

        [Given(@"I remove the seondary address")]
        public void GivenIRemoveTheSeondaryAddress()
        {
            _editMyProfilePage.ClickRemoveAddress();
        }




    }
}
