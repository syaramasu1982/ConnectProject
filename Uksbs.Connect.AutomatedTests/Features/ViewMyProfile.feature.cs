﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Uksbs.Connect.AutomatedTests.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class ViewMyProfileFeature : object, Xunit.IClassFixture<ViewMyProfileFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "ViewMyProfile.feature"
#line hidden
        
        public ViewMyProfileFeature(ViewMyProfileFeature.FixtureData fixtureData, Uksbs_Connect_AutomatedTests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "ViewMyProfile", "\tAs a user I want to launch UI Connect application\r\n\tSo that I can View My Profil" +
                    "e", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public void TestInitialize()
        {
        }
        
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Perform View My Profile")]
        [Xunit.TraitAttribute("FeatureTitle", "ViewMyProfile")]
        [Xunit.TraitAttribute("Description", "Perform View My Profile")]
        [Xunit.TraitAttribute("Category", "connect-regression")]
        [Xunit.TraitAttribute("Category", "viewprofile")]
        [Xunit.InlineDataAttribute("MARK NORRIS", "Policy Delivery", "Married/Civil Partnership", "NH006561D", "04 JUL 1965", "15030311", "102056", "Mr Keith Hodgkinson", new string[0])]
        public void PerformViewMyProfile(string fullName, string position, string maritalStatus, string niNumber, string dOB, string empNo, string costCenterCode, string lineManager, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "connect-regression",
                    "viewprofile"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("fullName", fullName);
            argumentsOfScenario.Add("position", position);
            argumentsOfScenario.Add("maritalStatus", maritalStatus);
            argumentsOfScenario.Add("niNumber", niNumber);
            argumentsOfScenario.Add("DOB", dOB);
            argumentsOfScenario.Add("empNo", empNo);
            argumentsOfScenario.Add("costCenterCode", costCenterCode);
            argumentsOfScenario.Add("lineManager", lineManager);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Perform View My Profile", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 6
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 8
 testRunner.Given("I login as an employee", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 9
 testRunner.Then(string.Format("I see my full name as \"{0}\"", fullName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 10
 testRunner.And(string.Format("I see my position as \"{0}\"", position), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 11
 testRunner.And("I click on view profile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 12
 testRunner.Then(string.Format("I see marital status as \"{0}\"", maritalStatus), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 13
 testRunner.And(string.Format("I see ni number as \"{0}\"", niNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 14
 testRunner.And(string.Format("I see dob as \"{0}\"", dOB), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 15
 testRunner.And(string.Format("I see employee no as \"{0}\"", empNo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 16
 testRunner.And(string.Format("I see cost center code as \"{0}\"", costCenterCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 17
 testRunner.And(string.Format("I see line manager as \"{0}\"", lineManager), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 18
 testRunner.And("I click on back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 19
 testRunner.Then("I click on logout button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                ViewMyProfileFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                ViewMyProfileFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion