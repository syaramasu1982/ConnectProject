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
    public sealed class MyExpensesSteps
    {
        private SeleniumContext seleniumContext;
        private IWebDriver webDriver;
        private ScenarioContext _scenarioContext;

        

        private MyExpensesPage _myExpensesPage;
        private MyNotificationsPage _myNotificationsPage;
        private string _notificationClickableElementID;

        public MyExpensesSteps(SeleniumContext seleniumContext, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            //save the context so you can use it in your tests
            this.seleniumContext = seleniumContext;
            this.webDriver = seleniumContext.WebDriver;

            

            // Creating selenium specific instance for login page
            _myExpensesPage = new MyExpensesPage(webDriver, _scenarioContext);
            _myNotificationsPage = new MyNotificationsPage(webDriver, _scenarioContext);
        }

        [Then(@"I should see my expenses tile in dashboard")]
        public void ThenIShouldSeeMyExpensesTileInDashboard()
        {
            _myExpensesPage.ValidateMyExpensesTileInDashboard();
        }

        [Then(@"I should see create/view expenses button")]
        public void ThenIShouldSeeCreateViewExpensesButton()
        {
            _myExpensesPage.ValidateCreateOrViewExpensesButton();
        }

        [When(@"I click on create or view expenses")]
        public void WhenIClickOnCreateOrViewExpenses()
        {
            _myExpensesPage.ClickOnCreateOrViewExpenses();
        }

        [Then(@"I will be redirected to my expense claims page")]
        public void ThenIWillBeRedirectedToMyExpenseClaimsPage()
        {
            _myExpensesPage.GetMyExpenseTitle();
        }

        [When(@"I click on create expense claim button")]
        public void WhenIClickOnCreateExpenseClaimButton()
        {
            _myExpensesPage.ClickOnCreateExpenseClaimButton();
        }

        [Then(@"Expense claim setup should be displayed")]
        public void ThenExpenseClaimSetupShouldBeDisplayed()
        {
            _myExpensesPage.ValidateExpenseClaimSetupPage();
        }

        [Then(@"I validate my expense claims page")]
        public void ThenIValidateMyExpenseClaimsPage()
        {
            _myExpensesPage.ValidateMyExpenseClaimsPage();
        }
        [When(@"I click on my expense claims")]
        public void WhenIClickOnMyExpenseClaims()
        {
            _myExpensesPage.ClickOnMyExpenseClaims();
        }

        [When(@"I click on one of my existing claims")]
        public void WhenIClickOnOneOfMyExistingClaims()
        {
            _myExpensesPage.ClickOnMyExistingClaim();
        }

        [Then(@"Review expense claim page should be displayed")]
        public void ThenReviewExpenseClaimPageShouldBeDisplayed()
        {
            _myExpensesPage.ValidateReviewExpenseClaimPage();
        }

        [When(@"I click on the dots to expand details of the claim")]
        public void WhenIClickOnTheDotsToExpandDetailsOfTheClaim()
        {
            _myExpensesPage.ClickOnThreeDotsToExpandClaim();
        }

        [Then(@"I should see additional expense details and expense allocations")]
        public void ThenIShouldSeeAdditionalExpenseDetailsAndExpenseAllocations()
        {
            _myExpensesPage.ValidateAdditionalExpenses();
        }

        [When(@"I click on the attachments View")]
        public void WhenIClickOnTheAttachmentsView()
        {
            _myExpensesPage.ClickOnAttachmentsView();
        }

        [When(@"I click on view")]
        public void WhenIClickOnView()
        {
            _myExpensesPage.ClickView();
        }

        [Then(@"I should see the attached receipt")]
        public void ThenIShouldSeeTheAttachedReceipt()
        {
            _myExpensesPage.ValidateReceipt();
        }

        [Then(@"I click on close")]
        public void ThenIClickOnClose()
        {
            _myExpensesPage.ClickClose();
        }

        [When(@"I click on back button")]
        public void WhenIClickOnBackButton()
        {
            _myExpensesPage.ClickBack();
        }

        [When(@"I click on uk claims select template")]
        public void WhenIClickOnUkClaimsSelectTemplate()
        {
            _myExpensesPage.ClickUKClaimSelectTemplate();
        }

        [When(@"I click on overseas claims select template")]
        public void WhenIClickOnOverseasClaimsSelectTemplate()
        {
            _myExpensesPage.ClickOverseasClaimSelectTemplate();
        }

        [When(@"I click on select template ""(.*)""")]
        public void WhenIClickOnSelectTemplate(string templateName)
        {
            if (templateName == "UK Claims")
            {
                _myExpensesPage.ClickUKClaimSelectTemplate();
            }
            else if (templateName == "Overseas Claims")
            {
                _myExpensesPage.ClickOverseasClaimSelectTemplate();
            }
            else
            {
                _myExpensesPage.ClickGPCSelectTemplate();
            }

        }

        [Then(@"I enter description as ""(.*)""")]
        public void ThenIEnterDescriptionAs(string description)
        {
            _myExpensesPage.EnterExpenseClaimDescription(description);
        }

        [Then(@"I click on next button")]
        public void ThenIClickOnNextButton()
        {
            _myExpensesPage.ClickNextButton();
        }

        [Then(@"I should see the created uk claim in my list as \|""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""\|")]
        public void ThenIShouldSeeTheCreatedUkClaimInMyListAs(string p0, string p1, string p2, string p3, string p4, string p5)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should see the created uk claim in my list as Saved")]
        public void ThenIShouldSeeTheCreatedUkClaimInMyListAsSaved()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I select expense date as ""(.*)""")]
        public void ThenISelectExpenseDateAs(string expenseDate)
        {
            _myExpensesPage.SelectDate(expenseDate);
        }

        [Then(@"I select currency as ""(.*)""")]
        public void ThenISelectCurrencyAs(string currency)
        {
            if(!(string.IsNullOrEmpty(currency)))
            {
                _myExpensesPage.SelectCurrency(currency);
            }            
        }


        [Then(@"I enter amount as ""(.*)""")]
        public void ThenIEnterAmountAs(string amount)
        {
            _myExpensesPage.EnterExpenseAmount(amount);
        }

        [Then(@"I select expense type as ""(.*)""")]
        public void ThenISelectExpenseTypeAs(string expenseType)
        {
            _myExpensesPage.SelectExpenseType(expenseType);
        }

        [Then(@"I enter justification as ""(.*)""")]
        public void ThenIEnterJustificationAs(string justification)
        {
            _myExpensesPage.EnterExpenseJustification(justification);
        }

        [Then(@"I click add button")]
        public void ThenIClickAddButton()
        {
            _myExpensesPage.ClickAddButton();
        }


        [Then(@"I click on edit button")]
        public void ThenIClickOnEditButton()
        {
            _myExpensesPage.ClickEditButton();
        }

        [Then(@"I click on mileage")]
        public void ThenIClickOnMileage()
        {
            _myExpensesPage.ClickMileage();
        }

        [Then(@"I enter trip distance in miles as ""(.*)""")]
        public void ThenIEnterTripDistanceInMilesAs(int tripDistance)
        {
            _myExpensesPage.EnterTripDistance(tripDistance);
        }

        [Then(@"I should see the error message as ""(.*)""")]
        public void ThenIShouldSeeTheErrorMessageAs(string expectedValue)
        {
            var actualValue = _myExpensesPage.GetErrorMessage();
            Assert.Equal(expectedValue, actualValue);
            _myExpensesPage.ClickCloseNotice();
        }

        [Then(@"I click on receipt")]
        public void ThenIClickOnReceipt()
        {
            _myExpensesPage.ClickReceipt();
        }

        [Then(@"I select submit claim check box")]
        public void ThenISelectSubmitClaimCheckBox()
        {
            _myExpensesPage.ClickSubmitClaimCheckbox();
        }

        [Then(@"I click on view my expenses")]
        public void ThenIClickOnViewMyExpenses()
        {
            _myExpensesPage.ClickViewMyExpenses();
        }

        [Then(@"I should see my expenses details in the list as \|""(.*)"" ""(.*)"" ""(.*)"" ""(.*)""\|")]
        public void ThenIShouldSeeMyExpensesDetailsInTheListAs(string description, string dateSubmitted, string approverInfo, string status)
        {
            if (dateSubmitted == "")
            {
                dateSubmitted = null;
            }
            var myExpenseClaims = _myExpensesPage.GetAllMyExpenseClaims();

            var myExpenseDetails = myExpenseClaims.ExpenseClaims.FirstOrDefault(x => x.Description == description &&
                                                                                  x.DateSubmitted == dateSubmitted &&
                                                                                  x.ApproverInfo == approverInfo &&
                                                                                  x.Status == status);
            Assert.NotNull(myExpenseDetails);
        }


        [Then(@"I enter approver comments as ""(.*)""")]
        public void ThenIEnterApproverCommentsAs(string approverComments)
        {
            _myExpensesPage.EnterApproverComments(approverComments);
        }

        [Then(@"I click on approve button")]
        public void ThenIClickOnApproveButton()
        {
            _myExpensesPage.ClickApprove();
        }

        [Then(@"I click on reject button")]
        public void ThenIClickOnRejectButton()
        {
            _myExpensesPage.ClickReject();
        }

        [Then(@"I click on mark as read button")]
        public void ThenIClickOnMarkAsReadButton()
        {
            _myExpensesPage.ClickMarkAsRead();
        }

        [Then(@"I click on delete button")]
        public void ThenIClickOnDeleteButton()
        {
            _myExpensesPage.ClickDelete();
        }

        [Then(@"I should see confirm deletion")]
        public void ThenIShouldSeeConfirmDeletion()
        {
            _myExpensesPage.ValidateConfirmDeletion();
        }

        [Then(@"I should see withdraw deletion")]
        public void ThenIShouldSeeWithdrawDeletion()
        {
            _myExpensesPage.ValidateConfirmWithdraw();
        }


        [Then(@"I click on yes button")]
        public void ThenIClickOnYesButton()
        {
            _myExpensesPage.ClickYes();
        }

        [When(@"I click on add attachments")]
        public void WhenIClickOnAddAttachments()
        {
            _myExpensesPage.ClickAddAttachments();
        }

        [Then(@"I enter attachmement title as ""(.*)""")]
        public void ThenIEnterAttachmementTitleAs(string title)
        {
            _myExpensesPage.EnterAttachmentTitle(title);
        }

        [Then(@"I enter attachment description as ""(.*)""")]
        public void ThenIEnterAttachmentDescriptionAs(string description)
        {
            _myExpensesPage.EnterAttachmentDescription(description);
        }


        [Then(@"I will upload expense bill")]
        public void ThenIWillUploadExpenseBill()
        {
            _myExpensesPage.ClickOnChooseFile();
        }

        [Then(@"I click on add button")]
        public void ThenIClickOnAddButton()
        {
            _myExpensesPage.ClickAdd();
        }

        [Then(@"I click on view")]
        public void ThenIClickOnView()
        {
            _myExpensesPage.ClickView();
        }

        [Then(@"I should see the bill")]
        public void ThenIShouldSeeTheBill()
        {
            _myExpensesPage.ValidateReceipt();
        }

        [Then(@"I click on remove")]
        public void ThenIClickOnRemove()
        {
            _myExpensesPage.ClickRemove();
        }

        [Then(@"I should see number of attachments")]
        public void ThenIShouldSeeNumberOfAttachments()
        {
            _myExpensesPage.ValidateManageAttachments();
        }


        [When(@"I click on expense item")]
        public void WhenIClickOnExpenseItem()
        {
            var myExpenseClaims =_myExpensesPage.GetAllMyExpenseClaims();
            var expenseClickableElementId = myExpenseClaims.ExpenseClaims.FirstOrDefault(x => x.Status.ToUpper().Equals("SAVED")).elementID;
            _myExpensesPage.ClickOnExpenseClaimCard(expenseClickableElementId);
        }

        [When(@"I click on my rejected expense claim")]
        public void WhenIClickOnMyRejectedExpenseClaim()
        {
            var myExpenseClaims = _myExpensesPage.GetAllMyExpenseClaims();
            var expenseClickableElementId = myExpenseClaims.ExpenseClaims.FirstOrDefault(x => x.Status.ToUpper().Equals("REJECTED")).elementID;
            _myExpensesPage.ClickOnExpenseClaimCard(expenseClickableElementId);
        }

        [When(@"I click on my expense claim status as ""(.*)""")]
        public void WhenIClickOnMyExpenseClaimStatusAs(string status)
        {
            var myExpenseClaims = _myExpensesPage.GetAllMyExpenseClaims();
            var expenseClickableElementId = myExpenseClaims.ExpenseClaims.FirstOrDefault(x => x.Status.Equals(status)).elementID;
            _myExpensesPage.ClickOnExpenseClaimCard(expenseClickableElementId);
        }


        [Then(@"I should see expense details")]
        public void ThenIShouldSeeExpenseDetails()
        {
            var notificationCentre = _myNotificationsPage.GetAllNotifications();
        }

        [When(@"I click on expense claim to action as \|""(.*)"", ""(.*)"", ""(.*)""\|")]
        public void WhenIClickOnExpenseClaimToActionAs(string title, string empName, string status)
        {
            var notificationCentre = _myNotificationsPage.GetAllNotifications();
            var notificationsClickableElementId = notificationCentre.Notifications.Find(x => x.Title.Contains(title) &&
                                                                                        x.FromWhom.Equals(empName) &&
                                                                                        x.Status.Equals(status)).ElementId;
            _notificationClickableElementID = notificationsClickableElementId;
            _myExpensesPage.ClickOnExpenseClaimCard(notificationsClickableElementId);
        }

        [Then(@"I should see the status of my expense has been approved \|""(.*)"", ""(.*)"", ""(.*)""\|")]
        [Then(@"I should see the status of my expense has been rejected \|""(.*)"", ""(.*)"", ""(.*)""\|")]

        public void ThenIShouldSeeTheStatusOfMyExpenseHasBeenApproved(string titleLeft, string titleRight, string approver)
        {
            var notificationCentre = _myNotificationsPage.GetAllNotifications();
            var notificationsClickableElementId = notificationCentre.Notifications.Find(x => x.Title.Contains(titleLeft) &&
                                                                                        x.Title.Contains(titleRight) &&
                                                                                        x.FromWhom.Equals(approver)).ElementId;
            _notificationClickableElementID = notificationsClickableElementId;

        }

        [When(@"I click on my approved expense")]
        [When(@"I click on my rejected expense")]
        public void WhenIClickOnMyApprovedExpense()
        {
            _myExpensesPage.ClickOnExpenseClaimCard(_notificationClickableElementID);
        }

        [Then(@"I click on mark as read")]
        public void ThenIClickOnMarkAsRead()
        {
            _myExpensesPage.ClickMarkAsRead();
        }

        [Then(@"I click on withdraw button")]
        public void ThenIClickOnWithdrawButton()
        {
            _myExpensesPage.ClickWithdrawButton();
        }

        [When(@"I click on expense allocations")]
        public void WhenIClickOnExpenseAllocations()
        {
            _myExpensesPage.ClickOnExpenseAllocation();
        }

        [When(@"I enter cost centre as ""(.*)""")]
        public void WhenIEnterCostCentreAs(string costCentre)
        {
            _myExpensesPage.SelectCostCentre(costCentre);
        }

        [When(@"I enter programme as ""(.*)""")]
        public void WhenIEnterProgrammeAs(string programme)
        {
            _myExpensesPage.SelectProgramme(programme);
        }

        [When(@"I enter analysis as ""(.*)""")]
        public void WhenIEnterAnalysisAs(string analysis1)
        {
            _myExpensesPage.SelectAnalysis1(analysis1);
        }


        [Then(@"I update cost centre as ""(.*)""")]
        public void ThenIUpdateCostCentreAs(string costCentre)
        {
            _myExpensesPage.UpdateCostCentre(costCentre);
        }

        [Then(@"I update programme as ""(.*)""")]
        public void ThenIUpdateProgrammeAs(string programme)
        {
            _myExpensesPage.UpdateProgramme(programme);
        }

        [Then(@"I update analysis as ""(.*)""")]
        public void ThenIUpdateAnalysisAs(string analysis)
        {
            _myExpensesPage.UpdateAnalysis1(analysis);
        }

        [Then(@"I click on apply all")]
        public void ThenIClickOnApplyAll()
        {
            _myExpensesPage.ClickApplyAll();
        }

        [When(@"I click on three dots to expand claim")]
        public void WhenIClickOnThreeDotsToExpandClaim()
        {
            _myExpensesPage.ClickOnThreeDotsToExpandClaim();
        }

    }
}
