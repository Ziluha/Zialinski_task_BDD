using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Zialinski_task.Enums;
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
