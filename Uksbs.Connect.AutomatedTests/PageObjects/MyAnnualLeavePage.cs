using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using Uksbs.Connect.AutomatedTests.Common;
using Uksbs.Connect.AutomatedTests.SpecFlowFactory;
using Xunit;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using System.Threading;
using SeleniumExtras.WaitHelpers;

namespace Uksbs.Connect.AutomatedTests.PageObjects
{
    public class MyAnnualLeavePage : BasePage, IClassFixture<SeleniumDriver>
    {
        private readonly IWebDriver webDriver;
        
        private readonly ScenarioContext _scenarioContext;

        private readonly string _myAnnualLeave = "//h2[contains(text(),'My Annual Leave')]";
        private readonly string _pieChart = "//div[@class='my-absence-tile-component']//oj-chart[@id='pieChart']";
        private readonly string _noOfHolidaysInPieChart = "//myholiday-balance//p[@class='number']";
        private readonly string _daysRemainingInPieChart = "//myholiday-balance//p[@class='text']";
        private readonly string _clickIicon = "//div[@class='my-absence-tile-component']//button/div[@class='oj-button-label']";
        private readonly string _iIconPopuptext = "//div[@id='tooltip-popup-holiday']";
        private readonly string _iIconPopupClose = "//div[@class='popuptext show']//div[@id='popuptext-messageclose']";
        private readonly string _createViewLeave = "//span[contains(text(),'CREATE/VIEW LEAVE')]";
        private readonly string _myAbsencesTitle = "//h1[contains(text(),'My Absences')]";
        private readonly string _teamCalender = "//oc-icon-button[@text='Team calendar']//oc-icon";
        private readonly string _createAbsenceButton = "//button[contains(normalize-space(.),'Create absence')]";
        private readonly string _statusAll = "//span[contains(text(),'All')]";
        private readonly string _statusApproved = "//span[contains(text(),'Approved')]";
        private readonly string _statusPending = "//span[contains(text(),'Pending')]";
        private readonly string _statusTaken = "//span[contains(text(),'Taken')]";
        private readonly string _verifyStatusSelected = "//span[contains(@class,'oj-selected')]";
        private readonly string _selectAbsenceType = "//div[@aria-label='Select absence type']/a";
        private readonly string _absenceStartDate = "//input[contains(@aria-label,'Absence Start Date')]";
        private readonly string _absenceEndDate = "//input[contains(@aria-label,'Absence end date')]";
        private readonly string _clearFilters = "//button[contains(normalize-space(.),'Clear Filters')]";
        private readonly string _errorMessagePastDuplicate = "//oc-toast/div[@role='alert']//p[1]";

        private readonly string _holidayBalance = "//h2[contains(text(),'Holiday balance')]";

        private readonly string _createAbsenceTitle = "//h2[contains(normalize-space(.),'Create Absence')]";
        private readonly string _clickTypeInCreateAbsence = "//span[contains(text(),'Absence Type')]";
        private readonly string _selectTypeInCreateAbsence = "//*[@id='oj-listbox-drop']//input[@aria-label='Absence Type']";
        private readonly string _clickReasonInCreateAbsence = "//span[contains(text(),'Absence Reason')]";
        private readonly string _selectReasonInCreateAbsence = "//*[@id='oj-listbox-drop']//input[@aria-label='Absence Reason']";

        private readonly string _selectAbsenceStartDate = "//input[contains(@aria-label,'Absence Start Date')]";
        private readonly string _selectAbsenceEndDate = "//input[contains(@aria-label,'Absence End Date')]";
        private readonly string _selectDuration = "//input[contains(@aria-label,'Duration')]";
        private readonly string _createAbsenceSubmit = "//button[contains(normalize-space(.),'Submit')]";
        private readonly string _closeButton = "//button[@id='toast-close-button']";
        private readonly string _validateSubmitDisabled = "//button[contains(normalize-space(.),'Submit') and @disabled='true']";
        private readonly string _createAbsenceCancel = "//button[contains(normalize-space(.),'Cancel')]";
        private readonly string _listOfMyLeaves = "//absences-list/oc-list/div[@class='list-area']";

