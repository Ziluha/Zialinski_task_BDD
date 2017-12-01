using NUnit.Framework;
using TechTalk.SpecFlow;
using Zialinski_task.PageObjects;
using Zialinski_task.TestSettings;

namespace Zialinski_task.SpecFlowSteps
{
    [Binding]
    public sealed class GmailFailSteps
    {
        [Then(@"Authorization is unsucceed, but fails")]
        public void ThenAuthorizationIsUnsucceedButFails()
        {
            Assert.True(Page.GmailPassword.IsLoginApplied(BaseTest.Driver), "Password page is not opened");
        }
    }
}
