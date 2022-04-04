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
using System.Globalization;
using System.Threading;

namespace Uksbs.Connect.AutomatedTests.StepDefinitions
{
    [Binding]
    public sealed class MyAnnualLeaveSteps
    {
        private SeleniumContext seleniumContext;
        private IWebDriver webDriver;
        private ScenarioContext _scenarioContext;

        

        private MyAnnualLeavePage _myAnnualLeavePage;
        private MyNotificationsPage _myNotificationsPage;

        private string createdAbsenceForClick_elementID;
        private string _startDate;
        private string _endDate;

        public MyAnnualLeaveSteps(SeleniumContext seleniumContext, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            //save the context so you can use it in your tests
            this.seleniumContext = seleniumContext;
            this.webDriver = seleniumContext.WebDriver;

            

            // Creating selenium specific instance for login page
            _myAnnualLeavePage = new MyAnnualLeavePage(webDriver, _scenarioContext);
            _myNotificationsPage = new MyNotificationsPage(webDriver, _scenarioContext);
        }

        [Then(@"I should see my annual leave tile in dashboard")]
        public void ThenIShouldSeeMyAnnualLeaveTileInDashboard()
        {
            _myAnnualLeavePage.ValidateMyAnnualLeaveTileInDashboard();
        }

        [When(@"I click on i icon")]
        public void WhenIClickOnIIcon()
        {
            _myAnnualLeavePage.ClickIIcon();
        }

        [Then(@"I should see annual leave entry from INSS and DIT")]
        public void ThenIShouldSeeAnnualLeaveEntryFromINSSAndDIT()
        {
            _myAnnualLeavePage.ValidateIIconPopupText();
        }

        [Then(@"I close the i icon")]
        public void ThenICloseTheIIcon()
        {
            _myAnnualLeavePage.ClickIIconPopupClose();
        }

        [Then(@"I should see pie chart in my annual leave tile left side")]
        public void ThenIShouldSeePieChartInMyAnnualLeaveTileLeftSide()
        {
            _myAnnualLeavePage.ValidatePieChart();
        }

        [Then(@"I should see number of remaining leaves in pie chart as ""(.*)""")]
        public void ThenIShouldSeeNumberOfRemainingLeavesInPieChartAs(string expectedValue)
        {
            var actualValue = _myAnnualLeavePage.GetNoOfHolidays();
           // Assert.Equal(expectedValue.ToString(), actualValue);
        }

        [Then(@"I should see the days remaining in pie chart as ""(.*)""")]
        public void ThenIShouldSeeTheDaysRemainingInPieChartAs(string expectedValue)
        {
            var actualValue = _myAnnualLeavePage.GetRemainingDays();
           // Assert.Equal(expectedValue, actualValue);
        }

        [When(@"I click on create or view leave")]
        public void WhenIClickOnCreateOrViewLeave()
        {
            _myAnnualLeavePage.ClickOnCreateOrViewLeave();
        }

        [Then(@"I will be redirected to the my absences page")]
        public void ThenIWillBeRedirectedToTheMyAbsencesPage()
        {
            _myAnnualLeavePage.GetMyAbsencesTitle();
        }

        [Then(@"I should see list of my direct reports")]
        public void ThenIShouldSeeListOfMyDirectReports()
        {
            var listOfMyDirectReports = _myAnnualLeavePage.GetMyDirectReportsList();
        }

        [Then(@"I should see team calendar button")]
        public void ThenIShouldSeeTeamCalendarButton()
        {
            _myAnnualLeavePage.ValidateTeamCalender();
        }

        [Then(@"I should see create absence button")]
        public void ThenIShouldSeeCreateAbsenceButton()
        {
            _myAnnualLeavePage.ValidateCreateAbsence();
        }

        [Then(@"I should see holiday balance")]
        public void ThenIShouldSeeHolidayBalance()
        {
            _myAnnualLeavePage.ValidateHolidayBalance();
        }

