using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using Uksbs.Connect.AutomatedTests.Common;
using Uksbs.Connect.AutomatedTests.SpecFlowFactory;
using Xunit;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Interactions;
using System.Threading;
using SeleniumExtras.WaitHelpers;

namespace Uksbs.Connect.AutomatedTests.PageObjects
{
    public class MyOvertimePage : BasePage, IClassFixture<SeleniumDriver>
    {
        private readonly IWebDriver webDriver;
        
        private readonly ScenarioContext _scenarioContext;

        private readonly string _myOvertime = "//*[contains(text(),'My Overtime')]";
        private readonly string _createViewOvertimeButton= "//*[contains(text(),'CREATE/VIEW OVERTIME')]";
        private readonly string _clickiIconOvertime = "//*[contains(@title,'My Overtime')]//button/div[@class='oj-button-label']";
        private readonly string _iIconPopuptext = "//*[@id='tooltip-popup-overtime']";
        private readonly string _myOvertimeTitle = "//h1[contains(text(),'My Overtime')]";
        private readonly string _createOvertimeButton = "//button[contains(normalize-space(.),'Create Overtime')]";
        private readonly string _selectPeriod = "//*[contains(text(),'Select Period')]";
        private readonly string _searchPeriod = "//input[@title='Search field']";
        private readonly string _comments = "//textarea[contains(@id,'input')]";
        private readonly string _selectHoursType = "//tr[contains(@class,'oj-focus-highlight')]//oc-field[@aria-label='Select Hours Type']";
        private readonly string _selectDeleteNextRow = "//tr[2]//button[contains(@on-click,'delete')]";
        private readonly string _listbox = "//*[@id='oj-listbox-drop']";
        private readonly string _editIconButton = "//tr[contains(@class,'oj-focus-highlight')]//button[contains(@on-click,'handleUpdate')]";
        private readonly string _selectHoursTypeNextButton = "//tr[2]//oc-field[@aria-label='Select Hours Type']";
        private readonly string _inputSelectHoursType = "//*[@id='oj-listbox-drop']//input[@title='Search field']";
        private readonly string _selectMondayHours = "//tr[contains(@class,'oj-focus-highlight')]//oc-field[contains(@aria-label,'Day 1')]//input[contains(@aria-label,'Overtime amount')]";
        private readonly string _selectMondayHoursNext = "//tr[2]//oc-field[contains(@aria-label,'Day 1')]//input[contains(@aria-label,'Overtime amount')]";

        private readonly string _addOvertime = "//button[@class='overtime-button-create']";
        private readonly string _saveButton = "//button[contains(normalize-space(.),'Save')]";
        private readonly string _overtimeStatus = "//*[@id='overtimeOverviewTable']//div[contains(text(),'Working')]";
        private readonly string _detailsIcon = "//button[@aria-label='Edit Overtime']//following-sibling::button";
        private readonly string _pencilIcon = "//tr[1]//button[@aria-label='Edit Overtime']";
        private readonly string _policyChecbox = "//*[contains(text(),'I have read')]//ancestor::div[@class='overtime-create-disclaimer-note']//input";
        private readonly string _confirmChecbox = "//*[contains(text(),'I confirm')]//ancestor::div[@class='overtime-create-disclaimer-note']//input";
        private readonly string _refineSearchCritera = "//*[contains(text(),'Refine Search Critieria')]";
        private readonly string _selectStatus = "//*[contains(text(),'Select overtime status')]//parent::div";
        private readonly string _fromDate = "//input[@aria-label='Overtime Start Date']";
        private readonly string _toDate = "//input[@aria-label='Overtime End Date']";
        private readonly string _searchButton = "//button[text()='Search']";
        private readonly string _clearButton = "//button[text()='Clear']";
        private readonly string _clickDeleteIcon = "//tr[1]//button[contains(@on-click,'delete')]";
        private readonly string _submitDisabled = "//button[contains(normalize-space(.),'Submit') and @disabled='true']";
        private readonly string _submitEnabled = "//button[contains(normalize-space(.),'Submit') and not(@disabled)]";
        //private readonly string _pencilIcon = "//tr[1]//button[@aria-label='Edit Overtime']";
        //private readonly string _pencilIcon = "//tr[1]//button[@aria-label='Edit Overtime']";
        //private readonly string _pencilIcon = "//tr[1]//button[@aria-label='Edit Overtime']";
        //private readonly string _pencilIcon = "//tr[1]//button[@aria-label='Edit Overtime']";
        //private readonly string _pencilIcon = "//tr[1]//button[@aria-label='Edit Overtime']";

