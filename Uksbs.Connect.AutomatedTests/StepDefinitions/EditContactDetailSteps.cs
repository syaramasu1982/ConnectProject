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
    public sealed class EditContactDetailSteps
    {
        private SeleniumContext seleniumContext;
        private IWebDriver webDriver;
        private ScenarioContext _scenarioContext;

        

        private EditContactDetailsPage _editContactDetailsPage;

        public EditContactDetailSteps(SeleniumContext seleniumContext, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            //save the context so you can use it in your tests
            this.seleniumContext = seleniumContext;
            this.webDriver = seleniumContext.WebDriver;

            

            // Creating selenium specific instance for login page
            _editContactDetailsPage = new EditContactDetailsPage(webDriver, _scenarioContext);
        }       
       

        [Given(@"I click add new contact details")]
        public void GivenIClickAddNewContactDetails()
        {
            _editContactDetailsPage.ClickAddNewContactDetails();
        }

        [Given(@"I enter contact details as ""(.*)""")]
        public void GivenIEnterContactDetailsAs(string contact)
        {
            _editContactDetailsPage.AddContactInput(1, contact);
        }

        [Given(@"I select contact method as ""(.*)""")]
        public void GivenISelectContactMethodAs(string contactMethod)
        {
            _editContactDetailsPage.SelectContactMethod(1, contactMethod);
        }

        [Then(@"I click save button")]
        public void ThenIClickSaveButton()
        {
            _editContactDetailsPage.SaveContactDetails();
        }

        [Then(@"I delete the contact details")]
        public void ThenIDeleteTheContactDetails()
        {
            _editContactDetailsPage.RemoveContactDetails(1);
        }

    }
}