        [Then(@"I should see status details")]
        public void ThenIShouldSeeStatusDetails()
        {
            _myAnnualLeavePage.ValidateStatusLabels();
        }

        [Then(@"I should see a list of my leaves")]
        public void ThenIShouldSeeAListOfMyLeaves()
        {
            _myAnnualLeavePage.ValidateListOfMyLeaves();
        }

        [When(@"I click on create absence")]
        public void WhenIClickOnCreateAbsence()
        {
            _myAnnualLeavePage.ClickOnCreateAbsence();
        }

        [Then(@"I see create absence window")]
        public void ThenISeeCreateAbsenceWindow()
        {
            _myAnnualLeavePage.ValidateCreateAbsenceTitle();
        }

        [Then(@"I select type as ""(.*)""")]
        public void ThenISelectTypeAs(string absenceType)
        {
            _myAnnualLeavePage.SelectTypeInCreateAbsence(absenceType);
        }

        [Then(@"I select reason as ""(.*)""")]
        public void ThenISelectReasonAs(string absenceReason)
        {
            _myAnnualLeavePage.SelectReasonInCreateAbsence(absenceReason);
        }

        [Then(@"I select start date")]
        public void ThenISelectStartDate()
        {
            DateTime currentDateTime = DateTime.Now;
            currentDateTime = currentDateTime.AddDays(35);
            _startDate = currentDateTime.ToString("dd.MM.yy", new CultureInfo("en-US"));

            _myAnnualLeavePage.SelectAbsenceStartDate(_startDate);
        }

        [Then(@"I select start date as ""(.*)""")]
        public void ThenISelectStartDateAs(string startDate)
        {
            DateTime currentDateTime = DateTime.Now;
            if (startDate.ToUpper().Contains("FUTURE"))
            {
                currentDateTime = currentDateTime.AddDays(35);
                _startDate = currentDateTime.ToString("dd.MM.yy", new CultureInfo("en-US"));
                _myAnnualLeavePage.SelectAbsenceStartDate(_startDate);
            }
            else if (startDate.ToUpper().Contains("PAST"))
            {
                currentDateTime = currentDateTime.AddDays(-32);
                _startDate = currentDateTime.ToString("dd.MM.yy", new CultureInfo("en-US"));
                _myAnnualLeavePage.SelectAbsenceStartDate(_startDate);
            }
            else
            {
                _startDate = currentDateTime.ToString("dd.MM.yy", new CultureInfo("en-US"));
                _myAnnualLeavePage.SelectAbsenceStartDate(_startDate);
            }
           
        }

        [Then(@"I select end date")]
        public void ThenISelectEndDate()
        {
            DateTime currentDateTime = DateTime.Now;
            currentDateTime = currentDateTime.AddDays(35);
            _endDate = currentDateTime.ToString("dd.MM.yy", new CultureInfo("en-US"));
            _myAnnualLeavePage.SelectAbsenceEndDate(_endDate);
        }

        [Then(@"I select end date as ""(.*)""")]
        public void ThenISelectEndDateAs(string endDate)
        {
            DateTime currentDateTime = DateTime.Now;
            if (endDate.ToUpper().Contains("FUTURE"))
            {
                currentDateTime = currentDateTime.AddDays(35);
                _endDate = currentDateTime.ToString("dd.MM.yy", new CultureInfo("en-US"));
                _myAnnualLeavePage.SelectAbsenceEndDate(_endDate);
            }
            else if (endDate.ToUpper().Contains("PAST"))
            {
                currentDateTime = currentDateTime.AddDays(-32);
                _endDate = currentDateTime.ToString("dd.MM.yy", new CultureInfo("en-US"));
                _myAnnualLeavePage.SelectAbsenceEndDate(_endDate);
            }
            else
            {
                _endDate = currentDateTime.ToString("dd.MM.yy", new CultureInfo("en-US"));
                _myAnnualLeavePage.SelectAbsenceEndDate(_endDate);
            }
        }

        [Then(@"I select duration as ""(.*)""")]
        public void ThenISelectDurationAs(string duration)
        {
            if (!string.IsNullOrEmpty(duration))
            {
                _myAnnualLeavePage.SelectDuration(duration);
            }
            
        }

