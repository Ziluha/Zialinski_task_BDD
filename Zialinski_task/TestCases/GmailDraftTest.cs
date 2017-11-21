using System.Configuration;
using AventStack.ExtentReports;
using NUnit.Framework;
using Zialinski_task.Enums;
using Zialinski_task.PageObjects;
using Zialinski_task.TestSettings;

namespace Zialinski_task.TestCases
{
    [TestFixture]
    public class GmailDraftTest
    {
        private const string TestName = "GmailDraftTest";

        [SetUp]
        public void SetUpAuth()
        {
            Page.GmailLogin.InputLogin(ConfigurationManager.AppSettings["ValidLogin"]);
            Page.GmailLogin.SubmitLogin();
            Page.GmailPassword.InputPassword(ConfigurationManager.AppSettings["ValidPassword"], BaseTest.Driver);
            Page.GmailPassword.SubmitPassword();
        }
        
        [Test]
        public void AddMessageToDrafts()
        {
            Page.GmailInbox.ClickComposeButton();
            Page.GmailInbox.InputMessageSubject(ConfigurationManager.AppSettings["TextSample"]);
            Assert.True(Page.GmailInbox.IsSavedLabelDisplayed(BaseTest.Driver), "Saved Lable is not presented");
            Page.GmailInbox.GoToDrafts();
            Assert.True(Page.GmailDrafts.IsDraftPageOpened(BaseTest.Driver), "Draft Page is not opened");
            Assert.True(Page.GmailDrafts.IsDraftAdded(ConfigurationManager.AppSettings["TextSample"]),
                "No message with this subject in drafts");
        }

        [Test]
        public void DeleteMessageFromDrafts()
        {
            int draftNumber = 3;
            Page.GmailInbox.GoToDrafts();
            Assert.True(Page.GmailDrafts.IsDraftPageOpened(BaseTest.Driver),"Draft Page is not opened");
            int countOfDraftsAtStart = Page.GmailDrafts.GetCountOfDrafts();
            Page.GmailDrafts.ChooseFirstDraft(draftNumber);
            Page.GmailDrafts.ClickDiscardDraftsButton();
            Assert.AreEqual(countOfDraftsAtStart-1, Page.GmailDrafts.GetCountOfDrafts(),
                "Count of drafts at start and afted discarding doesn't match");
        }
    }
}
