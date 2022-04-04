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
    public sealed class DiversityDetailSteps
    {
        private SeleniumContext seleniumContext;
        private IWebDriver webDriver;
        private ScenarioContext _scenarioContext;

        

        private DiversityDetailsPage _diversityDetailsPage;

        public DiversityDetailSteps(SeleniumContext seleniumContext, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            //save the context so you can use it in your tests
            this.seleniumContext = seleniumContext;
            this.webDriver = seleniumContext.WebDriver;

            

            // Creating selenium specific instance for login page
            _diversityDetailsPage = new DiversityDetailsPage(webDriver, _scenarioContext);
        }

        [Given(@"I select Gender as ""(.*)""")]
        public void GivenISelectGenderAs(string gender)
        {
            _diversityDetailsPage.SelectGender(gender);
        }

        [Given(@"I select nationality as ""(.*)""")]
        public void GivenISelectNationalityAs(string nationality)
        {
            _diversityDetailsPage.SelectNationality(nationality);
        }

        [Given(@"I select nationality secondary as ""(.*)""")]
        public void GivenISelectNationalitySecondaryAs(string nationalitySecondary)
        {
            _diversityDetailsPage.SelectNationalitySecondary(nationalitySecondary);
        }

        [Given(@"I select national identity as ""(.*)""")]
        public void GivenISelectNationalIdentityAs(string nationalIdentity)
        {
            _diversityDetailsPage.SelectNationalIdentity(nationalIdentity);
        }

        [Given(@"I select ethnicity as ""(.*)""")]
        public void GivenISelectEthnicityAs(string ethnicity)
        {
            _diversityDetailsPage.SelectEthnicity(ethnicity);
        }

        [Given(@"I select sexual orientation as ""(.*)""")]
        public void GivenISelectSexualOrientationAs(string sexualOrientation)
        {
            _diversityDetailsPage.SelectSexualOrientation(sexualOrientation);
        }

        [Given(@"I select religious belieft as ""(.*)""")]
        public void GivenISelectReligiousBelieftAs(string religiousBelief)
        {
            _diversityDetailsPage.SelectReligiousBelief(religiousBelief);
        }

        [Then(@"I save diversity details")]
        public void ThenISaveDiversityDetails()
        {
            _diversityDetailsPage.ClickSaveDiversityDetails();
        }
    }
}