        [Then(@"I click submit button on create absence")]
        public void ThenIClickSubmitButtonOnCreateAbsence()
        {
            _myAnnualLeavePage.ClickOnSubmit();
        }

        [Then(@"I click on close popup button")]
        public void ThenIClickOnClosePopupButton()
        {
            _myAnnualLeavePage.ClickOnClose();
        }


        [Then(@"I should see the absence request details in the list as \|""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""\|")]
        public void ThenIShouldSeeTheAbsenceRequestDetailsInTheListAs(string absenceType, string duration, string submittedDate, string status)
        {
            try
            {
                var absenceDashboard = _myAnnualLeavePage.GetAbsenceDetails();
                var createdAbsence = absenceDashboard.AllAbsences.FirstOrDefault(x => x.Type == absenceType &&
                                                                                      x.StartDate == _startDate &&
                                                                                      x.EndDate == _endDate &&
                                                                                      x.Duration == duration &&
                                                                                      x.DateSubmitted == submittedDate &&
                                                                                      x.Status == status);

                //var sickness_elementID = absenceDashboard.AllAbsences.FirstOrDefault(x => x.Type == "Sickness").elementID;
                //_myAnnualLeavePage.ClickOnCreatedAbsence(sickness_elementID);

                Assert.NotNull(createdAbsence);

                createdAbsenceForClick_elementID = createdAbsence.elementID;
            }
            catch
            {
                var mainClass = _myAnnualLeavePage.IsElementPresent(By.ClassName("item-main-info"));
                
                if (!mainClass)
                {
                    int index = 0;
                    while (true)
                    {
                        webDriver.Navigate().GoToUrl(webDriver.Url);
                        Thread.Sleep(5000);
                        _myAnnualLeavePage.LoadEntirePage();
                        Thread.Sleep(2000);
                        _myAnnualLeavePage.ClickViewMenu();
                        _myAnnualLeavePage.ClickAbsence();
                        _myAnnualLeavePage.ClickOnStatus(status);
                        if (mainClass)
                        {
                            break;
                        }
                    }
                }
               

                var absenceDashboard = _myAnnualLeavePage.GetAbsenceDetails();
                var createdAbsence = absenceDashboard.AllAbsences.Find(x => x.Type == absenceType &&
                                                                                      x.StartDate == _startDate &&
                                                                                      x.EndDate == _endDate &&
                                                                                      x.Duration == duration &&
                                                                                      x.DateSubmitted == submittedDate &&
                                                                                      x.Status == status);

                //var sickness_elementID = absenceDashboard.AllAbsences.FirstOrDefault(x => x.Type == "Sickness").elementID;
                //_myAnnualLeavePage.ClickOnCreatedAbsence(sickness_elementID);

                Assert.NotNull(createdAbsence);

                createdAbsenceForClick_elementID = createdAbsence.elementID;

            }
            
        }

        [Then(@"I click on created absence")]
        public void ThenIClickOnCreatedAbsence()
        {
            _myAnnualLeavePage.ClickOnCreatedAbsence(createdAbsenceForClick_elementID);
        }

        [When(@"I click on notification state toaction")]
        public void WhenIClickOnNotificationStateToaction()
        {
            _myAnnualLeavePage.ClickOnStateToAction();
        }

        [Then(@"I should see leave request details")]
        public void ThenIShouldSeeLeaveRequestDetails()
        {
            var leaveReqDetails = _myAnnualLeavePage.GetLeaveRequestDetails();
        }

