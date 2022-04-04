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
    public sealed class EditMyBankDetailsSteps
    {
        private SeleniumContext seleniumContext;
        private IWebDriver webDriver;
        private ScenarioContext _scenarioContext;

        

        private EditMyBankDetailsPage _editMyBankDetailsPage;

        public EditMyBankDetailsSteps(SeleniumContext seleniumContext, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            //save the context so you can use it in your tests
            this.seleniumContext = seleniumContext;
            this.webDriver = seleniumContext.WebDriver;

            

            // Creating selenium specific instance for login page
            _editMyBankDetailsPage = new EditMyBankDetailsPage(webDriver, _scenarioContext);
        }


        [Given(@"I select bank name as ""(.*)""")]
        public void GivenISelectBankNameAs(string bankName)
        {
            _editMyBankDetailsPage.SelectBankName(bankName);
        }

        [Given(@"I update bank barnch as ""(.*)""")]
        public void GivenIUpdateBankBarnchAs(string bankBranch)
        {
            _editMyBankDetailsPage.UpdateBranchName(bankBranch);
        }

        [Given(@"I update sort code as ""(.*)""")]
        public void GivenIUpdateSortCodeAs(string sortCode)
        {
            _editMyBankDetailsPage.UpdateSortCode(sortCode);
        }

        [Given(@"I update account number as ""(.*)""")]
        public void GivenIUpdateAccountNumberAs(int accountNumber)
        {
            _editMyBankDetailsPage.UpdateAccountNumber(accountNumber.ToString());
        }

        [Given(@"I update account name as ""(.*)""")]
        public void GivenIUpdateAccountNameAs(string accountName)
        {
            _editMyBankDetailsPage.UpdateAccountName(accountName);
        }

        [Given(@"I update bulidng society number as ""(.*)""")]
        public void GivenIUpdateBulidngSocietyNumberAs(int buildingSocietyNumber)
        {
            _editMyBankDetailsPage.UpdateBuildingSociety(buildingSocietyNumber.ToString());
        }

        [Given(@"I save my bank details")]
        public void GivenISaveMyBankDetails()
        {
            _editMyBankDetailsPage.ClickSaveBankDetails();
        }

    }
}
