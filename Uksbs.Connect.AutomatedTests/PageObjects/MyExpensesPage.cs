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
using System.IO;
using SeleniumExtras.WaitHelpers;

namespace Uksbs.Connect.AutomatedTests.PageObjects
{
    public class MyExpensesPage : BasePage, IClassFixture<SeleniumDriver>
    {
        private readonly IWebDriver webDriver;
        
        private readonly ScenarioContext _scenarioContext;

        private readonly string _myExpenses = "//*[contains(text(),'My Expenses')]";
        private readonly string _createViewExpensesButton = "//*[contains(text(),'CREATE/VIEW EXPENSES')]";
        private readonly string _myExpenseClaimsTitle = "//h1[contains(text(),'My Expense Claims')]";
        private readonly string _createExpenseClaimButton = "//button[contains(normalize-space(.),'Create expense claim')]";
        private readonly string _statusLabel = "//label[contains(normalize-space(.),'Status')]";
        private readonly string _startDateLabel = "//label[contains(normalize-space(.),'Start date')]";
        private readonly string _endDateLabel = "//label[contains(normalize-space(.),'End date')]";
        private readonly string _clearFilters = "//button[contains(normalize-space(.),'Clear Filters')]";
        private readonly string _expenseClaimSetup = "//h1[contains(text(),'Expense Claim Setup')]";
        private readonly string _ukClaimsTile = "//h2[contains(text(),'UK Claims')]";
        private readonly string _gpcTile = "//h2[contains(text(),'Government Procurement Card (GPC)')]";
        private readonly string _overseasClaimsTile = "//h2[contains(text(),'Overseas Claims')]";
        private readonly string _viewMyExpenseClaims = "//oc-icon-button[@text='My Expense Claims']/button";

        private readonly string _existingClaim = "//div[@class='content oj-swipeactions-content']";
        private readonly string _reviewExpenseClaim = "//h1[contains(text(),'Review Expense Claim')]";