        [When(@"I click on leave request to action as \|""(.*)"" ""(.*)"" ""(.*)""\|")]
        public void WhenIClickOnLeaveRequestToActionAs(string leaveRequest, string empName, string toAction)
        {
                DateTime currentDateTime = DateTime.Now;
                var dateSubmitted = currentDateTime.ToString("dddd dd MMM", new CultureInfo("en-US"));

                var listOfLeaveRequests = _myAnnualLeavePage.GetLeaveRequestDetails();

                var leaveRequestElementID = listOfLeaveRequests.AllAbsences.FirstOrDefault(x => x.LeaveRequest == leaveRequest &&
                                                                                      x.DateSubmitted == dateSubmitted &&
                                                                                      x.EmpName == empName &&
                                                                                      x.ToAction == toAction).elementID;

                // var leaveRequestElementID = listOfLeaveRequests.AllAbsences.FirstOrDefault(x => x.EmpName == directReportName).elementID;

                _myAnnualLeavePage.ClickOnCreatedAbsence(leaveRequestElementID);
            
            
        }

        [Then(@"I click on accept button")]
        public void ThenIClickOnAcceptButton()
        {
            _myAnnualLeavePage.ClickOnAcceptLeave();
        }

        [Then(@"I click on decline button")]
        public void ThenIClickOnDeclineButton()
        {
            _myAnnualLeavePage.ClickOnDeclineLeave();
        }

        [When(@"I click on status as ""(.*)""")]
        public void WhenIClickOnStatusAs(string status)
        {
            if (status == "All")
            {
                _myAnnualLeavePage.ClickOnStatusAll();
            }
            else if (status == "Approved")
            {
                _myAnnualLeavePage.ClickOnStatusApproved();
            }
            else if (status == "Pending")
            {
                _myAnnualLeavePage.ClickOnStatusPending();
            }
            else if (status == "Taken")
            {
                _myAnnualLeavePage.ClickOnStatusTaken();
            }
        }

        [Then(@"I should be able to see the submit button disabled")]
        public void ThenIShouldBeAbleToSeeTheSubmitButtonDisabled()
        {
            _myAnnualLeavePage.ValidateSubmitDisabled();
        }

        [Then(@"I should see the error message")]
        public void ThenIShouldSeeTheErrorMessage()
        {
            var expectedErrorMessage = "This absence overlaps an existing absence of same absence category for the employee.";
            var actualErrorMessage = _myAnnualLeavePage.GetErrorMessageWhenPastDuplicateAbsenceRequest();
            Assert.Equal(expectedErrorMessage, actualErrorMessage);
        }

        [When(@"I click on status all")]
        public void WhenIClickOnStatusAll()
        {
            _myAnnualLeavePage.ClickOnStatusAll();
        }

        [Then(@"I should see all my absences")]
        public void ThenIShouldSeeAllMyAbsences()
        {
            var allAbsences = _myAnnualLeavePage.GetAbsenceDetails();
            var totalNoOfAbsences = allAbsences.AllAbsences.Count;

            Assert.NotNull(allAbsences);
            // var allSickness = allAbsences.AllAbsences.FindAll(x => x.Type);
            //var allSickness = x.AllAbsences.FindAll(x => x.Type == "Sickness");
            //var firstSickness = x.AllAbsences.FirstOrDefault(x => x.Type == "Sickness");
            //var a = x.AllAbsences.OrderBy(x => x.Type);
            //var desc = x.AllAbsences.OrderByDescending(x => x.EndDate);
            //var dist = x.AllAbsences.Select(x => x.Type).Distinct().ToList();
            //  Assert.Equal("Sickness", x.AllAbsences[0].Type);
        }

        [When(@"I click on status pending")]
        public void WhenIClickOnStatusPending()
        {
            _myAnnualLeavePage.ClickOnStatusPending();
        }

        [Then(@"I should see all my pending absences")]
        public void ThenIShouldSeeAllMyPendingAbsences()
        {
            var pendingAbsences = _myAnnualLeavePage.GetAbsenceDetails();
            var allPending = pendingAbsences.AllAbsences.FindAll(x => x.Status == "Pending");
            foreach (var actual in allPending)
            {
                Assert.Equal("Pending", actual.Status);
            }
        }

        [When(@"I click on status taken")]
        public void WhenIClickOnStatusTaken()
        {
            _myAnnualLeavePage.ClickOnStatusTaken();
        }

