using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using Uksbs.Connect.AutomatedTests.Common;
using Uksbs.Connect.AutomatedTests.SpecFlowFactory;
using Xunit;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using SeleniumExtras.WaitHelpers;

namespace Uksbs.Connect.AutomatedTests.PageObjects
{
    public class MyTeamPage : BasePage, IClassFixture<SeleniumDriver>
    {
        private readonly IWebDriver webDriver;
        
        private readonly ScenarioContext _scenarioContext;

        private readonly string _myTeam = "//div[contains(text(),'My team')]/div[contains(text(),'Only displays staff with active Oracle User Accounts')]";
        private readonly string _pieChart = "//div[@class='myteam-wrap-container']//oj-chart[@id='pieChart']";
        private readonly string _noOfDirectsInPieChart = "//*[@id='myteam-tile-animatable']//div[@class='center-label']/p[@class='noOfDirects']";
        private readonly string _directsInPieChart = "//*[@id='myteam-tile-animatable']//div[@class='center-label']/p[@class='directs']";
        private readonly string _myNameInMyTeam = "//*[@id='myteam-film-strip']/div[3]/div/div[1]//p[1]";
        private readonly string _myRoleInMyTeam = "//*[@id='myteam-film-strip']/div[3]/div/div[1]//p[2]";
        private readonly string _myManagerNameInMyTeam = "//*[@id='myteam-film-strip']/div[3]/div/div[2]//p[1]";
        private readonly string _myManagerRoleInMyTeam = "//*[@id='myteam-film-strip']/div[3]/div/div[2]//p[2]";
        private readonly string _colleagueNameInMyTeamBack = "//*[@id='myteam-tile-animatable']//div[@class='myteam-tile-flipped-colleague-name']";
        private readonly string _colleagueRoleInMyTeamBack = "//*[@id='myteam-tile-animatable']//div[@class='myteam-tile-flipped-colleague-job']";
        private readonly string _colleagueEmailInMyTeamBack = "//*[@id='myteam-tile-animatable']//div[@class='myteam-tile-flipped-details-container']//div[1]//p";
        private readonly string _colleagueTelInMyTeamBack = "//*[@id='myteam-tile-animatable']//div[@class='myteam-tile-flipped-details-container']//div[2]//p";
        private readonly string _myTeamBack = "//*[@id='myteam-tile-close']";
        private readonly string _viewMyTeam = "//span[contains(text(),'VIEW MY TEAM')]";
        private readonly string _myManagerTitleTeamView = "//h2[contains(text(),'My Manager')]";
        private readonly string _myProfileTitleTeamView = "//h2[contains(text(),'My Profile')]";
        private readonly string _myDirectReportsTitleTeamView = "//h2[contains(text(),'My Direct Reports')]";
        private readonly string _myManagerNameTeamView = "//oj-masonry-layout[1]//div[@class='details']//h2";
        private readonly string _myManagerPositionTeamView = "//oj-masonry-layout[1]//div[@class='details']//p[@class='position']";
        private readonly string _myManagerGradeTeamView = "//oj-masonry-layout[1]//div[@class='details']//p[@class='grade']";
        private readonly string _myManagerContactTeamView = "//oj-masonry-layout[1]//div[@class='details']//p[@class='contact']";
        private readonly string _myManagerContact1HOverTeamView = "//oj-masonry-layout[1]//div[@class='contact-info']//p[1]";
        private readonly string _myManagerContact2HOverTeamView = "//oj-masonry-layout[1]//div[@class='contact-info']//p[2]";
        private readonly string _myManagerHOverTeamView = "//oj-masonry-layout[1]/oc-card/div[@class='header']";
        private readonly string _myProfileNameTeamView = "//oj-masonry-layout[2]//div[@class='details']//h2";
        private readonly string _myProfilePositionTeamView = "//oj-masonry-layout[2]//div[@class='details']//p[@class='position']";
        private readonly string _myProfileGradeTeamView = "//oj-masonry-layout[2]//div[@class='details']//p[@class='grade']";
        private readonly string _myProfileContactTeamView = "//oj-masonry-layout[2]//div[@class='bottom']//p[@class='contact']";
        private readonly string _myProfileWorkTelHoverTeamView = "//oj-masonry-layout[2]//div[@class='contact-info']//p[1]";
        private readonly string _myProfileEmailHoverTeamView = "//oj-masonry-layout[2]//div[@class='contact-info']//p[2]";
        private readonly string _viewProfileTeamView = "//oc-primary-button[@class='oj-complete']/button";
        private readonly string _myProfileHOverTeamView = "//oj-masonry-layout[2]/oc-card/div[@class='header']";
        private readonly string _fullNameProfileView = "//oc-heading[contains(@main,'fullName')]/h1";
        private readonly string _positionProfileView = "//oc-heading[contains(@main,'fullName')]/h2";
        private readonly string _empProfileView = "//user-details-panel/p[@class='contract-status']";
        private readonly string _workAddressProfileView = "//user-details-panel/div[@class='address']/p";
        private readonly string _workEmailProfileView = "//user-details-panel/div[@class='contact-details']/p[1]";
        private readonly string _workMobileProfileView = "//user-details-panel/div[@class='contact-details']/p[2]";
        private readonly string _organisationNameProfileView = "//oc-heading[contains(@main,'Organisation')]/h1";
        private readonly string _orgJobDescProfileView = "//label[contains(text(),'Job')]//parent::div[@class='info-holder']/p";
        private readonly string _orgLocationProfileView = "//label[contains(text(),'Location')]//parent::div[@class='info-holder']/p";
        private readonly string _orgDepartmentProfileView = "//label[text()='Department']//parent::div[@class='info-holder']/p";
        private readonly string _orgDeptCostCenterProfileView = "//label[text()='Department cost centre']//parent::div[@class='info-holder']/p";
        private readonly string _orgGradeProfileView = "//label[text()='Grade']//parent::div[@class='info-holder']/p";
        private readonly string _orgEmpPrgmCodeProfileView = "//label[text()='Employee programme code']//parent::div[@class='info-holder']/p";
        private readonly string _orgManagerTitleProfileView = "//organisation-details-panel//label[contains(text(),'Manager')]";
        private readonly string _orgManagerNameProfileView = "//organisation-details-panel//div[@class='info']/p[@class='name']";
        private readonly string _orgManagerRoleProfileView = "//organisation-details-panel//div[@class='info']/p[@class='role']";
        private readonly string _orgManagerReportsProfileView = "//organisation-details-panel//div[@class='info']/p[@class='reports'][1]";
        private readonly string _orgManagerReports2ProfileView = "//organisation-details-panel//div[@class='info']/p[@class='reports'][2]";
        private readonly string _navBulletsMyTeam = "//*[@id='myteam-paging-control']//a[contains(@class,'oj-enabled')]";
        private readonly string _howToUpdateOrgInfo = "//p[contains(text(),'How to update organisational informaton')]";
        private readonly string _closeUpdateOrgInfo = "//img[@alt='Close info']";
        private readonly string _editLineManager = "//oc-icon[@name='edit']//img[@alt='Edit line manager']";
        private readonly string _clickOnSelectManager = "//div[@aria-label='Select manager']/span[contains(text(),'Select manager')]";
        private readonly string _typeManagerName = "//*[@id='oj-listbox-drop']//input[@aria-label='Select manager']";
        private readonly string _effectiveStartDate = "//input[@placeholder='dd.MM.yy']";
        private readonly string _clickSubmit = "//button[contains(normalize-space(.),'Submit')]";
        private readonly string _oracleHomePageTitle = "//h1[contains(text(),'Oracle Applications Home Page')]";
        private readonly string _ebsMainMenu = "//h2[contains(text(),'Main Menu')]";
        private readonly string _viewMenu = "//*[@id='connect-module']//a[@title='View Menu']";
        private readonly string _logout = "//nav[@aria-label='Product navigation']//a/img[contains(@alt,'Logout')]";
        private readonly string _teamList = "//*[@id='myprofile-mycontactdetails-filmstrip']";


