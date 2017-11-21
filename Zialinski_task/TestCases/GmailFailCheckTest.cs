using System.Configuration;
using AventStack.ExtentReports;
using NUnit.Framework;
using Zialinski_task.Enums;
using Zialinski_task.PageObjects;
using Zialinski_task.TestSettings;

namespace Zialinski_task.TestCases
{
    class GmailFailCheckTest
    {
        private const string TestName = "GmailFailCheckTest";

        [NUnit.Framework.Test]
        public void FailReportCheckTest()
        {
            Page.GmailLogin.InputLogin(ConfigurationManager.AppSettings["InvalidLogin"]);
            Page.GmailLogin.SubmitLogin();
            Assert.True(Page.GmailPassword.IsLoginApplied(BaseTest.Driver), "Password page is not opened");
        }
    }
}
