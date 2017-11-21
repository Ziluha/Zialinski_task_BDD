using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using MongoDB.Driver.Core.Events;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Zialinski_task.DriverSettings;
using Zialinski_task.Enums;
using Zialinski_task.PageObjects;
using Zialinski_task.ReportSettings;
using Zialinski_task.SpecFlowHooks;
using Zialinski_task.TestSettings;

namespace Zialinski_task.SpecFlowSteps
{
    [Binding]
    public sealed class GmailAuthorizationSteps
    {
        [Given(@"I have opened Gmail on Login Page")]
        public void GivenIHaveOpenedGmailOnLoginPage()
        {
            BaseReport.Test = BaseReport.Extent.CreateTest("Authorization With Valid Data");
            Console.WriteLine("App is opened");
        }

        [When(@"I enter (.*) in Login Field")]
        public void WhenIEnterTest_Task_ZelInLoginField(string login)
        {
            Page.GmailLogin.InputLogin(login);
        }

        [When(@"I submit Login")]
        public void WhenISubmitLogin()
        {

            Page.GmailLogin.SubmitLogin();
        }

        [Then(@"Opens Password Page")]
        public void ThenOpensPasswordPage()
        {
            Console.WriteLine("Opened");
        }

        [When(@"I have entered '(.*)' in Password Field")]
        public void WhenIHaveEnteredInPasswordField(string password)
        {
            Page.GmailPassword.InputPassword(password, BaseTest.Driver);
        }

        [When(@"I submit Password")]
        public void WhenISubmitPassword()
        {
            Page.GmailPassword.SubmitPassword();
        }

        [Then(@"Opens Inbox Page and authorization is succeed")]
        public void ThenOpensInboxPageAndAuthorizationIsSucceed()
        {
            Console.WriteLine("Opened and Succeed");
            Assert.True(Page.GmailInbox.IsLoginSucceed(BaseTest.Driver), "User was not logged in");
            BaseReport.Test.Pass("User successfully authorized");
        }
    }
}