        public MyOvertimePage(IWebDriver webDriver, ScenarioContext scenarioContext) : base(webDriver)
        {
            this.webDriver = webDriver;
            
            _scenarioContext = scenarioContext;
        }

        public void ValidateMyOvertimeTileInDashboard()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_myOvertime)));
            Assert.True(this.IsElementPresent(By.XPath(_myOvertime)));
        }
        public void ValidateCreateOrViewOvertimeButton()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_createViewOvertimeButton)));
            Assert.True(this.IsElementPresent(By.XPath(_createViewOvertimeButton)));
        }
        public void ClickOnIiconOvertime()
        {           
            this.Click(By.XPath(_clickiIconOvertime));
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
            var expectedIconPopupText = "For BEIS, DIT and INSS employees: In line with the policy, permission to work overtime must always be pre-approved by your line manager.";
            var actualIconPopupText = GetIIconPopupText();
            Assert.Contains(expectedIconPopupText, actualIconPopupText);
        }
        public void ClickOnCreateOrViewOvertime()
        {           
            this.Click(By.XPath(_createViewOvertimeButton));
        }
        public string GetMyOvertimeTitle()
        {           
            this.Find(By.XPath(_myOvertimeTitle));
            string result = FindElementXPath(_myOvertimeTitle);
            return result;
        }
        public void ClickOnCreateOvertimeButton()
        {           
            this.Click(By.XPath(_createOvertimeButton));
        }
        public void SelectPeriod(string period)
        {           
            this.Click(By.XPath(_selectPeriod));
            this.TypeSearchClick(period, By.XPath(_searchPeriod));
        }
        public void EnterComments(string comments)
        {          
            this.Click(By.XPath(_comments));
            this.Type(comments, By.XPath(_comments));
        }
        public void SelectHoursType(string hoursType)
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementExists(By.XPath(_selectHoursType)));
            Actions act = new Actions(WebDriver);
            var clickSelectHoursType = this.Find(By.XPath(_selectHoursType));
            act.DoubleClick(clickSelectHoursType).Perform();
            Thread.Sleep(1000); 

            //this.Type(hoursType, By.XPath(_selectHoursType));
            this.Click(By.XPath(_selectHoursType));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_listbox)));           

            this.TypeSearchClick(hoursType, By.XPath(_inputSelectHoursType));
        }
        public void SelectHoursTypeNextRow(string hoursType)
        {
            this.ClickTab(By.XPath(_selectDeleteNextRow));
            var wait = new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(Constants.ShortWaitTime));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(_selectHoursTypeNextButton)));
            Actions act = new Actions(WebDriver);
            var clickSelectHoursType = this.Find(By.XPath(_selectHoursTypeNextButton));
            act.DoubleClick(clickSelectHoursType).Perform();
            //this.ClickTab(By.XPath(_selectDeleteNextRow));
            //this.PressKeyDown(By.XPath(_selectHoursTypeNextButton));
            //this.Click(By.XPath(_editIconButton));
            this.Click(By.XPath(_selectHoursTypeNextButton));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_listbox)));

            this.TypeSearchClick(hoursType, By.XPath(_inputSelectHoursType));
        }
        public void EnterOvertimePeriod(decimal period)
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementExists(By.XPath(_selectMondayHours)));

            Actions act = new Actions(WebDriver);
            var clickSelectHours = this.Find(By.XPath(_selectMondayHours));
            act.DoubleClick(clickSelectHours).Perform();

            this.Type(period.ToString(), By.XPath(_selectMondayHours));
        }

        public void EnterOvertimePeriodNext(decimal period)
        {
            var wait = new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(Constants.ShortWaitTime));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(_selectMondayHoursNext)));

            Actions act = new Actions(WebDriver);
            var clickSelectHours = this.Find(By.XPath(_selectMondayHoursNext));
            act.DoubleClick(clickSelectHours).Perform();

            this.Type(period.ToString(), By.XPath(_selectMondayHoursNext));
        }
        public void ClickOnAddOvertime()
        {           
            this.Click(By.XPath(_addOvertime));
        }
        public void ClickOnSave()
        {           
            this.Click(By.XPath(_saveButton));
        }
        public void ValidateMyOvertimeAdded()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_overtimeStatus)));
            Assert.True(this.IsElementPresent(By.XPath(_overtimeStatus)));
        }
        public void ClickOnDetailsiCon()
        {           
            this.Click(By.XPath(_detailsIcon));
        }
        public string GetMyOvertimeHoursType(string hoursType)
        {
            string hoursTypeXPath = "//*[text()='"+ hoursType +"']";
           
            this.Find(By.XPath(hoursTypeXPath));
            string result = FindElementXPath(hoursTypeXPath);
            return result;
        }
        public string GetMyOvertimeHours(string hours)
        {            
            string hoursTypeXPath = "//*[text()='" + hours + "']";           
            this.Find(By.XPath(hoursTypeXPath));
            string result = FindElementXPath(hoursTypeXPath);
            return result;
        }
        public void ClickOnPenciliCon()
        {           
            this.Click(By.XPath(_pencilIcon));
        }

        public void UpdateHoursType(string hoursType)
        {
            var hoursTypeXPath = "//span[text()='" + hoursType + "']//ancestor::tr//button[contains(@on-click,'handleUpdate')]";
            
            var hoursTypeXPath1 = "//span[text()='" + hoursType + "']//ancestor::oj-select-one";
            var wait = getDriverWait();
            this.Click(By.XPath(hoursTypeXPath));
            //Actions act = new Actions(WebDriver);
            //var clickSelectHoursType = this.Find(By.XPath(hoursTypeXPath));
            //act.DoubleClick(clickSelectHoursType).Perform();

            //Thread.Sleep(1000);
            this.Type(hoursType, By.XPath(hoursTypeXPath1));
            //this.Click(By.XPath(hoursTypeXPath));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_listbox)));

           // var inputSelectHoursType = "//*[@id='oj-listbox-drop']//ul/li[1]/div[contains(text(),'Select')]";
            this.TypeSearchClick(hoursType, By.XPath(_inputSelectHoursType));
        }
        public void TickCheckboxes()
        {           
            this.Click(By.XPath(_policyChecbox));
            this.Click(By.XPath(_confirmChecbox));
        }
        public void TickPolicyCheckbox()
        {
            this.Click(By.XPath(_policyChecbox));
        }
        public void TickConfirmCheckbox()
        {
            this.Click(By.XPath(_confirmChecbox));
        }
        public void ValidateUpdateIcon()
        {
            Assert.False(this.IsElementPresent(By.XPath(_pencilIcon)));
        }
        public void ClickOnRefineSearchCriteria()
        {
            this.Click(By.XPath(_refineSearchCritera));
        }
        public void SelectStatus(string status)
        {
            this.Click(By.XPath(_selectStatus));
            this.TypeSearchClick(status, By.XPath(_searchPeriod));
        }
        public void EnterFromDate(string fromDate)
        {
            this.Click(By.XPath(_fromDate));
            this.Type(fromDate, By.XPath(_fromDate));
        }
        public void EnterToDate(string toDate)
        {
            this.Click(By.XPath(_toDate));
            this.Type(toDate, By.XPath(_toDate));
        }
        public void ClickSearchButton()
        {
            this.Click(By.XPath(_searchButton));
        }
        public void ClickClearButton()
        {
            this.Click(By.XPath(_clearButton));
        }
        public void ValidateSelectStatusAsCleared()
        {
            Assert.True(this.IsElementPresent(By.XPath(_selectStatus)));
        }
        public void ClickODeleteIcon()
        {
            this.Click(By.XPath(_clickDeleteIcon));
        }
        public void ValidateAddOvertimeDeleted(string hoursType)
        {
            string hoursTypeXPath = "//*[contains(text(),'"+ hoursType +"')]";
           // Assert.False(this.IsElementPresent(By.XPath(hoursTypeXPath)));
        }
        public void ValidateTotal()
        {
            this.ClickEscape(By.XPath(_selectMondayHoursNext));

            var hour1Value = GetHours1();
            var hours1 = decimal.Parse(hour1Value);
            var hour2Value = GetHours2();
            var hours2 = decimal.Parse(hour2Value);
            var total = hours1 + hours2;

            var totalXPath = "//*[text()='"+ total + "']";

            Assert.True(this.IsElementPresent(By.XPath(totalXPath)));
        }
        public string GetHours1()
        {
          //  this.Find(By.XPath(_selectMondayHours));
            string result = FindElementXPath(_selectMondayHours);
            return result;
        }
        public string GetHours2()
        {
            this.Find(By.XPath(_selectMondayHoursNext));
            string result = FindElementXPath(_selectMondayHoursNext);
            return result;
        }
        public void ValidateDisabledSubmit()
        {
            Assert.True(this.IsElementPresent(By.XPath(_submitDisabled)));
        }
        public void ValidateEnabledSubmit()
        {
            Assert.True(this.IsElementPresent(By.XPath(_submitEnabled)));
        }
        private WebDriverWait getDriverWait()
        {
            return new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(Constants.DefaultWaitTime));
        }
    }
}