        private readonly string _expandClaim = "//tr[1]//button[@title='Expand line for more details']";
        private readonly string _additionalExpenseDetails = "//additional-expense-details-form//h3[contains(normalize-space(.),'Additional Expense Details')]";
        private readonly string _expenseAllocation = "//additional-expense-details-form//following-sibling::allocations-form//h3[contains(normalize-space(.),'Expense Allocations')]";
        private readonly string _viewAttachment = "//button[@title='Add Item Receipt']";
        private readonly string _view = "//button[text()='View']";
        private readonly string _bill = "//*[@id='iframe']";
        private readonly string _close = "//button[text()='Close']";
        private readonly string _back = "//button[text()='Back']";
        private readonly string _selectUKExpenseTemplate = "//button[@title='Select UK Expense Template']";
        private readonly string _expenseClaimDescription = "//input[@aria-label='Expense claim description']";
        private readonly string _nextButton = "//button/span[text()='Next']";
        private readonly string _expenseDate = "//input[@aria-label='Expense Date']";
        private readonly string _expenseAmount = "//input[@aria-label='Expense amount']";
        private readonly string _selectType = "//*[contains(text(),'Select type')]//ancestor::div[contains(@class,'select no-label')]";
        private readonly string _inputType = "//*[@id='oj-listbox-drop']//input[@title='Search field']";
        private readonly string _selectCurrency = "//*[contains(text(),'Currency code')]//parent::div[contains(@aria-label,'Currency code')]";
        private readonly string _justification = "//input[@aria-label='Justification']";
        private readonly string _addButton = "//button/p[text()='Add']";
        private readonly string _editButton = "//button[text()='Edit']";
        private readonly string _tripDistance = "//input[@aria-label='Trip distance in miles']";
        private readonly string _errorMessage = "//*[@id='notice-summary']";
        private readonly string _closeNotice = "//*[@id='oc-notice-close-btn']/oc-icon";
        private readonly string _mileage = "//button/span[contains(normalize-space(.),'Mileage')]";
        private readonly string _receipt = "//button/span[contains(normalize-space(.),'Receipt')]";
        private readonly string _submitClaimCheckbox = "//input[@id='submitClaim']";
        private readonly string _viewMyExpenses = "//button[contains(normalize-space(.),'View my expenses')]";
        private readonly string _approverComments = "//textarea[@aria-label='Approver comments']";
        private readonly string _approve = "//button[contains(normalize-space(.),'Approve')]";
        private readonly string _reject = "//button[contains(normalize-space(.),'Reject')]";
        private readonly string _markAsRead = "//button[contains(normalize-space(.),'Mark as Read')]";
        private readonly string _delete = "//button[contains(normalize-space(.),'Delete')]";
        private readonly string _confirmDeletion = "//*[contains(text(),'Confirm Deletion')]";
        private readonly string _yesButton = "//button//*[text()='Yes']";
        private readonly string _addAttachments = "//oc-icon-button[@icon-name='attachments']";
        private readonly string _attachmentTitle = "//input[@aria-label='Enter an attachment title']";
        private readonly string _attachmentDescription = "//textarea[@aria-label='Enter an attachment description']";
        private readonly string _filePath = "//input[@id='file-picker']";
        private readonly string _add = "//button/span[text()='Add']";
        private readonly string _expenseList = "//ul[contains(@id,'ui-id')]";
        private readonly string _remove = "//button[text()='Remove']";
        private readonly string _withdraw = "//button[text()='Withdraw']";
        private readonly string _confirmWithdraw = "//*[contains(text(),'Confirm Withdrawal')]";
        private readonly string _manageAttachments = "//oc-icon-button[@alt='Add and manage attachments']//span[text()='1']";
        private readonly string _selectOverseasClaimsTemplate = "//button[@title='Select Overseas Template']";
        private readonly string _selectGPCTemplate = "//button[@title='Select GPC Template']";
        private readonly string _listbox = "//*[@id='oj-listbox-drop']";
        private readonly string _expenseAllocations = "//oc-icon-button[@alt='Expense Allocations']";
        private readonly string _costCentre = "//claim-allocations-view//oj-select-one[@aria-label='Cost Centre']";
        private readonly string _programme = "//claim-allocations-view//oj-select-one[@aria-label='Programme']";
        private readonly string _analysis1 = "//claim-allocations-view//oj-select-one[@aria-label='Analysis1']";
        private readonly string _applyAll = "//button[contains(normalize-space(.),'Apply to all')]";
        private readonly string _updateCostCentre = "//tr[@class='expandable expanded']//oj-select-one[contains(@aria-label,'Cost Centre')]";
        private readonly string _updateProgramme = "//tr[@class='expandable expanded']//oj-select-one[contains(@aria-label,'Programme')]";
        private readonly string _updateAnalysis1 = "//tr[@class='expandable expanded']//oj-select-one[contains(@aria-label,'Analysis1')]";
        public MyExpensesPage(IWebDriver webDriver, ScenarioContext scenarioContext) : base(webDriver)
        {
            this.webDriver = webDriver;
            
            _scenarioContext = scenarioContext;
        }

