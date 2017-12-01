using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using Zialinski_task.Pathes;
using Zialinski_task.WrapperFactory;

namespace Zialinski_task.ReportSettings
{
    public static class BaseReport
    {
        public static ExtentReports Extent;
        public static ExtentTest Test;
        public static ExtentTest Scenario;
        private static ExtentHtmlReporter _htmlReporter;
        
        public static void StartReport(string testName)
        {
            string extentConfigName = "extent-config.xml";
            string binPath = ProjectPathes.GetBinPath();
            string actualPath = ProjectPathes.GetActualPath(binPath);
            string projectPath = ProjectPathes.GetLocalUri(actualPath);
            string reportPath = projectPath + "Reports\\Report"+testName+".html";

            _htmlReporter = new ExtentHtmlReporter(reportPath);
            _htmlReporter.LoadConfig(projectPath + extentConfigName);
            Extent = new ExtentReports();
            Extent.AttachReporter(_htmlReporter);

            Extent.AddSystemInfo("By", "Zialinski Ivan");
        }
        
        public static void GetResult(string testName)
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var errorMessage = TestContext.CurrentContext.Result.Message;

            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                string screenshotPath = GetScreenshot.Capture(BrowserFactory.Driver, testName);
                Scenario.CreateNode<Then>(errorMessage).Fail("fail");
                Test.CreateNode<And>("Snapshot below: " + Test.AddScreenCaptureFromPath(screenshotPath)).Fail("fail");
            }
            Scenario = null;
        }
        
        public static void StopReport()
        {
            Extent.Flush();
            Extent.RemoveTest(Test);
        }
    }
}
