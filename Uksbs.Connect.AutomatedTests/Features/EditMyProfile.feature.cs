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
    public partial class EditMyProfileFeature : object, Xunit.IClassFixture<EditMyProfileFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "EditMyProfile.feature"
#line hidden
        
        public EditMyProfileFeature(EditMyProfileFeature.FixtureData fixtureData, Uksbs_Connect_AutomatedTests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "EditMyProfile", "\tAs a user I want to launch UI Connect application\r\n\tSo that I can Edit My Profil" +
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
        
        [Xunit.SkippableFactAttribute(DisplayName="Perform Future Date Validation in My Profile")]
        [Xunit.TraitAttribute("FeatureTitle", "EditMyProfile")]
        [Xunit.TraitAttribute("Description", "Perform Future Date Validation in My Profile")]
        [Xunit.TraitAttribute("Category", "connect-regression")]
        [Xunit.TraitAttribute("Category", "editmyprofile")]
        public void PerformFutureDateValidationInMyProfile()
        {
            string[] tagsOfScenario = new string[] {
                    "connect-regression",
                    "editmyprofile"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Perform Future Date Validation in My Profile", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 24
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 26
 testRunner.Given("I login as an employee", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 27
 testRunner.And("I click on edit my profile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 28
 testRunner.And("I verify future date validation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 29
 testRunner.Then("I click on logout button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Perform address change in My Profile")]
        [Xunit.TraitAttribute("FeatureTitle", "EditMyProfile")]
        [Xunit.TraitAttribute("Description", "Perform address change in My Profile")]
        [Xunit.TraitAttribute("Category", "connect-regression")]
        [Xunit.TraitAttribute("Category", "editmyprofile")]
        [Xunit.InlineDataAttribute("Other", "10 Chalgrove Road", "", "", "Sutton", "", "SM2 5JT", new string[0])]
        public void PerformAddressChangeInMyProfile(string addressType, string addressLine1, string addressLine2, string addressLine3, string town, string county, string postCode, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "connect-regression",
                    "editmyprofile"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("addressType", addressType);
            argumentsOfScenario.Add("addressLine1", addressLine1);
            argumentsOfScenario.Add("addressLine2", addressLine2);
            argumentsOfScenario.Add("addressLine3", addressLine3);
            argumentsOfScenario.Add("town", town);
            argumentsOfScenario.Add("county", county);
            argumentsOfScenario.Add("postCode", postCode);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Perform address change in My Profile", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 32
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 34
 testRunner.Given("I login as an employee", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 35
 testRunner.And("I click on edit my profile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 36
 testRunner.And(string.Format("I can select address type as \"{0}\"", addressType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 37
 testRunner.And(string.Format("I can update address line 1 as \"{0}\"", addressLine1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 38
 testRunner.And(string.Format("I can update address line 2 as \"{0}\"", addressLine2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 39
 testRunner.And(string.Format("I can update address line 3 as \"{0}\"", addressLine3), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 40
 testRunner.And(string.Format("I can update town as \"{0}\"", town), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 41
 testRunner.And(string.Format("I can select county as \"{0}\"", county), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 42
 testRunner.And(string.Format("I can update postcode as \"{0}\"", postCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 43
 testRunner.And("I click address save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 44
 testRunner.Then("I click on logout button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Perform Add a new address and start date = effective date in my profile")]
        [Xunit.TraitAttribute("FeatureTitle", "EditMyProfile")]
        [Xunit.TraitAttribute("Description", "Perform Add a new address and start date = effective date in my profile")]
        [Xunit.TraitAttribute("Category", "connect-regression")]
        [Xunit.TraitAttribute("Category", "editmyprofile")]
        [Xunit.InlineDataAttribute("Other", "10 Chalgrove Road", "", "", "Sutton", "", "SM2 5JT", "current date", new string[0])]
        public void PerformAddANewAddressAndStartDateEffectiveDateInMyProfile(string addressType, string addressLine1, string addressLine2, string addressLine3, string town, string county, string postCode, string startDate, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "connect-regression",
                    "editmyprofile"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("addressType", addressType);
            argumentsOfScenario.Add("addressLine1", addressLine1);
            argumentsOfScenario.Add("addressLine2", addressLine2);
            argumentsOfScenario.Add("addressLine3", addressLine3);
            argumentsOfScenario.Add("town", town);
            argumentsOfScenario.Add("county", county);
            argumentsOfScenario.Add("postCode", postCode);
            argumentsOfScenario.Add("startDate", startDate);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Perform Add a new address and start date = effective date in my profile", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 51
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 53
 testRunner.Given("I login as an employee", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 54
 testRunner.And("I click on edit my profile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 55
 testRunner.And("I click add new address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 56
 testRunner.And(string.Format("I can select address type as \"{0}\"", addressType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 57
 testRunner.And(string.Format("I can update address line 1 as \"{0}\"", addressLine1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 58
 testRunner.And(string.Format("I can update address line 2 as \"{0}\"", addressLine2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 59
 testRunner.And(string.Format("I can update address line 3 as \"{0}\"", addressLine3), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 60
 testRunner.And(string.Format("I can update town as \"{0}\"", town), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 61
 testRunner.And(string.Format("I can select county as \"{0}\"", county), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 62
 testRunner.And(string.Format("I can update postcode as \"{0}\"", postCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 63
 testRunner.And(string.Format("I add start date as \"{0}\"", startDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 64
 testRunner.And("I click checkbox to make default address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 65
 testRunner.And("I click address save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 66
 testRunner.Then("I click on logout button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Perform add secondary address and start date <  effective date in my Profile")]
        [Xunit.TraitAttribute("FeatureTitle", "EditMyProfile")]
        [Xunit.TraitAttribute("Description", "Perform add secondary address and start date <  effective date in my Profile")]
        [Xunit.TraitAttribute("Category", "connect-regression")]
        [Xunit.TraitAttribute("Category", "editmyprofile")]
        [Xunit.InlineDataAttribute("Other", "10 Chalgrove Road", "", "", "Sutton", "", "SM2 5JT", "past date", new string[0])]
        public void PerformAddSecondaryAddressAndStartDateEffectiveDateInMyProfile(string addressType, string addressLine1, string addressLine2, string addressLine3, string town, string county, string postCode, string startDate, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "connect-regression",
                    "editmyprofile"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("addressType", addressType);
            argumentsOfScenario.Add("addressLine1", addressLine1);
            argumentsOfScenario.Add("addressLine2", addressLine2);
            argumentsOfScenario.Add("addressLine3", addressLine3);
            argumentsOfScenario.Add("town", town);
            argumentsOfScenario.Add("county", county);
            argumentsOfScenario.Add("postCode", postCode);
            argumentsOfScenario.Add("startDate", startDate);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Perform add secondary address and start date <  effective date in my Profile", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 73
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 75
 testRunner.Given("I login as an employee", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 76
 testRunner.And("I click on edit my profile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 77
 testRunner.And("I click add new address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 78
 testRunner.And(string.Format("I can select address type as \"{0}\"", addressType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 79
 testRunner.And(string.Format("I can update address line 1 as \"{0}\"", addressLine1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 80
 testRunner.And(string.Format("I can update address line 2 as \"{0}\"", addressLine2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 81
 testRunner.And(string.Format("I can update address line 3 as \"{0}\"", addressLine3), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 82
 testRunner.And(string.Format("I can update town as \"{0}\"", town), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 83
 testRunner.And(string.Format("I can select county as \"{0}\"", county), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 84
 testRunner.And(string.Format("I add start date as \"{0}\"", startDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 85
 testRunner.And("I click address save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 86
 testRunner.And("I go to secondary address page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 87
 testRunner.And("I remove the seondary address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 88
 testRunner.And("I click address save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 89
 testRunner.Then("I click on logout button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Perform add new address and start date >  effective date in my Profile")]
        [Xunit.TraitAttribute("FeatureTitle", "EditMyProfile")]
        [Xunit.TraitAttribute("Description", "Perform add new address and start date >  effective date in my Profile")]
        [Xunit.TraitAttribute("Category", "connect-regression")]
        [Xunit.TraitAttribute("Category", "editmyprofile")]
        public void PerformAddNewAddressAndStartDateEffectiveDateInMyProfile()
        {
            string[] tagsOfScenario = new string[] {
                    "connect-regression",
                    "editmyprofile"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Perform add new address and start date >  effective date in my Profile", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 97
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 99
 testRunner.Given("I login as an employee", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 100
 testRunner.And("I click on edit my profile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 101
 testRunner.And("I click add new address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 102
 testRunner.And("I can select address type as \"Recruiting\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 103
 testRunner.And("I can update address line 1 as \"1 Chalgrove Road\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 104
 testRunner.And("I can update address line 2 as \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 105
 testRunner.And("I can update address line 3 as \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 106
 testRunner.And("I can update town as \"Suotton\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 107
 testRunner.And("I can select county as \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 108
 testRunner.And("I can update postcode as \"SM2 5JT\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 109
 testRunner.And("I add start date as \"06/10/2020\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 110
 testRunner.And("I click address save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 111
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
                EditMyProfileFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                EditMyProfileFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