        public void ValidateMyExpensesTileInDashboard()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_myExpenses)));
            Assert.True(this.IsElementPresent(By.XPath(_myExpenses)));
        }
        public void ValidateCreateOrViewExpensesButton()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_createViewExpensesButton)));
            Assert.True(this.IsElementPresent(By.XPath(_createViewExpensesButton)));
        }
        
        public void ClickOnCreateOrViewExpenses()
        {
           
            this.Click(By.XPath(_createViewExpensesButton));
        }
        public string GetMyExpenseTitle()
        {
           
            this.Find(By.XPath(_myExpenseClaimsTitle));
            string result = FindElementXPath(_myExpenseClaimsTitle);
            return result;
        }
        public void ValidateMyExpenseClaimsPage()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_myExpenseClaimsTitle)));
            Assert.True(this.IsElementPresent(By.XPath(_myExpenseClaimsTitle)));
            Assert.True(this.IsElementPresent(By.XPath(_createExpenseClaimButton)));
            Assert.True(this.IsElementPresent(By.XPath(_statusLabel)));
            Assert.True(this.IsElementPresent(By.XPath(_startDateLabel)));
            Assert.True(this.IsElementPresent(By.XPath(_endDateLabel)));
            Assert.True(this.IsElementPresent(By.XPath(_clearFilters)));
        }
        public void ClickOnCreateExpenseClaimButton()
        {
           
            this.Click(By.XPath(_createExpenseClaimButton));
        }
        public void ValidateExpenseClaimSetupPage()
        {
           
            Assert.True(this.IsElementPresent(By.XPath(_expenseClaimSetup)));
            Assert.True(this.IsElementPresent(By.XPath(_ukClaimsTile)));
            Assert.True(this.IsElementPresent(By.XPath(_gpcTile)));
            Assert.True(this.IsElementPresent(By.XPath(_overseasClaimsTile)));
        }
        public void ClickOnMyExpenseClaims()
        {
           
            this.Click(By.XPath(_viewMyExpenseClaims));
        }
        public void ClickOnMyExistingClaim()
        {
           
            this.Click(By.XPath(_existingClaim));
        }
        public void ValidateReviewExpenseClaimPage()
        {
           
            Assert.True(this.IsElementPresent(By.XPath(_reviewExpenseClaim)));           
        }
        public void ClickOnThreeDotsToExpandClaim()
        {
           
            this.Click(By.XPath(_expandClaim));
        }
        public void ValidateAdditionalExpenses()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_additionalExpenseDetails)));
            Assert.True(this.IsElementPresent(By.XPath(_additionalExpenseDetails)));
            Assert.True(this.IsElementPresent(By.XPath(_expenseAllocation)));
        }
        public void ClickOnExpenseAllocation()
        {
           
            this.Click(By.XPath(_expenseAllocations));
        }
        public void SelectCostCentre(string costCentre)
        {
           
            this.Click(By.XPath(_costCentre));
            this.TypeSearchClick(costCentre, By.XPath(_inputType));
        }
        public void SelectProgramme(string programme)
        {
           
            this.Click(By.XPath(_programme));
            this.TypeSearchClick(programme, By.XPath(_inputType));
        }
        public void SelectAnalysis1(string analysis1)
        {
           
            this.Click(By.XPath(_analysis1));
            this.TypeSearchClick(analysis1, By.XPath(_inputType));
        }

        public void ClickApplyAll()
        {
           
            this.Click(By.XPath(_applyAll));
        }
        public void UpdateCostCentre(string costCentre)
        {
           
            this.Click(By.XPath(_updateCostCentre));
            this.TypeSearchClick(costCentre, By.XPath(_inputType));
        }
        public void UpdateProgramme(string programme)
        {
           
            this.Click(By.XPath(_updateProgramme));
            this.TypeSearchClick(programme, By.XPath(_inputType));
        }
        public void UpdateAnalysis1(string analysis1)
        {
           
            this.Click(By.XPath(_updateAnalysis1));
            this.TypeSearchClick(analysis1, By.XPath(_inputType));
        }
        public void ClickOnExpenseClaimCard(string createdExpenseForClick_elementID)
        {
            this.Click(By.XPath("//li[contains(@id,'" + createdExpenseForClick_elementID + "')]"));
        }

        public void ClickOnAttachmentsView()
        {
           
            this.Click(By.XPath(_viewAttachment));
        }
        public void ClickView()
        {
           
            this.Click(By.XPath(_view));
        }
        public void ValidateReceipt()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_bill)));
            Assert.True(this.IsElementPresent(By.XPath(_bill)));
        }
        public void ClickClose()
        {
           
            this.Click(By.XPath(_close));
        }
        public void ClickBack()
        {
           
            this.Click(By.XPath(_back));
        }
        public void ClickUKClaimSelectTemplate()
        {
           
            this.Click(By.XPath(_selectUKExpenseTemplate));
        }
        public void EnterExpenseClaimDescription(string description)
        {
           
            this.Click(By.XPath(_expenseClaimDescription));
            this.Type(description, By.XPath(_expenseClaimDescription));
        }
        public void ClickNextButton()
        {
           
            this.Click(By.XPath(_nextButton));
        }
        public void ClickWithdrawButton()
        {
           
            this.Click(By.XPath(_withdraw));
        }
        public void SelectDate(string expenseDate)
        {
           
            this.Click(By.XPath(_expenseDate));
            this.Type(expenseDate, By.XPath(_expenseDate));
            this.ClickEscape(By.XPath(_expenseDate));
        }
        public void EnterExpenseAmount(string amount)
        {
           
            this.Click(By.XPath(_expenseAmount));
            this.Type(amount, By.XPath(_expenseAmount));
        }
        public void SelectExpenseType(string expenseType)
        {
           
            this.Click(By.XPath(_selectType));
            this.TypeSearchClick(expenseType, By.XPath(_inputType));
        }
        public void SelectCurrency(string currency)
        {
            var wait = getDriverWait();
            this.Click(By.XPath(_selectCurrency));
            this.Click(By.XPath(_selectCurrency));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_listbox)));
            if (!this.IsElementPresent(By.XPath(_listbox)))
            {
                this.ClickEnter(By.XPath(_selectCurrency));
            }

            this.TypeSearchClick(currency, By.XPath(_inputType));
        }
        public void EnterExpenseJustification(string justification)
        {
            this.Click(By.XPath(_justification));
            this.Type(justification, By.XPath(_justification));
        }
        public void ClickAddButton()
        {
            this.Click(By.XPath(_addButton));
        }
        public void ClickEditButton()
        {           
            this.Click(By.XPath(_editButton));
        }
        public void ClickMileage()
        {
           
            this.Click(By.XPath(_mileage));
        }
        public void ClickReceipt()
        {
           
            this.Click(By.XPath(_receipt));
        }
        public void EnterTripDistance(int miles)
        {
           
            this.Click(By.XPath(_tripDistance));
            this.Type(miles.ToString(), By.XPath(_tripDistance));
        }
        public string GetErrorMessage()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_errorMessage)));
            this.Find(By.XPath(_errorMessage));
            string result = FindElementXPath(_errorMessage);
            return result;
        }
        public void ClickCloseNotice()
        {
           
            this.Click(By.XPath(_closeNotice));
        }
        public void ClickSubmitClaimCheckbox()
        {
           
            this.Click(By.XPath(_submitClaimCheckbox));
        }
        public void ClickViewMyExpenses()
        {
           
            this.Click(By.XPath(_viewMyExpenses));
        }
        public void EnterApproverComments(string approverComments)
        {
           
            this.Click(By.XPath(_approverComments));
            this.Type(approverComments, By.XPath(_approverComments));
        }
        public void ClickApprove()
        {
           
            this.Click(By.XPath(_approve));
        }
        public void ClickReject()
        {
           
            this.Click(By.XPath(_reject));
        }

        public void ClickMarkAsRead()
        {
           
            this.Click(By.XPath(_markAsRead));
        }
        public void ClickDelete()
        {
           
            this.Click(By.XPath(_delete));
        }
        public void ValidateConfirmDeletion()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_confirmDeletion)));
            Assert.True(this.IsElementPresent(By.XPath(_confirmDeletion)));
        }
        public void ClickYes()
        {
           
            this.Click(By.XPath(_yesButton));
        }
        public void ValidateConfirmWithdraw()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_confirmWithdraw)));
            Assert.True(this.IsElementPresent(By.XPath(_confirmWithdraw)));
        }
        public void ClickAddAttachments()
        {
           
            this.Click(By.XPath(_addAttachments));
        }
        public void EnterAttachmentTitle(string title)
        {
           
            this.Click(By.XPath(_attachmentTitle));
            this.Type(title, By.XPath(_attachmentTitle));
        }
        public void EnterAttachmentDescription(string description)
        {
           
            this.Click(By.XPath(_attachmentDescription));
            this.Type(description, By.XPath(_attachmentDescription));
        }
        public void ClickOnChooseFile()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementExists(By.XPath(_filePath)));
            var testDataFolder = @"/TestData/";
            var testDataPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + testDataFolder;
            var file = Directory.GetFiles(testDataPath, "*.jpg");
            IWebElement fileUpload = WebDriver.FindElement(By.XPath(_filePath));
            fileUpload.SendKeys(file[0]);
        }
        public void ClickAdd()
        {
           
            this.Click(By.XPath(_add));
        }
        
        public void ClickRemove()
        {
           
            this.Click(By.XPath(_remove));
        }
        public void ValidateManageAttachments()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_manageAttachments)));
            Assert.True(this.IsElementPresent(By.XPath(_manageAttachments)));
        }

        public void ClickOverseasClaimSelectTemplate()
        {
           
            this.Click(By.XPath(_selectOverseasClaimsTemplate));
        }
        public void ClickGPCSelectTemplate()
        {
           
            this.Click(By.XPath(_selectGPCTemplate));
        }
        private WebDriverWait getDriverWait()
        {
            return new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(Constants.DefaultWaitTime));
        }

        public MyExpenseClaims GetAllMyExpenseClaims()
        {
            this.Find(By.XPath(_expenseList));
            MyExpenseClaims myExpenseClaims = null;

            if (this.IsElementPresent(By.XPath(_expenseList)))
            {
                IWebElement ulExpenseClaims = WebDriver.FindElement(By.XPath(_expenseList));

                List<IWebElement> listItemsOfExpenseClaims = new List<IWebElement>(ulExpenseClaims.FindElements(By.TagName("li")));
                myExpenseClaims = new MyExpenseClaims();
                myExpenseClaims.ExpenseClaims = new List<ExpenseClaim>();
                ExpenseClaim expenseClaim = null;

                foreach (var listItem in listItemsOfExpenseClaims)
                {

                    expenseClaim = new ExpenseClaim();
                    IWebElement farLeftMainInfo = listItem.FindElement(By.ClassName("item-main-info"));
                    var infoParagraphs = farLeftMainInfo.FindElements(By.TagName("p"));
 
                    var descriptionItems = infoParagraphs[0].Text.Split('|');
                    expenseClaim.Id = descriptionItems[0].Trim();
                    expenseClaim.Description = descriptionItems[1].Trim();

                    var itemsAndAmount = infoParagraphs[1].Text.Split('|');
                    expenseClaim.TotalExpenseItems = itemsAndAmount[0].Trim();
                    expenseClaim.TotalExpenseAmount = itemsAndAmount[1].Trim();


                    if(infoParagraphs[2].Text.Contains('|'))
                    {
                        var submittedDateAndApprover = infoParagraphs[2].Text.Split('|');
                        expenseClaim.DateSubmitted = submittedDateAndApprover[0].Trim();
                        expenseClaim.ApproverInfo = submittedDateAndApprover[1].Trim();
                    }
                    else
                    {
                        expenseClaim.ApproverInfo = infoParagraphs[2].Text.Trim();
                    }


                    expenseClaim.elementID = listItem.GetAttribute("id");
                    IWebElement farRightAdditionalInfo = listItem.FindElement(By.CssSelector(".item-additional-info.oj-complete"));

                   // IWebElement farRightAdditionalInfo = listItem.FindElement(By.ClassName("item-additional-info"));
                    infoParagraphs = farRightAdditionalInfo.FindElements(By.TagName("p"));

                    if (infoParagraphs.Count > 1)
                    {
                        expenseClaim.HeadsUpMessage = infoParagraphs[0].Text.Trim();
                        expenseClaim.Status = infoParagraphs[1].Text.Trim();
                    }
                    else if (infoParagraphs.Count == 1)
                    {
                        expenseClaim.HeadsUpMessage = string.Empty;
                        expenseClaim.Status = infoParagraphs[0].Text.Trim();
                    }
                    else
                    {
                        expenseClaim.HeadsUpMessage = string.Empty;
                        expenseClaim.Status = string.Empty;
                    }


                   // expenseClaim.Status = infoParagraphs[0].Text;
                    myExpenseClaims.ExpenseClaims.Add(expenseClaim);
                }


            }

            return myExpenseClaims;
        }



    }
}
