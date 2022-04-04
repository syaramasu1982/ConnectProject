using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Uksbs.Connect.AutomatedTests.Common;
using Uksbs.Connect.AutomatedTests.SpecFlowFactory;
using Uksbs.Connect.AutomatedTests.PageObjects;
using Xunit;
using System.Linq;
using System;

namespace Uksbs.Connect.AutomatedTests.StepDefinitions
{
    [Binding]
    public sealed class MyOvertimeSteps
    {
        private SeleniumContext seleniumContext;
        private IWebDriver webDriver;
        private ScenarioContext _scenarioContext;

        

        private MyOvertimePage _myOvertimePage;
        private string createdAbsenceForClick_elementID;

        public MyOvertimeSteps(SeleniumContext seleniumContext, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            //save the context so you can use it in your tests
            this.seleniumContext = seleniumContext;
            this.webDriver = seleniumContext.WebDriver;

            

            // Creating selenium specific instance for login page
            _myOvertimePage = new MyOvertimePage(webDriver, _scenarioContext);
        }

        [Then(@"I should see my overtime tile in dashboard")]
        [Then(@"my overtime screen should be displayed")]
        public void ThenIShouldSeeMyOverTimeTileInDashboard()
        {
            _myOvertimePage.ValidateMyOvertimeTileInDashboard();
        }

        [Then(@"I should see create/view overtime button")]
        public void ThenIShouldSeeCreateViewOvertimeButton()
        {
            _myOvertimePage.ValidateCreateOrViewOvertimeButton();
        }
        [When(@"I click on i icon on my overtime tile")]
        public void WhenIClickOnIIconOnMyOvertimeTile()
        {
            _myOvertimePage.ClickOnIiconOvertime();
        }    

        [Then(@"I should see information message")]
        public void ThenIShouldSeeInformationMessage()
        {
            _myOvertimePage.ValidateIIconPopupText();
        }

        [When(@"I click on create or view overtime")]
        public void WhenIClickOnCreateOrViewOvertime()
        {
            _myOvertimePage.ClickOnCreateOrViewOvertime();
        }

        [Then(@"I will be redirected to the my overtime page")]
        public void ThenIWillBeRedirectedToTheMyOvertimePage()
        {
            _myOvertimePage.GetMyOvertimeTitle();
        }

        [When(@"I click on create overtime button")]
        public void WhenIClickOnCreateOvertimeButton()
        {
            _myOvertimePage.ClickOnCreateOvertimeButton();
        }

        [Then(@"I select period as ""(.*)""")]
        public void ThenISelectPeriodAs(string period)
        {
            _myOvertimePage.SelectPeriod(period);
        }

        [Then(@"I enter comments as ""(.*)""")]
        public void ThenIEnterCommentsAs(string comments)
        {
            _myOvertimePage.EnterComments(comments);
        }

        [Then(@"I select hours type as ""(.*)""")]
        public void ThenISelectHoursTypeAs(string hoursType)
        {
            _myOvertimePage.SelectHoursType(hoursType);
        }

        [Then(@"I select next row hours type as ""(.*)""")]
        public void ThenISelectNextRowHoursTypeAs(string hoursType)
        {
            _myOvertimePage.SelectHoursTypeNextRow(hoursType);
        }

        [Then(@"I enter next overtime hours on monday as ""(.*)""")]
        public void ThenIEnterNextOvertimeHoursOnMondayAs(Decimal period)
        {
            _myOvertimePage.EnterOvertimePeriodNext(period);
        }

        [Then(@"I enter overtime hours on monday as ""(.*)""")]
        public void ThenIEnterOvertimeHoursOnMondayAs(Decimal period)
        {
            _myOvertimePage.EnterOvertimePeriod(period);
        }

        [Then(@"I click add overtime")]
        public void ThenIClickAddOvertime()
        {
            _myOvertimePage.ClickOnAddOvertime();
        }

        [Then(@"I click on save button")]
        public void ThenIClickOnSaveButton()
        {
            _myOvertimePage.ClickOnSave();
        }

        [Then(@"I should see my overtime request was added")]
        public void ThenIShouldSeeMyOvertimeRequestWasAdded()
        {
            _myOvertimePage.ValidateMyOvertimeAdded();
        }

        [Then(@"I should see my overtime request was added and status as ""(.*)""")]
        public void ThenIShouldSeeMyOvertimeRequestWasAddedAndStatusAs(string p0)
        {
            ScenarioContext.Current.Pending();
        }


        [When(@"I click on my overtime details icon")]
        public void WhenIClickOnMyOvertimeDetailsIcon()
        {
            _myOvertimePage.ClickOnDetailsiCon();
        }

        [Then(@"I should see my overtime hours type as ""(.*)"" and ""(.*)""")]
        public void ThenIShouldSeeMyOvertimeHoursTypeAsAnd(string expectedHoursType1, string expectedHoursType2)
        {
            var actualHoursType1 = _myOvertimePage.GetMyOvertimeHoursType(expectedHoursType1);
            Assert.Equal(expectedHoursType1, actualHoursType1);

            var actualHoursType2 = _myOvertimePage.GetMyOvertimeHoursType(expectedHoursType2);
            Assert.Equal(expectedHoursType2, actualHoursType2);
        }

