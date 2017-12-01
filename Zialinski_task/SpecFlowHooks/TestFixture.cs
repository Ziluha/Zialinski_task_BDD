using AventStack.ExtentReports;
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
        }

        [BeforeScenario]
        public static void BeforeScenario()
        {
            BaseTest.BrowserName = Browser.Name.Chrome;
            BaseTest.Init();
            BaseReport.Test = BaseReport.Extent.CreateTest<Feature>(ScenarioContext.Current.ScenarioInfo.Title);
            BaseReport.Scenario = BaseReport.Test.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterStep]
        public static void AfterStep()
        {
            BaseReport.Scenario.CreateNode(new GherkinKeyword(
                ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString()), 
                ScenarioStepContext.Current.StepInfo.Text).Pass("pass");
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
