using TechTalk.SpecFlow;
using BoDi;
using System.IO;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using System.Reflection;
using Uksbs.Connect.AutomatedTests.WebTests.PageObjects;
using System;
using System.Threading;

namespace Uksbs.Connect.AutomatedTests.SpecFlowFactory
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer objectContainer;
        private static SeleniumContext seleniumContext;

        const string testReportFolder = @"/TestReports/";
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        private static FeatureContext _featureContext;
        private static ScenarioContext _scenarioContext;

        public Hooks(IObjectContainer container)
        {
            this.objectContainer = container;
        }

        [BeforeTestRun]
        public static void RunBeforeAllTests()
        {
            var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + testReportFolder + "index.html";
            var htmlReporter = new ExtentHtmlReporter(path);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            seleniumContext = new SeleniumContext();

            _featureContext = featureContext;

            featureName = extent.CreateTest<Feature>(_featureContext.FeatureInfo.Title);
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            seleniumContext.WebDriver.Dispose();
        }

        [BeforeScenario]
        public void RunBeforeScenario(ScenarioContext scenarioContext)
        {
            objectContainer.RegisterInstanceAs<SeleniumContext>(seleniumContext);

            _scenarioContext = scenarioContext;
            scenario = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void RunAfterScenario()
        {
           
           // CreateScreenshot(_scenarioContext.ScenarioInfo.Title);
            ClickLogoutButton();
        }


        [AfterStep]
        public void InsertReportingSteps()
        {

            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

            if (_scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
            }
            else if (_scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                }
                else if (stepType == "And")
                {
                    scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                }
            }
          
        }

        private void CreateScreenshot(string scenarioTitle)
        {
            string screenshotsFolder = @"/TestResults/Reports/images/";
            //     string uuid = Guid.NewGuid().ToString();                

            var artifactDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + screenshotsFolder;
            string fileName = artifactDirectory + scenarioTitle.Replace(" ", string.Empty);

            if (!Directory.Exists(artifactDirectory))
                Directory.CreateDirectory(artifactDirectory);

            Screenshot screen = ((ITakesScreenshot)seleniumContext.WebDriver).GetScreenshot();
            screen.SaveAsFile(fileName + ".png", ScreenshotImageFormat.Png);
        }

        public void ClickLogoutButton()
        {
            try
            {
                seleniumContext.WebDriver.FindElement(By.XPath("//nav[@aria-label='Product navigation']//button[@title='Logout']")).Click();
                Thread.Sleep(2000);
                seleniumContext.WebDriver.Manage().Cookies.DeleteAllCookies();
            }
            catch (Exception)
            {

            }
            
        }

    }

}
