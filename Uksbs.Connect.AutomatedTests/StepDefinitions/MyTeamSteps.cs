using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Uksbs.Connect.AutomatedTests.Common;
using Uksbs.Connect.AutomatedTests.SpecFlowFactory;
using Uksbs.Connect.AutomatedTests.PageObjects;
using Xunit;
using System;

namespace Uksbs.Connect.AutomatedTests.StepDefinitions
{
    [Binding]
    public sealed class MyTeamSteps
    {
        private SeleniumContext seleniumContext;
        private IWebDriver webDriver;
        private ScenarioContext _scenarioContext;

        

        private MyTeamPage _myTeamPage;

        public MyTeamSteps(SeleniumContext seleniumContext, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            //save the context so you can use it in your tests
            this.seleniumContext = seleniumContext;
            this.webDriver = seleniumContext.WebDriver;

            

            // Creating selenium specific instance for login page
            _myTeamPage = new MyTeamPage(webDriver, _scenarioContext);
        }


        [Then(@"I should see my team tile")]
        public void ThenIShouldSeeMyTeamTile()
        {
            _myTeamPage.ValidateMyTeamTileInDashboard();
        }

        [Then(@"I should see pie chart in my team tile left side")]
        public void ThenIShouldSeePieChartInMyTeamTileLeftSide()
        {
            _myTeamPage.ValidatePieChartInMyTeam();
        }

        [Then(@"I should see number of directs in pie chart as ""(.*)""")]
        public void ThenIShouldSeeNumberOfDirectsInPieChartAs(int expectedValue)
        {
            var actualValue = _myTeamPage.GetNoOfDirectsInMyTeam();
            Assert.Equal(expectedValue.ToString(), actualValue);

        }

        [Then(@"I should see directs in pie chart as ""(.*)""")]
        public void ThenIShouldSeeDirectsInPieChartAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetDirectsInMyTeam();
            Assert.Equal(expectedValue, actualValue);
        }