        [Then(@"I should see my overtime hours as ""(.*)"" and ""(.*)""")]
        public void ThenIShouldSeeMyOvertimeHoursAsAnd(Decimal expectedHours1, Decimal expectedHours2)
        {
            var actualHours1 = _myOvertimePage.GetMyOvertimeHoursType(expectedHours1.ToString());
            Assert.Equal(expectedHours1.ToString(), actualHours1);

            var actualHours2 = _myOvertimePage.GetMyOvertimeHoursType(expectedHours2.ToString());
            Assert.Equal(expectedHours2.ToString(), actualHours2);
        }

        [When(@"I click on pencil icon")]
        public void WhenIClickOnPencilIcon()
        {
            _myOvertimePage.ClickOnPenciliCon();
        }

        [Then(@"I update hours type as ""(.*)""")]
        public void ThenIUpdateHoursTypeAs(string hoursType)
        {
            _myOvertimePage.UpdateHoursType(hoursType);
        }

        [Then(@"I tick two checkboxes")]
        public void ThenITickTwoCheckboxes()
        {
            _myOvertimePage.TickCheckboxes();
        }

        [Then(@"I should not see update icon")]
        public void ThenIShouldNotSeeUpdateIcon()
        {
            _myOvertimePage.ValidateUpdateIcon();
        }

        [When(@"I click on refine search criteria")]
        public void WhenIClickOnRefineSearchCriteria()
        {
            _myOvertimePage.ClickOnRefineSearchCriteria();
        }

        [Then(@"The search criteria should be displayed")]
        public void ThenTheSearchCriteriaShouldBeDisplayed()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I select status as ""(.*)""")]
        public void WhenISelectStatusAs(string status)
        {
            _myOvertimePage.SelectStatus(status);
        }

        [When(@"I click on search button")]
        public void WhenIClickOnSearchButton()
        {
            _myOvertimePage.ClickSearchButton();
        }

        [Then(@"I should the see list of the items status as ""(.*)""")]
        public void ThenIShouldTheSeeListOfTheItemsStatusAs(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click on clear button")]
        public void WhenIClickOnClearButton()
        {
            _myOvertimePage.ClickClearButton();
        }

        [Then(@"I should see the selected status cleared")]
        public void ThenIShouldSeeTheSelectedStatusCleared()
        {
            _myOvertimePage.ValidateSelectStatusAsCleared();
        }

        [When(@"I click delete icon from the existing list")]
        public void WhenIClickDeleteIconFromTheExistingList()
        {
            _myOvertimePage.ClickODeleteIcon();
        }

        [Then(@"The row should disappear from the request ""(.*)""")]
        public void ThenTheRowShouldDisappearFromTheRequest(string hoursType)
        {
            _myOvertimePage.ValidateAddOvertimeDeleted(hoursType);
        }

        [Then(@"I should see total hours as calculated")]
        public void ThenIShouldSeeTotalHoursAsCalculated()
        {
            _myOvertimePage.ValidateTotal();
        }

        [When(@"I check the checkbox of I have read and understood my organisations overtime policy")]
        public void WhenICheckTheCheckboxOfIHaveReadAndUnderstoodMyOrganisationsOvertimePolicy()
        {
            _myOvertimePage.TickPolicyCheckbox();
        }

        [Then(@"I should see submit button remains disabled")]
        public void ThenIShouldSeeSubmitButtonRemainsDisabled()
        {
            _myOvertimePage.ValidateDisabledSubmit();
        }

        [When(@"I check the checkbox of I confirm that I have line manager pre-approval to work overtime and budget holder approval to allow me to submit my claim")]
        public void WhenICheckTheCheckboxOfIConfirmThatIHaveLineManagerPre_ApprovalToWorkOvertimeAndBudgetHolderApprovalToAllowMeToSubmitMyClaim()
        {
            _myOvertimePage.TickConfirmCheckbox();
        }

        [Then(@"I should see submit button becomes enabled")]
        public void ThenIShouldSeeSubmitButtonBecomesEnabled()
        {
            _myOvertimePage.ValidateEnabledSubmit();
        }

        [When(@"I uncheck the checkbox of I have read and understood my organisations overtime policy")]
        public void WhenIUncheckTheCheckboxOfIHaveReadAndUnderstoodMyOrganisationsOvertimePolicy()
        {
            _myOvertimePage.TickPolicyCheckbox();
        }

        [Then(@"I should see the status as ""(.*)""")]
        public void ThenIShouldSeeTheStatusAs(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click on messages and select type as ""(.*)""")]
        public void WhenIClickOnMessagesAndSelectTypeAs(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should see overtime messages")]
        public void ThenIShouldSeeOvertimeMessages()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I click on the last overtime notification")]
        public void ThenIClickOnTheLastOvertimeNotification()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The request details should be displayed")]
        public void ThenTheRequestDetailsShouldBeDisplayed()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click on overtime information")]
        public void WhenIClickOnOvertimeInformation()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click on mark as read button")]
        public void WhenIClickOnMarkAsReadButton()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Overtime notification disappears from the list")]
        public void ThenOvertimeNotificationDisappearsFromTheList()
        {
            ScenarioContext.Current.Pending();
        }


    }
}
