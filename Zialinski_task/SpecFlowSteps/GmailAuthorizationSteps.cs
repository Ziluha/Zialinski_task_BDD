using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Zialinski_task.SpecFlowSteps
{
    [Binding]
    public sealed class GmailAuthorizationSteps
    {
        [Given(@"I have entered (.*) in Login Field")]
        public void GivenIHaveEnteredTest_Task_ZelInLoginField(string login)
        {
            Console.WriteLine(login);
        }

        [When(@"I press Next Button")]
        public void WhenIPressNextButton()
        {
            Console.WriteLine("Pressed");
        }

        [Then(@"Opens Password Page")]
        public void ThenOpensPasswordPage()
        {
            Console.WriteLine("Opened");
        }

        [Given(@"I have entered ""(.*)"" in Password Field")]
        public void GivenIHaveEnteredInPasswordField(string password)
        {
            Console.WriteLine(password);
        }


        [Then(@"Opens Inbox Page and authorization is succeed")]
        public void ThenOpensInboxPageAndAuthorizationIsSucceed()
        {
            Console.WriteLine("Opened.Succeed");
        }

    }
}
