using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Uksbs.Connect.AutomatedTests.Common;
using Uksbs.Connect.AutomatedTests.SpecFlowFactory;
using Uksbs.Connect.AutomatedTests.PageObjects;

namespace Uksbs.Connect.AutomatedTests.StepDefinitions
{
    [Binding]
    public sealed class EditMyEmergencyContactSteps
    {
        private SeleniumContext seleniumContext;
        private IWebDriver webDriver;
        private ScenarioContext _scenarioContext;

        

        private EditMyEmergencyContactsPage _editMyEmergencyContactsPage;

        public EditMyEmergencyContactSteps(SeleniumContext seleniumContext, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            //save the context so you can use it in your tests
            this.seleniumContext = seleniumContext;
            this.webDriver = seleniumContext.WebDriver;

            

            // Creating selenium specific instance for login page
            _editMyEmergencyContactsPage = new EditMyEmergencyContactsPage(webDriver, _scenarioContext);
        }


        [Given(@"I click Add new emergency contact")]
        public void GivenIClickAddNewEmergencyContact()
        {
            _editMyEmergencyContactsPage.ClickAddNewEmergencyContact();
        }


        [Given(@"I select  emergency contact Title as ""(.*)""")]
        public void GivenISelectEmergencyContactTitleAs(string title)
        {
            _editMyEmergencyContactsPage.SelectECTitle(title);
        }

        [Given(@"I update emergency contact first name as ""(.*)""")]
        public void GivenIUpdateEmergencyContactFirstNameAs(string firstName)
        {
            _editMyEmergencyContactsPage.UpdateECFirstName(firstName);
        }

        [Given(@"I update emergency contact last name as ""(.*)""")]
        public void GivenIUpdateEmergencyContactLastNameAs(string lastName)
        {
            _editMyEmergencyContactsPage.UpdateECLastName(lastName);
        }

        [Given(@"I select emergency contact relationship as ""(.*)""")]
        public void GivenISelectEmergencyContactRelationshipAs(string relationship)
        {
            _editMyEmergencyContactsPage.SelectECRelationship(relationship);
        }

        [Given(@"I update emergency contact home phone as ""(.*)""")]
        public void GivenIUpdateEmergencyContactHomePhoneAs(int homePhone)
        {
            _editMyEmergencyContactsPage.UpdateECHomePhone(homePhone.ToString());
        }

        [Given(@"I update emergency contact mobile phone as ""(.*)""")]
        public void GivenIUpdateEmergencyContactMobilePhoneAs(int mobilePhone)
        {
            _editMyEmergencyContactsPage.UpdateECMobilePhone(mobilePhone.ToString());
        }

        [Given(@"I update emergency contact work phone as ""(.*)""")]
        public void GivenIUpdateEmergencyContactWorkPhoneAs(int workPhone)
        {
            _editMyEmergencyContactsPage.UpdateECWorkPhone(workPhone.ToString());
        }

        [Given(@"I check primary contact")]
        public void GivenICheckPrimaryContact()
        {
            _editMyEmergencyContactsPage.ClickECPrimaryContact();
        }

        [Given(@"I uncheck use my address for this person")]
        public void GivenIUncheckUseMyAddressForThisPerson()
        {
            _editMyEmergencyContactsPage.ClickECUseMyAddress();
        }

        [Given(@"I can update emergency contact address line (.*) as ""(.*)""")]
        public void GivenICanUpdateEmergencyContactAddressLineAs(int line, string addressLine)
        {

            if (line == 1)
            {
                _editMyEmergencyContactsPage.AddECAddressLine1(addressLine);
            }
            else if (line == 2)
            {
                _editMyEmergencyContactsPage.AddECAddressLine2(addressLine);
            }
            else
            {
                _editMyEmergencyContactsPage.AddECAddressLine3(addressLine);
            }
        }

        [Given(@"I can update emergency contact town as ""(.*)""")]
        public void GivenICanUpdateEmergencyContactTownAs(string town)
        {
            _editMyEmergencyContactsPage.AddECTown(town);
        }

        [Given(@"I select emergency contact county as ""(.*)""")]
        public void GivenISelectEmergencyContactCountyAs(string ecCounty)
        {
            _editMyEmergencyContactsPage.SelectECCounty(ecCounty);
        }

        [Given(@"I can update emergency contact post code as ""(.*)""")]
        public void GivenICanUpdateEmergencyContactPostCodeAs(string postCode)
        {
            _editMyEmergencyContactsPage.AddECPostCode(postCode);
        }

        [Then(@"I can save emergency contact details")]
        public void ThenICanSaveEmergencyContactDetails()
        {
            _editMyEmergencyContactsPage.ClickECSave();
        }

    }
}