        private readonly string _notificationStateAll = "//span[contains(text(),'All')]";
        private readonly string _notificationStateToAction = "//span[contains(text(),'To action')]";
        private readonly string _notificationStateMessages = "//span[contains(text(),'Messages')]";
        private readonly string _acceptLeave = "//button[contains(normalize-space(.),'Accept')]";
        private readonly string _declineLeave = "//button[contains(normalize-space(.),'Decline')]";
        private readonly string _toAction = "//p[contains(normalize-space(.),'To action')]";
        private readonly string _absenceList = "//ul[contains(@id,'ui-id')]";
        private readonly string _clickDeleteAbsence = "//button[contains(normalize-space(.),'Delete absence')]";
        private readonly string _viewMenu = "//nav[@aria-label='Product navigation']//button[@title='View Menu']";
        private readonly string _absence = "//button[@id='absence-link']";

        public MyAnnualLeavePage(IWebDriver webDriver, ScenarioContext scenarioContext) : base(webDriver)
        {
            this.webDriver = webDriver;
            
            _scenarioContext = scenarioContext;
        }

        public void ClickViewMenu()
        {
           
            this.Click(By.XPath(_viewMenu));
        }
        public void ClickAbsence()
        {
           
            this.Click(By.XPath(_absence));
        }
        public void ValidateMyAnnualLeaveTileInDashboard()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_myAnnualLeave)));
            Assert.True(this.IsElementPresent(By.XPath(_myAnnualLeave)));
        }
        public void ValidatePieChart()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_pieChart)));

            Assert.True(this.IsElementPresent(By.XPath(_pieChart)));
        }

        public string GetNoOfHolidays()
        {
            this.Find(By.XPath(_noOfHolidaysInPieChart));
            string result = FindElementXPath(_noOfHolidaysInPieChart);
            return result;
        }
        public string GetRemainingDays()
        {
            this.Find(By.XPath(_daysRemainingInPieChart));
            string result = FindElementXPath(_daysRemainingInPieChart);
            return result;
        }
        public void ClickIIcon()
        {
           
            this.Click(By.XPath(_clickIicon));
        }
        public string GetIIconPopupText()
        {
            this.Find(By.XPath(_iIconPopuptext));
            string result = FindElementXPath(_iIconPopuptext);
            return result;
        }
        public void ValidateIIconPopupText()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_iIconPopuptext)));
            var expectedIconPopupText = "All staff should now record their annual leave here, unless you are exempt.";
            var actualIconPopupText = GetIIconPopupText();
            Assert.Contains(expectedIconPopupText, actualIconPopupText);
        }

        public void ClickOnCreatedAbsence(string createdAbsenceForClick_elementID)
        {
            this.Click(By.XPath("//li[contains(@id,'" + createdAbsenceForClick_elementID + "')]"));
        }

        public void ClickIIconPopupClose()
        {
           
            this.Click(By.XPath(_iIconPopupClose));
        }

        public void ClickOnCreateOrViewLeave()
        {
           
            this.Click(By.XPath(_createViewLeave));
        }
        public string GetMyAbsencesTitle()
        {
           
            this.Find(By.XPath(_myAbsencesTitle));
            string result = FindElementXPath(_myAbsencesTitle);
            return result;
        }
        public string GetStatusAll()
        {
            this.Find(By.XPath(_statusAll));
            string result = FindElementXPath(_statusAll);
            return result;
        }
        public string GetStatusApproved()
        {
            this.Find(By.XPath(_statusApproved));
            string result = FindElementXPath(_statusApproved);
            return result;
        }
        public string GetStatusPending()
        {
            this.Find(By.XPath(_statusPending));
            string result = FindElementXPath(_statusPending);
            return result;
        }
        public string GetStatusTaken()
        {
            this.Find(By.XPath(_statusTaken));
            string result = FindElementXPath(_statusTaken);
            return result;
        }
        public void ValidateStatusSelected(string selectedStatus)
        {
            var verifyStatusSelected = "//span[contains(@class,'oj-selected' )]//span[contains(text(),'" + selectedStatus + "')]";
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(verifyStatusSelected)));
            Assert.True(this.IsElementPresent(By.XPath(verifyStatusSelected)));
        }


        public void ValidateStatusLabels()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_statusAll)));
            Assert.True(this.IsElementPresent(By.XPath(_statusAll)));
            Assert.True(this.IsElementPresent(By.XPath(_statusApproved)));
            Assert.True(this.IsElementPresent(By.XPath(_statusPending)));
            Assert.True(this.IsElementPresent(By.XPath(_statusTaken)));
        }

        public void ValidateTeamCalender()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_teamCalender)));
            Assert.True(this.IsElementPresent(By.XPath(_teamCalender)));
        }
        public void ValidateCreateAbsence()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_createAbsenceButton)));
            Assert.True(this.IsElementPresent(By.XPath(_createAbsenceButton)));
        }
        public void ValidateHolidayBalance()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_holidayBalance)));
            Assert.True(this.IsElementPresent(By.XPath(_holidayBalance)));
        }
        public void ValidateListOfMyLeaves()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_listOfMyLeaves)));
            Assert.True(this.IsElementPresent(By.XPath(_listOfMyLeaves)));
        }
        public void ClickOnTeamCalender()
        {
           
            this.Click(By.XPath(_teamCalender));
        }
        public void ClickOnCreateAbsence()
        {
           
            this.Click(By.XPath(_createAbsenceButton));
        }

        public void ValidateCreateAbsenceTitle()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_createAbsenceTitle)));
            Assert.True(this.IsElementPresent(By.XPath(_createAbsenceTitle)));
        }
        public void ClickOnStatusAll()
        {
           
            this.Click(By.XPath(_statusAll));
        }
        public void ClickOnStatusApproved()
        {
           
            this.Click(By.XPath(_statusApproved));
            this.Click(By.XPath(_statusApproved));
        }
        public void ClickOnStatusPending()
        {
           
            this.Click(By.XPath(_statusPending));
        }
        public void ClickOnStatusTaken()
        {
           
            this.Click(By.XPath(_statusTaken));
        }
        public void ClickOnStatus(string status)
        {
            string statusXPath = "//span[contains(text(),'"+ status +"')]";
           
            this.Click(By.XPath(statusXPath));
            this.Click(By.XPath(statusXPath));
        }
        public void SelectAbsenceType(string absenceType)
        {
           
            this.SearchFromDropdown(By.XPath(_selectAbsenceType));

        }

        public void SelectStartDate(string startDate)
        {
           
            this.Click(By.XPath(_absenceStartDate));
            this.TypeSearchClick(startDate, By.XPath(_absenceStartDate));
        }
        public void SelectEndDate(string endDate)
        {
           
            this.Click(By.XPath(_absenceEndDate));
            this.TypeSearchClick(endDate, By.XPath(_absenceEndDate));
        }
        public void ClickClearFilters()
        {
           
            this.Click(By.XPath(_clearFilters));
        }
        public string GetCreateAbsenceTitle()
        {
            this.Find(By.XPath(_createAbsenceTitle));
            string result = FindElementXPath(_createAbsenceTitle);
            return result;
        }
        public void SelectTypeInCreateAbsence(string absenceType)
        {
           
            this.Click(By.XPath(_clickTypeInCreateAbsence));
            //this.EnterZero(By.XPath(_clickReasonInCreateAbsence));
            this.TypeSearchClick(absenceType, By.XPath(_selectTypeInCreateAbsence));
        }
        public void SelectReasonInCreateAbsence(string absenceType)
        {
           
            this.Click(By.XPath(_clickReasonInCreateAbsence));
            this.TypeSearchClick(absenceType, By.XPath(_selectReasonInCreateAbsence));
        }
        public void SelectAbsenceStartDate(string startDate)
        {
           
            this.Click(By.XPath(_selectAbsenceStartDate));
            this.TypeSearchClick(startDate, By.XPath(_selectAbsenceStartDate));
            this.ClickEscape(By.XPath(_selectAbsenceStartDate));
        }
        public void SelectAbsenceEndDate(string endDate)
        {
           
            this.Click(By.XPath(_selectAbsenceEndDate));
            this.TypeSearchClick(endDate, By.XPath(_selectAbsenceEndDate));
            this.ClickEscape(By.XPath(_selectAbsenceEndDate));
            this.ClickEscape(By.XPath(_selectAbsenceEndDate));
        }
        public void SelectDuration(string duration)
        {           
            this.Click(By.XPath(_selectDuration));
            this.ClearAndType(duration, By.XPath(_selectDuration));
            this.ClickEscape(By.XPath(_selectDuration));
            this.Click(By.XPath(_createAbsenceTitle));
        }
        public void ClickOnSubmit()
        {           
            this.Click(By.XPath(_createAbsenceSubmit));
        }
        public void ClickOnClose()
        {           
            this.Click(By.XPath(_closeButton));
        }
        public void ValidateSubmitDisabled()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_validateSubmitDisabled)));
            Assert.True(this.IsElementPresent(By.XPath(_validateSubmitDisabled)));
        }
        public string GetErrorMessageWhenPastDuplicateAbsenceRequest()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_errorMessagePastDuplicate)));
            this.Find(By.XPath(_errorMessagePastDuplicate));
            string result = FindElementXPath(_errorMessagePastDuplicate);
            return result;
        }
        public void ClickOnNotificationStateAll()
        {
           
            this.Click(By.XPath(_notificationStateAll));
        }

        public void ClickOnNotificationStateToAction()
        {
           
            this.Click(By.XPath(_notificationStateToAction));
        }
        public void ClickOnNotificationStateMessages()
        {
           
            this.Click(By.XPath(_notificationStateMessages));
        }
        public void ClickOnStateToAction()
        {
           
            this.Click(By.XPath(_notificationStateToAction));
        }
        public void ClickOnToAction()
        {
           
            this.Click(By.XPath(_toAction));
        }

        public void ClickOnAcceptLeave()
        {
           
            this.Click(By.XPath(_acceptLeave));
        }
        public void ClickOnDeclineLeave()
        {
           
            this.Click(By.XPath(_declineLeave));
        }

        public void ClickOnDeleteAbsence()
        {
           
            this.Click(By.XPath(_clickDeleteAbsence));
            this.LoadEntirePage();
        }

        public MyAbsenceDashboard GetAbsenceDetails()
        {
            
            this.Find(By.XPath(_absenceList));
            MyAbsenceDashboard myAbsenceDashboard = null;

            if (this.IsElementPresent(By.XPath(_absenceList)))
            {
                IWebElement ulAbsences = WebDriver.FindElement(By.XPath(_absenceList));

                List<IWebElement> listItemsOfAbsences = new List<IWebElement>(ulAbsences.FindElements(By.TagName("li")));
                myAbsenceDashboard = new MyAbsenceDashboard();
                myAbsenceDashboard.AllAbsences = new List<Absence>();
                Absence absence = null;

                foreach (var listItem in listItemsOfAbsences)
                {

                    absence = new Absence();
                    IWebElement farLeftMainInfo = listItem.FindElement(By.ClassName("item-main-info"));
                    var infoParagraphs = farLeftMainInfo.FindElements(By.TagName("p"));
                    absence.Type = infoParagraphs[0].Text;
                    var dateInfo = infoParagraphs[1].Text;

                    var toIndex = dateInfo.ToLower().IndexOf("to");
                    if(toIndex>-1)
                    {
                        var pipeIndex = dateInfo.IndexOf("|");
                        absence.StartDate = dateInfo.Substring(0, toIndex).Trim();
                        absence.EndDate = dateInfo.Substring(toIndex + 2, pipeIndex - toIndex - 2).Trim();
                        absence.Duration = dateInfo.Substring(pipeIndex + 1).Trim();
                    }
                    else
                    {
                        absence.StartDate = dateInfo.ToUpper().Replace("OPEN FROM",string.Empty).Trim();
                        absence.EndDate = string.Empty;
                        absence.Duration = string.Empty;
                    }
                   

                    absence.DateSubmitted = infoParagraphs[2].Text;

                    absence.elementID = listItem.GetAttribute("id");

                    IWebElement farRightAdditionalInfo = listItem.FindElement(By.ClassName("item-additional-info"));
                    infoParagraphs = farRightAdditionalInfo.FindElements(By.TagName("p"));
                    absence.Status = infoParagraphs[0].Text;
                    myAbsenceDashboard.AllAbsences.Add(absence);
                }


            }

            return myAbsenceDashboard;
        }

        public MyAbsenceDashboard GetLeaveRequestDetails()
        {
            this.Find(By.XPath(_absenceList));
            MyAbsenceDashboard myAbsenceDashboard = null;

            if (this.IsElementPresent(By.XPath(_absenceList)))
            {
                IWebElement ulAbsences = WebDriver.FindElement(By.XPath(_absenceList));

                List<IWebElement> listItemsOfAbsences = new List<IWebElement>(ulAbsences.FindElements(By.TagName("li")));
                myAbsenceDashboard = new MyAbsenceDashboard();
                myAbsenceDashboard.AllAbsences = new List<Absence>();
                Absence absence = null;

                foreach (var listItem in listItemsOfAbsences)
                {
                    absence = new Absence();
                    IWebElement farLeftMainInfo = listItem.FindElement(By.ClassName("item-main-info"));
                    var infoParagraphs = farLeftMainInfo.FindElements(By.TagName("p"));
                    absence.LeaveRequest = infoParagraphs[0].Text;
                    var leaveReqInfo = infoParagraphs[1].Text;
                    //  var toIndex = dateInfo.ToLower().IndexOf("to");
                    var pipeIndex = leaveReqInfo.IndexOf("|");
                    absence.DateSubmitted = leaveReqInfo.Substring(0, pipeIndex).Trim();

                    absence.EmpName = leaveReqInfo.Substring(pipeIndex + 2).Trim();
                    absence.elementID = listItem.GetAttribute("id");

                    IWebElement farRightAdditionalInfo = listItem.FindElement(By.ClassName("item-additional-info"));
                    infoParagraphs = farRightAdditionalInfo.FindElements(By.TagName("p"));
                    if (infoParagraphs.Count == 2)
                    {
                        absence.Priority = infoParagraphs[0].Text;
                        absence.ToAction = infoParagraphs[1].Text;
                    }
                    else
                    {
                        absence.ToAction = infoParagraphs[0].Text;
                    }

                    myAbsenceDashboard.AllAbsences.Add(absence);
                }

            }
            return myAbsenceDashboard;
        }
        public MyAbsenceDashboard GetMyDirectReportsList()
        {
            this.Find(By.XPath(_absenceList));
            MyAbsenceDashboard myAbsenceDashboard = null;

            if (this.IsElementPresent(By.XPath(_absenceList)))
            {
                IWebElement ulAbsences = WebDriver.FindElement(By.XPath(_absenceList));

                List<IWebElement> listItemsOfAbsences = new List<IWebElement>(ulAbsences.FindElements(By.TagName("li")));
                myAbsenceDashboard = new MyAbsenceDashboard();
                myAbsenceDashboard.AllAbsences = new List<Absence>();
                Absence absence = null;

                foreach (var listItem in listItemsOfAbsences)
                {
                    absence = new Absence();
                    IWebElement farLeftMainInfo = listItem.FindElement(By.ClassName("item-main-info"));
                    var infoParagraphs = farLeftMainInfo.FindElements(By.TagName("p"));
                    absence.EmpName = infoParagraphs[0].Text;
                    absence.Position = infoParagraphs[1].Text;
                    absence.elementID = listItem.GetAttribute("id");
                    myAbsenceDashboard.AllAbsences.Add(absence);
                }
            }

            return myAbsenceDashboard;
        }

        private WebDriverWait getDriverWait()
        {
            return new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(Constants.DefaultWaitTime));
        }

    }
}