        [Then(@"I should see all my taken absences")]
        public void ThenIShouldSeeAllMyTakenAbsences()
        {
            var takenAbsences = _myAnnualLeavePage.GetAbsenceDetails();
            var allPending = takenAbsences.AllAbsences.FindAll(x => x.Type == "Taken");
        }

        [When(@"I click on clear filters")]
        public void WhenIClickOnClearFilters()
        {
            _myAnnualLeavePage.ClickClearFilters();
        }

        [When(@"I select type as ""(.*)""")]
        public void WhenISelectTypeAs(string absenceType)
        {
            _myAnnualLeavePage.SelectAbsenceType(absenceType);
        }

        [Then(@"I should see all my ""(.*)"" absences")]
        public void ThenIShouldSeeAllMyAbsences(string p0)
        {
            var allAbsences = _myAnnualLeavePage.GetAbsenceDetails();
        }

        [When(@"I select start date as ""(.*)"" and end date as ""(.*)""")]
        public void WhenISelectStartDateAsAndEndDateAs(string p0, string p1)
        {
            var allAbsences = _myAnnualLeavePage.GetAbsenceDetails();
        }

        [Then(@"I should see my absences filter by start date and end date")]
        public void ThenIShouldSeeMyAbsencesFilterByStartDateAndEndDate()
        {
            var allAbsences = _myAnnualLeavePage.GetAbsenceDetails();
        }

        [Then(@"I should be able to see all my pending sickness")]
        public void ThenIShouldBeAbleToSeeAllMyPendingSickness()
        {
            var allAbsences = _myAnnualLeavePage.GetAbsenceDetails();
        }

        [Then(@"I click on my direct report as ""(.*)""")]
        public void ThenIClickOnMyDirectReportAs(string directReportName)
        {
            var listOfMyDirectReports = _myAnnualLeavePage.GetMyDirectReportsList();

            var directReportElementID = listOfMyDirectReports.AllAbsences.FirstOrDefault(x => x.EmpName == directReportName).elementID;

            _myAnnualLeavePage.ClickOnCreatedAbsence(directReportElementID);
        }

        [When(@"I click on status approved")]
        public void WhenIClickOnStatusApproved()
        {
            _myAnnualLeavePage.ClickOnStatusApproved();
        }

        [Then(@"I should see all my approved absences")]
        public void ThenIShouldSeeAllMyApprovedAbsences()
        {
            var approvedAbsences = _myAnnualLeavePage.GetAbsenceDetails();
            var allApproved = approvedAbsences.AllAbsences.FindAll(x => x.Type == "Approved");
            //  var actualApproved = approvedAbsences.AllAbsences.Select(x => x.Type).Distinct().ToList();
            foreach (var actual in allApproved)
            {
                Assert.Equal("Pending", actual.Status);
            }
        }

        [When(@"I click on leave request to delete as \|""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""\|")]
        public void WhenIClickOnLeaveRequestToDeleteAs(string absenceType, string duration, string submittedDate, string status)
        {
            var listOfLeaveRequests = _myAnnualLeavePage.GetAbsenceDetails();
            var leaveRequestElementID = listOfLeaveRequests.AllAbsences.FirstOrDefault(x => x.Type == absenceType &&
                                                                                  x.StartDate == _startDate &&
                                                                                  x.EndDate == _endDate &&
                                                                                  x.Duration == duration &&
                                                                                  x.DateSubmitted == submittedDate &&
                                                                                  x.Status == status).elementID;

            _myAnnualLeavePage.ClickOnCreatedAbsence(leaveRequestElementID);
        }

        [Then(@"I click on delete absence button")]
        public void ThenIClickOnDeleteAbsenceButton()
        {
            _myAnnualLeavePage.ClickOnDeleteAbsence();
        }

        [Then(@"I verify the status selected as ""(.*)""")]
        public void ThenIVerifyTheStatusSelectedAs(string statusSelected)
        {
            _myAnnualLeavePage.ValidateStatusSelected(statusSelected);
        }

    }
}