        [Then(@"I should see my name in my team tile as ""(.*)""")]
        public void ThenIShouldSeeMyNameInMyTeamTileAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetNameInMyTeam(expectedValue);
            Assert.Equal(expectedValue, actualValue);
        }

        [Then(@"I should see my position in my team tile as ""(.*)""")]
        public void ThenIShouldSeeMyPositionInMyTeamTileAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetRoleInMyTeam(expectedValue);
            Assert.Equal(expectedValue, actualValue);
        }

        [Then(@"I should see my manager name in my team tile as ""(.*)""")]
        public void ThenIShouldSeeMyManagerNameInMyTeamTileAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetNameInMyTeam(expectedValue);
            Assert.Equal(expectedValue, actualValue);
        }

        [Then(@"I should not see my manager name in my team tile as ""(.*)""")]
        public void ThenIShouldNotSeeMyManagerNameInMyTeamTileAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetNameInMyTeam(expectedValue);
            Assert.NotEqual(expectedValue, actualValue);
        }


        [Then(@"I should see my manager position in my team tile as ""(.*)""")]
        public void ThenIShouldSeeMyManagerPositionInMyTeamTileAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetRoleInMyTeam(expectedValue);
            Assert.Equal(expectedValue, actualValue);
        }


        [When(@"I click on the manager in my team tile right side as ""(.*)""")]
        public void WhenIClickOnTheManagerInMyTeamTileRightSideAs(string expectedValue)
        {
            _myTeamPage.ClickOnNameInMyTeam(expectedValue);
        }


        [Then(@"I should see manager name in my team tile back as ""(.*)""")]
        public void ThenIShouldSeeManagerNameInMyTeamTileBackAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetColleagueNameInMyTeamBack();
            Assert.Equal(expectedValue, actualValue);
        }

        [Then(@"I should see manager position in my team tile back as ""(.*)""")]
        public void ThenIShouldSeeManagerPositionInMyTeamTileBackAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetColleagueRoleInMyTeamBack();
            Assert.Equal(expectedValue, actualValue);
        }

        [Then(@"I should see manager email in my team tile back as ""(.*)""")]
        public void ThenIShouldSeeManagerEmailInMyTeamTileBackAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetColleagueEmailInMyTeamBack();
            Assert.Equal(expectedValue, actualValue);
        }

        [When(@"I click back button")]
        public void WhenIClickBackButton()
        {
            _myTeamPage.ClickBackInMyTeam();
        }

        [Then(@"the tile flips back to my team tile")]
        public void ThenTheTileFlipsBackToMyTeamTile()
        {
            _myTeamPage.ValidateMyTeamTileInDashboard();
        }

        [When(@"I click on view my team")]
        public void WhenIClickOnViewMyTeam()
        {
            _myTeamPage.ClickViewMyTeam();
        }

        [Then(@"I will be redirected to the team view page")]
        public void ThenIWillBeRedirectedToTheTeamViewPage()
        {
            _myTeamPage.GetMyManagerTitleTeamView();
        }

        [Then(@"I should see title of manager in team view as ""(.*)""")]
        public void ThenIShouldSeeTitleOfManagerInTeamViewAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetMyManagerTitleTeamView();
            Assert.Equal(expectedValue, actualValue);
        }

        [Then(@"I should see my manager name in team view as ""(.*)""")]
        public void ThenIShouldSeeMyManagerNameInTeamViewAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetMyManagerNameTeamView();
            Assert.Equal(expectedValue, actualValue);
        }

        [Then(@"I should see my manager position in team view as ""(.*)""")]
        public void ThenIShouldSeeMyManagerPositionInTeamViewAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetMyManagerPositionTeamView();
            Assert.Equal(expectedValue, actualValue);
        }

        [Then(@"I should see my manager grade in team view as ""(.*)""")]
        public void ThenIShouldSeeMyManagerGradeInTeamViewAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetMyManagerGradeTeamView();
            Assert.Equal(expectedValue, actualValue);
        }

        [When(@"I mouse over the tile that has my manager name")]
        public void WhenIMouseOverTheTileThatHasMyManagerName()
        {
            _myTeamPage.MouseOverMyManager();
        }


        [Then(@"I should see my manager email as ""(.*)""")]
        public void ThenIShouldSeeMyManagerEmailAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetMyManagerEmailHOverTeamView(expectedValue);
            Assert.Contains(expectedValue, actualValue);
        }


        [Then(@"I should see title with my details as ""(.*)""")]
        public void ThenIShouldSeeTitleWithMyDetailsAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetMyProfileTitleTeamView();
            Assert.Equal(expectedValue, actualValue);
        }

        [Then(@"I should see title in team view as ""(.*)""")]
        public void ThenIShouldSeeTitleInTeamViewAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetTitleInTeamView(expectedValue);
            Assert.Equal(expectedValue, actualValue);
        }

        [When(@"I mouse over the tile that has my user name")]
        public void WhenIMouseOverTheTileThatHasMyUserName()
        {
            _myTeamPage.MouseOverMyProfile();
        }

        [Then(@"I should see my phone number as ""(.*)""")]
        public void ThenIShouldSeeMyPhoneNumberAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetMyProfileWorkTelHoverTeamView();
            Assert.Equal(expectedValue, actualValue);
        }

        [Then(@"I should see my email as ""(.*)""")]
        public void ThenIShouldSeeMyEmailAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetMyProfileEmailHoverTeamView();
            Assert.Contains(expectedValue, actualValue);
        }


        [When(@"I click on view profile")]
        public void WhenIClickOnViewProfile()
        {
            _myTeamPage.ClickViewProfile();
        }

        [When(@"I click on view profile as ""(.*)""")]
        public void WhenIClickOnViewProfileAs(string expectedValue)
        {
            _myTeamPage.ClickOnViewProfile(expectedValue);
        }


        [Then(@"I will be redirected to the profile screen")]
        public void ThenIWillBeRedirectedToTheProfileScreen()
        {
            _myTeamPage.GetFullNameProfileView();
        }

        [Then(@"I should see my full name as ""(.*)""")]
        [Then(@"I should see full name as ""(.*)""")]
        public void ThenIShouldSeeMyFullNameAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetFullNameProfileView();
            Assert.Equal(expectedValue, actualValue);
        }

        [Then(@"I should see my job description as ""(.*)""")]
        [Then(@"I should see job description as ""(.*)""")]
        public void ThenIShouldSeeMyJobDescriptionAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetPositionProfileView();
            Assert.Equal(expectedValue, actualValue);
        }

        [Then(@"I should see person type as ""(.*)""")]
        public void ThenIShouldSeePersonTypeAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetEmpProfileView();
            Assert.Equal(expectedValue, actualValue);
        }

        [Then(@"I should see work location address as \|""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""\|")]
        public void ThenIShouldSeeWorkLocationAddressAs(string expectedAddress1, string expectedAddress2, string expectedAddress3, string expectedAddress4)
        {
            var actualAddress1 = _myTeamPage.GetWorkAddressProfileView1();
            var actualAddress2 = _myTeamPage.GetWorkAddressProfileView2();
            var actualAddress3 = _myTeamPage.GetWorkAddressProfileView3();
           // var actualAddress4 = _myTeamPage.GetWorkAddressProfileView4();
            Assert.Equal(expectedAddress1, actualAddress1);
            Assert.Equal(expectedAddress2, actualAddress2);
            Assert.Equal(expectedAddress3, actualAddress3);
          //  Assert.Equal(expectedAddress4, actualAddress4);
        }

        [Then(@"I should see work email address as ""(.*)""")]
        public void ThenIShouldSeeWorkEmailAddressAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetWorkEmailProfileView();
            Assert.Equal(expectedValue, actualValue);
        }

        [Then(@"I should see work phone number as ""(.*)""")]
        public void ThenIShouldSeeWorkPhoneNumberAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetWorkMobileProfileView();
            Assert.Equal(expectedValue, actualValue);
        }

        [Then(@"I should see organisation job description as ""(.*)""")]
        public void ThenIShouldSeeOrganisationJobDescriptionAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetOrgJobDescProfileView();
            Assert.Equal(expectedValue, actualValue);
        }

        [Then(@"I should see organisation location as ""(.*)""")]
        public void ThenIShouldSeeOrganisationLocationAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetOrgLocationProfileView();
            Assert.Equal(expectedValue, actualValue);
        }

        [Then(@"I should see organisation department as ""(.*)""")]
        public void ThenIShouldSeeOrganisationDepartmentAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetOrgDepartmentProfileView();
            Assert.Equal(expectedValue, actualValue);
        }

        [Then(@"I should see organisation department cost centre as ""(.*)""")]
        public void ThenIShouldSeeOrganisationDepartmentCostCentreAs(int expectedValue)
        {
            var actualValue = _myTeamPage.GetOrgDeptCostCenterProfileView();
            Assert.Equal(expectedValue.ToString(), actualValue);
        }

        [Then(@"I should see organisation grade as ""(.*)""")]
        public void ThenIShouldSeeOrganisationGradeAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetOrgGradeProfileView();
            Assert.Equal(expectedValue, actualValue);
        }

        [Then(@"I should see organisation employee programme code as ""(.*)""")]
        public void ThenIShouldSeeOrganisationEmployeeProgrammeCodeAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetOrgEmpPrgmCodeProfileView();
            Assert.Equal(expectedValue, actualValue);
        }

        [Then(@"I should see manager tile title as ""(.*)""")]
        public void ThenIShouldSeeManagerTileTitleAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetOrgManagerTitleProfileView();
            Assert.Equal(expectedValue, actualValue);
        }

        [Then(@"I should see manager name as ""(.*)""")]
        public void ThenIShouldSeeManagerNameAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetOrgManagerNameProfileView();
            Assert.Equal(expectedValue, actualValue);
        }

        [Then(@"I should see manager position as ""(.*)""")]
        public void ThenIShouldSeeManagerPositionAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetOrgManagerRoleProfileView();
            Assert.Equal(expectedValue, actualValue);
        }

        [Then(@"I should see number of direct reports as ""(.*)""")]
        public void ThenIShouldSeeNumberOfDirectReportsAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetOrgManagerReportsProfileView();
            Assert.Equal(expectedValue, actualValue);
        }

        [Then(@"I should see number of total reports as ""(.*)""")]
        public void ThenIShouldSeeNumberOfTotalReportsAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetOrgManagerReports2ProfileView();
            Assert.Equal(expectedValue, actualValue);
        }

        [Then(@"I click logout icon")]
        public void ThenIClickLogoutIcon()
        {
            _myTeamPage.ClickLogout();
        }

        [When(@"I click navigation bullets")]
        public void WhenIClickNavigationBullets()
        {
            _myTeamPage.ClickNavigationBulletsMyTeam();
        }

        [Then(@"I should see list of my team members")]
        public void ThenIShouldSeeListOfMyTeamMembers()
        {
            _myTeamPage.ValidateTeamMembersList();
        }


        [When(@"I click on one of my team member as ""(.*)""")]
        public void WhenIClickOnOneOfMyTeamMemberAs(string name)
        {
            _myTeamPage.ClickMyTeamMember(name);
        }


        [Then(@"I should see team member name in my team tile back as ""(.*)""")]
        public void ThenIShouldSeeTeamMemberNameInMyTeamTileBackAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetColleagueNameInMyTeamBack();
            Assert.Equal(expectedValue, actualValue);
        }

        [Then(@"I should see team member position in my team tile back as ""(.*)""")]
        public void ThenIShouldSeeTeamMemberPositionInMyTeamTileBackAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetColleagueRoleInMyTeamBack();
            Assert.Equal(expectedValue, actualValue);
        }

        [Then(@"I should see team member email in my team tile back as ""(.*)""")]
        public void ThenIShouldSeeTeamMemberEmailInMyTeamTileBackAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetColleagueEmailInMyTeamBack();
            Assert.Equal(expectedValue, actualValue);
        }

        [Then(@"I should see team member telephone number in my team tile back as ""(.*)""")]
        public void ThenIShouldSeeTeamMemberTelephoneNumberInMyTeamTileBackAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetColleagueTelNoInMyTeamBack();
            Assert.Equal(expectedValue, actualValue);
        }

        [Then(@"I should see my manager telephone number as ""(.*)""")]
        public void ThenIShouldSeeMyManagerTelephoneNumberAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetMyManagerContactTeamView();
            Assert.Equal(expectedValue, actualValue);
        }

        [Then(@"I should see my manager work telephone number as ""(.*)""")]
        public void ThenIShouldSeeMyManagerWorkTelephoneNumberAs(string expectedValue)
        {
            if(!String.IsNullOrEmpty(expectedValue))
            {
                var actualValue = _myTeamPage.GetMyManageWorkTelHOverTeamView(expectedValue);
                Assert.Equal(expectedValue, actualValue);
            }
            
        }


        [When(@"I mouse over the tile that has my direct reports as ""(.*)""")]
        public void WhenIMouseOverTheTileThatHasMyDirectReportsAs(string expectedValue)
        {
            _myTeamPage.MouseOverMyDirectReports(expectedValue);
        }


        [Then(@"I should see my direct reports work telephone number as ""(.*)""")]
        public void ThenIShouldSeeMyDirectReportsWorkTelephoneNumberAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetMyDRWorkTelHoverTeamView(expectedValue);
            Assert.Contains(expectedValue, actualValue);
        }

        [Then(@"I should see my direct reports email as ""(.*)""")]
        public void ThenIShouldSeeMyDirectReportsEmailAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetMyDREmailHoverTeamView(expectedValue);
            Assert.Contains(expectedValue, actualValue);
        }

        [When(@"I click on how to update organizational information’")]
        public void WhenIClickOnHowToUpdateOrganizationalInformation()
        {
            _myTeamPage.ClickHowToUpdateOrgInfo();
        }


        [Then(@"I should see dialog window as ""(.*)""")]
        public void ThenIShouldSeeDialogWindowAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetUpdateOrgDataInfo(expectedValue);
            Assert.Equal(expectedValue, actualValue);
        }


        [Then(@"I close dialog window")]
        public void ThenICloseDialogWindow()
        {
            _myTeamPage.CloseUpdateOrgInfoDialog();
        }

        [When(@"I click on manager to update line manager")]
        public void WhenIClickOnManagerToUpdateLineManager()
        {
            _myTeamPage.ClickEditLineManager();
        }

        [Then(@"I should see dialog window header as ""(.*)""")]
        public void ThenIShouldSeeDialogWindowHeaderAs(string expectedValue)
        {
            var actualValue = _myTeamPage.GetChangeManagerDialogInfo(expectedValue);
            Assert.Equal(expectedValue, actualValue);
        }


        [Then(@"I select new manager as ""(.*)""")]
        public void ThenISelectNewManagerAs(string managerName)
        {
            _myTeamPage.SelectNewManager(managerName);
        }

        [Then(@"I select effective start date as ""(.*)""")]
        public void ThenISelectEffectiveStartDateAs(string startDate)
        {
            _myTeamPage.SelectEffectiveStartDate(startDate);
        }

        [Then(@"I click submit button")]
        public void ThenIClickSubmitButton()
        {
            _myTeamPage.ClickSubmit();
        }


    }
}
