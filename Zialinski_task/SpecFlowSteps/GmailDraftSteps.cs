using System;
using System.Configuration;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Zialinski_task.PageObjects;
using Zialinski_task.TestSettings;

namespace Zialinski_task.SpecFlowSteps
{
    [Binding]
    public sealed class GmailDraftSteps
    {
        private int _countOfDraftsAtStart;

        [Given(@"I have opened Gmail on Login Page and authorized with valid data\. Inbox Page is opened")]
        public void GivenIHaveOpenedGmailOnLoginPageAndAuthorizedWithValidData_InboxPageIsOpened()
        {
            Page.GmailLogin.InputLogin(ConfigurationManager.AppSettings["ValidLogin"]);
            Page.GmailLogin.SubmitLogin();
            Page.GmailPassword.InputPassword(ConfigurationManager.AppSettings["ValidPassword"], BaseTest.Driver);
            Page.GmailPassword.SubmitPassword();
            Console.WriteLine("App is opened");
        }
        
        [When(@"I click Compose button")]
        public void WhenIClickComposeButton()
        {
            Page.GmailInbox.ClickComposeButton();
        }

        [Then(@"Opens Compose box and I input Message Subject")]
        public void ThenOpensComposeBoxAndIInputMessageSubject()
        {
            Page.GmailInbox.InputMessageSubject(ConfigurationManager.AppSettings["TextSample"]);
        }

        [When(@"Saved label is presented")]
        public void WhenSavedLabelIsPresented()
        {
            Assert.True(Page.GmailInbox.IsSavedLabelDisplayed(BaseTest.Driver), "Saved Lable is not presented");
        }

        [Then(@"I click Drafts Link")]
        public void ThenIClickDraftsLink()
        {
            Page.GmailInbox.GoToDrafts();
        }

        [When(@"Draft Page is opened")]
        public void WhenDraftPageIsOpened()
        {
            Assert.True(Page.GmailDrafts.IsDraftPageOpened(BaseTest.Driver), "Draft Page is not opened");
        }

        [When(@"My message is presented in Drafts")]
        public void WhenMyMessageIsPresentedInDrafts()
        {
            Assert.True(Page.GmailDrafts.IsDraftAdded(ConfigurationManager.AppSettings["TextSample"]),
                "No message with this subject in drafts");
        }

        [Then(@"Message successfully added in drafts")]
        public void ThenMessageSuccessfullyAddedInDrafts()
        {
        }

        [When(@"I choose first Draft")]
        public void WhenIChooseFirstDraft()
        {
            _countOfDraftsAtStart = Page.GmailDrafts.GetCountOfDrafts();
            Page.GmailDrafts.ChooseFirstDraft();
        }

        [Then(@"I click Discard Drafts button")]
        public void ThenIClickDiscardDraftsButton()
        {
            Page.GmailDrafts.ClickDiscardDraftsButton();
        }

        [When(@"Count of Drafts equals count of Drafts at start minus (.*)")]
        public void WhenCountOfDraftsEqualsCountOfDraftsAtStartMinus(int p0)
        {
            Assert.AreEqual(_countOfDraftsAtStart - 1, Page.GmailDrafts.GetCountOfDrafts(),
                "Count of drafts at start and afted discarding doesn't match");
        }

        [Then(@"Draft successfully deleted")]
        public void ThenDraftSuccessfullyDeleted()
        {
        }
    }
}
