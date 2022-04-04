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
    public sealed class SideMenuSteps
    {
        private SeleniumContext seleniumContext;
        private IWebDriver webDriver;
        private ScenarioContext _scenarioContext;

        

        private SideMenuPage _sideMenuPage;

        public SideMenuSteps(SeleniumContext seleniumContext, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            //save the context so you can use it in your tests
            this.seleniumContext = seleniumContext;
            this.webDriver = seleniumContext.WebDriver;
            

            // Creating selenium specific instance for login page
            _sideMenuPage = new SideMenuPage(webDriver, _scenarioContext);
        }


        [Then(@"I click on view menu")]
        public void ThenIClickOnViewMenu()
        {
            _sideMenuPage.ClickViewMenu();
        }

        [Then(@"I refresh the page")]
        public void ThenIRefreshThePage()
        {
            _sideMenuPage.RefreshPage();
        }

        [When(@"I click on my oracle homepage")]
        public void WhenIClickOnMyOracleHomepage()
        {
            _sideMenuPage.ClickMyOracleHomepage();
        }

        [When(@"I click on professional qualifications")]
        public void WhenIClickOnProfessionalQualifications()
        {
            _sideMenuPage.ClickProfQualifications();
        }

        [Then(@"I should see other professional qualifications from EBS")]
        public void ThenIShouldSeeOtherProfessionalQualificationsFromEBS()
        {
            _sideMenuPage.ValidateProfQualifications();
        }

        [When(@"I click on iexpenses")]
        public void WhenIClickOnIexpenses()
        {
            _sideMenuPage.ClickIExpenses();
        }

        [Then(@"I should see expenses home from EBS")]
        public void ThenIShouldSeeExpensesHomeFromEBS()
        {
            _sideMenuPage.ValidateExpenseHomepage();
        }

        [When(@"I click on Absence")]
        public void WhenIClickOnAbsence()
        {
            _sideMenuPage.ClickAbsence();
        }

        [Then(@"I should see my absense details")]
        public void ThenIShouldSeeMyAbsenseDetails()
        {
            _sideMenuPage.ValidateAbsenceDetails();
        }

        [When(@"I click on manager absence view")]
        public void WhenIClickOnManagerAbsenceView()
        {
            _sideMenuPage.ClickManagerAbsenceView();
        }


        [Then(@"I should see my direct reports title")]
        public void ThenIShouldSeeMyDirectReportsTitle()
        {
            _sideMenuPage.ValidateManagerAbsenceView();
        }


        [When(@"I click on notifications")]
        public void WhenIClickOnNotifications()
        {
            _sideMenuPage.ClickNotifications();
        }

        [Then(@"I should see list of notification and some filters")]
        public void ThenIShouldSeeListOfNotificationAndSomeFilters()
        {
            _sideMenuPage.ValidateNotifications();
        }

        [When(@"I click on team")]
        public void WhenIClickOnTeam()
        {
            _sideMenuPage.ClickTeam();
        }

        [Then(@"I should see my manager and directs")]
        public void ThenIShouldSeeMyManagerAndDirects()
        {
            _sideMenuPage.ValidateTeamView();
        }

        [When(@"I click on isupport")]
        public void WhenIClickOnIsupport()
        {
            _sideMenuPage.ClickISupport();
        }

        [Then(@"I should see iSupport Resources from EBS")]
        public void ThenIShouldSeeISupportResourcesFromEBS()
        {
            _sideMenuPage.ValidateISupport();
        }

    }
}
