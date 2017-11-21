using System.Configuration;
using AventStack.ExtentReports;
using NUnit.Framework;
using Zialinski_task.Enums;
using Zialinski_task.PageObjects;
using Zialinski_task.ReportSettings;
using Zialinski_task.TestSettings;

namespace Zialinski_task.TestCases
{
    [TestFixture]
    public class GmailAuthorizationTest
    {
        private const string TestName = "GmailLoginTest";

        [Test]
        public void AuthorizationWithValidData()
        {
            BaseReport.Test = BaseReport.Extent.CreateTest("Authorization With Valid Data");
            Page.GmailLogin.InputLogin(ConfigurationManager.AppSettings["ValidLogin"]);
            Page.GmailLogin.SubmitLogin();
            Page.GmailPassword.InputPassword(ConfigurationManager.AppSettings["ValidPassword"], BaseTest.Driver);
            Page.GmailPassword.SubmitPassword();
            Assert.True(Page.GmailInbox.IsLoginSucceed(BaseTest.Driver), "User was not logged in");
            BaseReport.Test.Pass("User successfully authorized");
        }

        [Test]
        public void AuthorizationWithInvalidLogin()
        {
            BaseReport.Test = BaseReport.Extent.CreateTest("Authorization With Invalid Login");
            Page.GmailLogin.InputLogin(ConfigurationManager.AppSettings["InvalidLogin"]);
            Page.GmailLogin.SubmitLogin();
            Assert.True(Page.GmailLogin.IsLoginErrorLabelPresented(BaseTest.Driver), "Login Error Lable is not presented");
            BaseReport.Test.Pass("User is not authorized with invalid login");
        }

        [Test]
        public void AuthorizationWithInvalidPassword()
        {
            BaseReport.Test = BaseReport.Extent.CreateTest("Authorization With Invalid Password");
            Page.GmailLogin.InputLogin(ConfigurationManager.AppSettings["ValidLogin"]);
            Page.GmailLogin.SubmitLogin();
            Page.GmailPassword.InputPassword(ConfigurationManager.AppSettings["InvalidPassword"], BaseTest.Driver);
            Page.GmailPassword.SubmitPassword();
            Assert.True(Page.GmailPassword.IsPasswordErrorLabelPresented(BaseTest.Driver), 
                "Password Error Lable is not presented");
            BaseReport.Test.Pass("User is not authorized with invalid password");
        }
    }
}
