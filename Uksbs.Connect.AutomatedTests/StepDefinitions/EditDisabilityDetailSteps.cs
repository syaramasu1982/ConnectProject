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
    public sealed class EditDisabilityDetailSteps
    {
        private SeleniumContext seleniumContext;
        private IWebDriver webDriver;
        private ScenarioContext _scenarioContext;



        private EditDisabilityDetailsPage _editDisabilityDetailsPage;

        public EditDisabilityDetailSteps(SeleniumContext seleniumContext, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            //save the context so you can use it in your tests
            this.seleniumContext = seleniumContext;
            this.webDriver = seleniumContext.WebDriver;



            // Creating selenium specific instance for login page
            _editDisabilityDetailsPage = new EditDisabilityDetailsPage(webDriver, _scenarioContext);
        }


        [Given(@"I select disability status as ""(.*)""")]
        public void GivenISelectDisabilityStatusAs(string disabilityStatus)
        {
            _editDisabilityDetailsPage.SelectDisabilityStatus(disabilityStatus);
        }

        [Given(@"I select reason (.*) as ""(.*)""")]
        public void GivenISelectReasonAs(int line, string reason)
        {
            if (line == 1)
            {
                _editDisabilityDetailsPage.SelectReason1(reason);
            }
            else if (line == 2)
            {
                _editDisabilityDetailsPage.SelectReason2(reason);
            }
            else
            {
                _editDisabilityDetailsPage.SelectReason3(reason);
            }
        }

        [Given(@"I update reason other (.*) as ""(.*)""")]
        public void GivenIUpdateReasonOtherAs(int line, string reasonOther)
        {
            if (line == 1)
            {
                _editDisabilityDetailsPage.UpdateReasonOther1(reasonOther);
            }
            else if (line == 2)
            {
                _editDisabilityDetailsPage.UpdateReasonOther2(reasonOther);
            }
            else
            {
                _editDisabilityDetailsPage.UpdateReasonOther3(reasonOther);
            }
        }

        [Given(@"I update special requirements (.*) as ""(.*)""")]
        public void GivenIUpdateSpecialRequirementsAs(int line, string specialRequirement)
        {
            if (line == 1)
            {
                _editDisabilityDetailsPage.UpdateSpecialRequirements1(specialRequirement);
            }
            else if (line == 2)
            {
                _editDisabilityDetailsPage.UpdateSpecialRequirements2(specialRequirement);
            }
            else
            {
                _editDisabilityDetailsPage.UpdateSpecialRequirements3(specialRequirement);
            }
        }

        [Given(@"I select grant access to manager as ""(.*)""")]
        public void GivenISelectGrantAccessToManagerAs(string grantAccessToManager)
        {
            _editDisabilityDetailsPage.SelectGrantAccessToManager(grantAccessToManager);
        }

        [Given(@"I select risk assessment carried out as ""(.*)""")]
        public void GivenISelectRiskAssessmentCarriedOutAs(string riskAssessmentCarriedOut)
        {
            _editDisabilityDetailsPage.SelectRiskAssessment(riskAssessmentCarriedOut);
        }

        [Then(@"I save disability details")]
        public void ThenISaveDisabilityDetails()
        {
            _editDisabilityDetailsPage.ClickSaveDisabilityDetails();
        }

    }
}
