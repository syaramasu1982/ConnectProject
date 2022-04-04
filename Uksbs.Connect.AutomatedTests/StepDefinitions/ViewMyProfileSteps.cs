using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Uksbs.Connect.AutomatedTests.Common;
using Uksbs.Connect.AutomatedTests.SpecFlowFactory;
using Uksbs.Connect.AutomatedTests.PageObjects;
using Xunit;

namespace Uksbs.Connect.AutomatedTests.StepDefinitions
{
    [Binding]
    public sealed class ViewMyProfileSteps
    {
        private SeleniumContext seleniumContext;
        private IWebDriver webDriver;
        private ScenarioContext _scenarioContext;

        

        private ViewMyProfilePage _viewMyProfilePage;

        public ViewMyProfileSteps(SeleniumContext seleniumContext, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            //save the context so you can use it in your tests
            this.seleniumContext = seleniumContext;
            this.webDriver = seleniumContext.WebDriver;

            

            // Creating selenium specific instance for login page
            _viewMyProfilePage = new ViewMyProfilePage(webDriver, _scenarioContext);
        }


        [Then(@"I check my username and position")]
        public void ThenICheckMyUsernameAndPosition(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _viewMyProfilePage.VerifyProfileNameAndPosition((string)data.FullName, (string)data.Position);
        }

        [Then(@"I see my full name as ""(.*)""")]
        public void ThenISeeMyFullNameAs(string ExpectedValue)
        {
            var ActualValue = _viewMyProfilePage.GetProfileFullName();
            Assert.Equal(ExpectedValue, ActualValue);
        }

        [Then(@"I see my position as ""(.*)""")]
        public void ThenISeeMyPositionAs(string ExpectedValue)
        {
            var ActualValue = _viewMyProfilePage.GetProfilePositionName();
            Assert.Equal(ExpectedValue, ActualValue);
        }

        [Then(@"I click on view profile")]
        public void ThenIClickOnViewProfile()
        {
            _viewMyProfilePage.ClickViewMyProfile();
        }

        [Then(@"I see marital status as ""(.*)""")]
        public void ThenISeeMaritalStatusAs(string ExpectedValue)
        {
            var ActualValue = _viewMyProfilePage.GetMaritalStatus();

           // Assert.Equal(ExpectedValue, ActualValue);
        }

        [Then(@"I see ni number as ""(.*)""")]
        public void ThenISeeNiNumberAs(string ExpectedValue)
        {
            var ActualValue = _viewMyProfilePage.GetNINumber();
            Assert.Equal(ExpectedValue, ActualValue);
        }

        [Then(@"I see dob as ""(.*)""")]
        public void ThenISeeDobAs(string ExpectedValue)
        {
            var ActualValue = _viewMyProfilePage.GetDOB();
            Assert.Equal(ExpectedValue, ActualValue);
        }

        [Then(@"I see employee no as ""(.*)""")]
        public void ThenISeeEmployeeNoAs(int ExpectedValue)
        {
            var ActualValue = _viewMyProfilePage.GetEmpNumber();
            Assert.Equal(ExpectedValue.ToString(), ActualValue);
        }

        [Then(@"I see cost center code as ""(.*)""")]
        public void ThenISeeCostCenterCodeAs(int ExpectedValue)
        {
            var ActualValue = _viewMyProfilePage.GetCostCenterCode();
            Assert.Equal(ExpectedValue.ToString(), ActualValue);
        }

        [Then(@"I see line manager as ""(.*)""")]
        public void ThenISeeLineManagerAs(string ExpectedValue)
        {
            var ActualValue = _viewMyProfilePage.GetSupervisorName();
            Assert.Equal(ExpectedValue, ActualValue);
        }

        [Then(@"I click on back")]
        public void ThenIClickOnBack()
        {
            _viewMyProfilePage.ClickBack();
        }


        [Then(@"I see profile information")]
        public void ThenISeeProfileInformation(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _viewMyProfilePage.VerifyProfileInformation((string)data.MaritalStatus, (string)data.NINumber, (string)data.DOB, (string)data.EmployeeNo, (string)data.CostCentreCode, (string)data.LineManager);
        }


    }
}
