using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AventStack.ExtentReports.Gherkin.Model;
using TechTalk.SpecFlow;
using Zialinski_task.Enums;
using Zialinski_task.ReportSettings;
using Zialinski_task.TestSettings;

namespace Zialinski_task.SpecFlowHooks
{
    [Binding]
    public sealed class TestFixture
    {
        [BeforeFeature]
        public static void BeforeFeature()
        {
            BaseTest.TestName = FeatureContext.Current.FeatureInfo.Title;
            BaseTest.InitReport();
            BaseReport.Test = BaseReport.Extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [BeforeScenario]
        public static void BeforeScenario()
        {
            BaseTest.BrowserName = Browser.Name.Chrome;
            BaseTest.Init();
            BaseReport.Scenario = BaseReport.Test.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [BeforeStep]
        public void AfterStep()
        {
            BaseReport.Scenario.CreateNode<Scenario>(ScenarioStepContext.Current.StepInfo.Text).Pass("pass");
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            BaseTest.EndTest();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            BaseTest.EndReport();
        }
    }
}
