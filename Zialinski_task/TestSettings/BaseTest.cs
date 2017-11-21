using NUnit.Framework;
using OpenQA.Selenium;
using System.Configuration;
using Zialinski_task.DriverSettings;
using Zialinski_task.Enums;
using Zialinski_task.ReportSettings;
using Zialinski_task.WrapperFactory;

namespace Zialinski_task.TestSettings
{
    public static class BaseTest
    {
        public static IWebDriver Driver { get; set; }
        public static Browser.Name BrowserName;
        public static string TestName;

        /*public BaseTest(Browser.Name browserName, string testName)
        {
            BrowserName = browserName;
            BrowserFactory = BrowserFactory.GetInstance();
            TestName = testName;
        }*/

        private static void ChooseDriverInstance(Browser.Name browserName)
        {
            if (browserName == Browser.Name.Chrome)
                Driver = BrowserFactory.GetInstance().InitBrowser(Browser.Name.Chrome);
            else if (browserName == Browser.Name.Firefox)
                Driver = BrowserFactory.GetInstance().InitBrowser(Browser.Name.Firefox);
        }
        
        public static void InitReport()
        {
            BaseReport.StartReport(TestName);
        }
        
        public static void Init()
        {
            ChooseDriverInstance(BrowserName);
            DriverConfiguration.LoadApp(Driver, ConfigurationManager.AppSettings["GmailURL"]);
        }
        
        public static void EndTest()
        {
            BaseReport.GetResult(TestName);
            BrowserFactory.GetInstance().CloseAllDrivers();
        }

        public static void EndReport()
        {
            BaseReport.StopReport();
        }
    }
}