        public MyTeamPage(IWebDriver webDriver, ScenarioContext scenarioContext) : base(webDriver)
        {
            this.webDriver = webDriver;
            
            _scenarioContext = scenarioContext;
        }

        public void ValidateMyTeamTileInDashboard()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_myTeam)));
            Assert.True(this.IsElementPresent(By.XPath(_myTeam)));
        }
        public void ValidatePieChartInMyTeam()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_pieChart)));

            Assert.True(this.IsElementPresent(By.XPath(_pieChart)));
        }

        public string GetNoOfDirectsInMyTeam()
        {
            this.Find(By.XPath(_noOfDirectsInPieChart));
            string result = FindElementXPath(_noOfDirectsInPieChart);
            return result;
        }
        public string GetDirectsInMyTeam()
        {
            this.Find(By.XPath(_directsInPieChart));
            string result = FindElementXPath(_directsInPieChart);
            return result;
        }
        public string GetNameInMyTeam(string name)
        {
            var myNameInMyTeam = "//*[@id='myteam-film-strip']//p[contains(normalize-space(.),'" + name + "') and 1]";
            this.Find(By.XPath(myNameInMyTeam));
            string result = FindElementXPath(myNameInMyTeam);
            return result;
        }
        public string GetRoleInMyTeam(string role)
        {
            var myRoleInMyTeam = "//*[@id='myteam-film-strip']//p[contains(normalize-space(.),'" + role + "')]";
            this.Find(By.XPath(myRoleInMyTeam));
            string result = FindElementXPath(myRoleInMyTeam);
            return result;
        }
        public string GetMyManagerNameInMyTeam()
        {
            this.Find(By.XPath(_myManagerNameInMyTeam));
            string result = FindElementXPath(_myManagerNameInMyTeam);
            return result;
        }
        public string GetMyManagerRoleInMyTeam()
        {
            this.Find(By.XPath(_myManagerRoleInMyTeam));
            string result = FindElementXPath(_myManagerRoleInMyTeam);
            return result;
        }
        public void ClickOnNameInMyTeam(string name)
        {
            var nameInMyTeam = "//*[@id='myteam-film-strip']//p[contains(normalize-space(.),'" + name + "') and 1]";
           
            this.Click(By.XPath(nameInMyTeam));
        }
        public string GetColleagueNameInMyTeamBack()
        {
            this.Find(By.XPath(_colleagueNameInMyTeamBack));
            string result = FindElementXPath(_colleagueNameInMyTeamBack);
            return result;
        }
        public string GetColleagueRoleInMyTeamBack()
        {
            this.Find(By.XPath(_colleagueRoleInMyTeamBack));
            string result = FindElementXPath(_colleagueRoleInMyTeamBack);
            return result;
        }
        public string GetColleagueEmailInMyTeamBack()
        {
            this.Find(By.XPath(_colleagueEmailInMyTeamBack));
            string result = FindElementXPath(_colleagueEmailInMyTeamBack);
            return result;
        }
        public string GetColleagueTelNoInMyTeamBack()
        {
            this.Find(By.XPath(_colleagueTelInMyTeamBack));
            string result = FindElementXPath(_colleagueTelInMyTeamBack);
            return result;
        }
        public void ClickBackInMyTeam()
        {
           
            this.Click(By.XPath(_myTeamBack));
        }
        public void ClickViewMyTeam()
        {
           
            this.Click(By.XPath(_viewMyTeam));
        }

        public string GetMyManagerTitleTeamView()
        {
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_myManagerTitleTeamView)));
            this.Find(By.XPath(_myManagerTitleTeamView));
            string result = FindElementXPath(_myManagerTitleTeamView);
            return result;
        }
        public string GetMyProfileTitleTeamView()
        {
            this.Find(By.XPath(_myProfileTitleTeamView));
            string result = FindElementXPath(_myProfileTitleTeamView);
            return result;
        }
        public string GetTitleInTeamView(string title)
        {
            var titleInTeamView = "//h2[contains(text(),'" + title + "')]";
            this.Find(By.XPath(titleInTeamView));
            string result = FindElementXPath(titleInTeamView);
            return result;
        }
        public string GetMyManagerNameTeamView()
        {
            this.Find(By.XPath(_myManagerNameTeamView));
            string result = FindElementXPath(_myManagerNameTeamView);
            return result;
        }
        public string GetMyManagerPositionTeamView()
        {
            this.Find(By.XPath(_myManagerPositionTeamView));
            string result = FindElementXPath(_myManagerPositionTeamView);
            return result;
        }
        public string GetMyManagerGradeTeamView()
        {
            this.Find(By.XPath(_myManagerGradeTeamView));
            string result = FindElementXPath(_myManagerGradeTeamView);
            return result;
        }
        public string GetMyManagerContactTeamView()
        {
            this.Find(By.XPath(_myManagerContactTeamView));
            string result = FindElementXPath(_myManagerContactTeamView);
            return result;
        }
        public string GetMyManageWorkTelHOverTeamView(string workTel)
        {
            var myManagerWorkTelHOverTeamView = "//oj-masonry-layout[1]//div[@class='contact-info']//p[contains(normalize-space(.),'" + workTel + "')]";
            this.Find(By.XPath(myManagerWorkTelHOverTeamView));
            string result = FindElementXPath(myManagerWorkTelHOverTeamView);
            return result;
        }
        public string GetMyManagerEmailHOverTeamView(string email)
        {
            var myManagerEmailHOverTeamView = "//oj-masonry-layout[1]//div[@class='contact-info']//p[contains(normalize-space(.),'" + email + "')]";
            this.Find(By.XPath(myManagerEmailHOverTeamView));
            string result = FindElementXPath(myManagerEmailHOverTeamView);
            return result;
        }
        public void MouseOverMyManager()
        {
           
            this.Click(By.XPath(_myManagerHOverTeamView));
        }
        public void MouseOverMyProfile()
        {
           
            this.Click(By.XPath(_myProfileHOverTeamView));
        }
        public string GetMyProfileWorkTelHoverTeamView()
        {
            this.Find(By.XPath(_myProfileWorkTelHoverTeamView));
            string result = FindElementXPath(_myProfileWorkTelHoverTeamView);
            return result;
        }
        public string GetMyProfileEmailHoverTeamView()
        {
            this.Find(By.XPath(_myProfileEmailHoverTeamView));
            string result = FindElementXPath(_myProfileEmailHoverTeamView);
            return result;
        }
        public string GetMyProfileNameTeamView()
        {
            this.Find(By.XPath(_myProfileNameTeamView));
            string result = FindElementXPath(_myProfileNameTeamView);
            return result;
        }
        public string GetMyProfilePositionTeamView()
        {
            this.Find(By.XPath(_myProfilePositionTeamView));
            string result = FindElementXPath(_myProfilePositionTeamView);
            return result;
        }
        public string GetMyProfileGradeTeamView()
        {
            this.Find(By.XPath(_myProfileGradeTeamView));
            string result = FindElementXPath(_myProfileGradeTeamView);
            return result;
        }
        public string GetMyProfileContactTeamView()
        {
            this.Find(By.XPath(_myProfileContactTeamView));
            string result = FindElementXPath(_myProfileContactTeamView);
            return result;
        }

        public string GetFullNameProfileView()
        {
           
            this.Find(By.XPath(_fullNameProfileView));
            string result = FindElementXPath(_fullNameProfileView);
            return result;
        }
        public string GetPositionProfileView()
        {
            this.Find(By.XPath(_positionProfileView));
            string result = FindElementXPath(_positionProfileView);
            return result;
        }
        public string GetEmpProfileView()
        {
            this.Find(By.XPath(_empProfileView));
            string result = FindElementXPath(_empProfileView);
            return result;
        }
        public string GetWorkAddressProfileView1()
        {
            var workAddressProfileView = "//user-details-panel/div[@class='address']/p[1]";
            this.Find(By.XPath(workAddressProfileView));
            string result = FindElementXPath(workAddressProfileView);
            return result;
        }
        public string GetWorkAddressProfileView2()
        {
            var workAddressProfileView = "//user-details-panel/div[@class='address']/p[3]";
            this.Find(By.XPath(workAddressProfileView));
            string result = FindElementXPath(workAddressProfileView);
            return result;
        }
        public string GetWorkAddressProfileView3()
        {
            var workAddressProfileView = "//user-details-panel/div[@class='address']/p[4]";
            this.Find(By.XPath(workAddressProfileView));
            string result = FindElementXPath(workAddressProfileView);
            return result;
        }
        public string GetWorkAddressProfileView4()
        {
            var workAddressProfileView = "//user-details-panel/div[@class='address']/p[5]";
            this.Find(By.XPath(workAddressProfileView));
            string result = FindElementXPath(workAddressProfileView);
            return result;
        }
        public string GetWorkEmailProfileView()
        {
            this.Find(By.XPath(_workEmailProfileView));
            string result = FindElementXPath(_workEmailProfileView);
            return result;
        }
        public string GetWorkMobileProfileView()
        {
            this.Find(By.XPath(_workMobileProfileView));
            string result = FindElementXPath(_workMobileProfileView);
            return result;
        }
        public string GetOrganisationNameProfileView()
        {
            this.Find(By.XPath(_organisationNameProfileView));
            string result = FindElementXPath(_organisationNameProfileView);
            return result;
        }
        public string GetOrgJobDescProfileView()
        {
            this.Find(By.XPath(_orgJobDescProfileView));
            string result = FindElementXPath(_orgJobDescProfileView);
            return result;
        }
        public string GetOrgLocationProfileView()
        {
            this.Find(By.XPath(_orgLocationProfileView));
            string result = FindElementXPath(_orgLocationProfileView);
            return result;
        }
        public string GetOrgDepartmentProfileView()
        {
            this.Find(By.XPath(_orgDepartmentProfileView));
            string result = FindElementXPath(_orgDepartmentProfileView);
            return result;
        }
        public string GetOrgDeptCostCenterProfileView()
        {
            this.Find(By.XPath(_orgDeptCostCenterProfileView));
            string result = FindElementXPath(_orgDeptCostCenterProfileView);
            return result;
        }
        public string GetOrgGradeProfileView()
        {
            this.Find(By.XPath(_orgGradeProfileView));
            string result = FindElementXPath(_orgGradeProfileView);
            return result;
        }
        public string GetOrgEmpPrgmCodeProfileView()
        {
            this.Find(By.XPath(_orgEmpPrgmCodeProfileView));
            string result = FindElementXPath(_orgEmpPrgmCodeProfileView);
            return result;
        }
        public string GetOrgManagerTitleProfileView()
        {
            this.Find(By.XPath(_orgManagerTitleProfileView));
            string result = FindElementXPath(_orgManagerTitleProfileView);
            return result;
        }
        public string GetOrgManagerNameProfileView()
        {
            this.Find(By.XPath(_orgManagerNameProfileView));
            string result = FindElementXPath(_orgManagerNameProfileView);
            return result;
        }
        public string GetOrgManagerRoleProfileView()
        {
            this.Find(By.XPath(_orgManagerRoleProfileView));
            string result = FindElementXPath(_orgManagerRoleProfileView);
            return result;
        }
        public string GetOrgManagerReportsProfileView()
        {
            this.Find(By.XPath(_orgManagerReportsProfileView));
            string result = FindElementXPath(_orgManagerReportsProfileView);
            return result;
        }
        public string GetOrgManagerReports2ProfileView()
        {
            this.Find(By.XPath(_orgManagerReports2ProfileView));
            string result = FindElementXPath(_orgManagerReports2ProfileView);
            return result;
        }

        public void ClickNavigationBulletsMyTeam()
        {           
            this.Click(By.XPath(_navBulletsMyTeam));
        }
        public void ClickViewProfile()
        {
            //var viewProfileTeamView = "//h2[contains(normalize-space(.),'"+ name +"')]/ancestor::div[@class='details']/following-sibling::div[@class='contact-info']//oc-primary-button[@class='oj-complete']/button";

            var viewProfileTeamView = "//oc-primary-button[@class='oj-complete']/button";
           
            this.Click(By.XPath(viewProfileTeamView));
        }
        public void ClickOnViewProfile(string name)
        {
            var viewProfileTeamView = "//h2[contains(normalize-space(.),'" + name + "')]/ancestor::div[@class='details']/following-sibling::div[@class='contact-info']//oc-primary-button[@class='oj-complete']/button";

            // var viewProfileTeamView = "//oc-primary-button[@class='oj-complete']/button";
           
            this.Click(By.XPath(viewProfileTeamView));
        }
        public string GetMyDirectReportsTitleTeamView()
        {
            this.Find(By.XPath(_myDirectReportsTitleTeamView));
            string result = FindElementXPath(_myDirectReportsTitleTeamView);
            return result;
        }
        public void ClickLogout()
        {
           
            this.Click(By.XPath(_logout));
        }
        public void ClickMyTeamMember(string name)
        {
            var myTeamMember = "//*[@id='myteam-film-strip']//p[contains(normalize-space(.),'" + name + "')]";
           
            this.Click(By.XPath(myTeamMember));
        }
        public void MouseOverMyDirectReports(string name)
        {
            var myDirectReportsHOver = "//oj-masonry-layout[2]//h2[contains(normalize-space(.),'" + name + "')]";
           
            //  this.Hover(By.XPath(myDirectReportsHOver));
            this.Click(By.XPath(myDirectReportsHOver));
        }
        public string GetMyDRWorkTelHoverTeamView(string workTel)
        {
            var myDRWorkTel = "//oj-masonry-layout[2]//div[@class='contact-info']//p[contains(normalize-space(.),'" + workTel + "')]";
            this.Find(By.XPath(myDRWorkTel));
            string result = FindElementXPath(myDRWorkTel);
            return result;
        }
        public string GetMyDREmailHoverTeamView(string email)
        {
            var myDREmail = "//oj-masonry-layout[2]//div[@class='contact-info']//p[contains(normalize-space(.),'" + email + "')]";
            this.Find(By.XPath(myDREmail));
            string result = FindElementXPath(myDREmail);
            return result;
        }
        public void ValidateOracleHomePage()
        {
            this.WaitUntilVisible(By.XPath(_oracleHomePageTitle));

            Assert.True(this.IsElementPresent(By.XPath(_oracleHomePageTitle)));
            Assert.True(this.IsElementPresent(By.XPath(_ebsMainMenu)));
        }
        public void ValidateTeamMembersList()
        {
            this.WaitUntilVisible(By.XPath(_teamList));
            Assert.True(this.IsElementPresent(By.XPath(_teamList)));
        }

        public void ClickViewMenu()
        {           
            this.Click(By.XPath(_viewMenu));
        }
        public void ClickHowToUpdateOrgInfo()
        {           
            this.Click(By.XPath(_howToUpdateOrgInfo));
        }
        public string GetUpdateOrgDataInfo(string updateOrgData)
        {
            var updateOrgDataInfo = "//p[contains(text(),'" + updateOrgData + "')]";
            this.Find(By.XPath(updateOrgDataInfo));
            string result = FindElementXPath(updateOrgDataInfo);
            return result;
        }
        public void CloseUpdateOrgInfoDialog()
        {           
            this.Click(By.XPath(_closeUpdateOrgInfo));
        }
        public void ClickEditLineManager()
        {           
            this.Click(By.XPath(_editLineManager));
        }
        public string GetChangeManagerDialogInfo(string changeManager)
        {
            var changeManagerInfo = "//h2[contains(text(),'" + changeManager + "')]";
            var wait = getDriverWait();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(changeManagerInfo)));
            this.Find(By.XPath(changeManagerInfo));
            string result = FindElementXPath(changeManagerInfo);
            return result;
        }
        public void SelectNewManager(string managerName)
        {           
            this.Click(By.XPath(_clickOnSelectManager));
            this.TypeSearchClick(managerName, By.XPath(_typeManagerName));
        }
        public void SelectEffectiveStartDate(string startDate)
        {           
            this.Click(By.XPath(_effectiveStartDate));
            this.TypeDate(startDate, (By.XPath(_effectiveStartDate)));
        }
        public void ClickSubmit()
        {           
            this.Click(By.XPath(_clickSubmit));
        }

        private WebDriverWait getDriverWait()
        {
            return new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(Constants.DefaultWaitTime));
        }
    }
}
