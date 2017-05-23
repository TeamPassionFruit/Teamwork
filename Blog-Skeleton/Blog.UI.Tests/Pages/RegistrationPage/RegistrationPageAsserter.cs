using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests.Pages.RegistrationPage
{
    public static class RegistrationPageAsserter
    {


        public static void AssertEmailErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesEmail.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesEmail.Text);
            //The Email field is not a valid e-mail address.
        }


        public static void AssertConfPassErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesConfPass.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesConfPass.Text);

        }

        public static void AssertFullNameErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesFullName.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesFullName.Text);

        }

        public static void AssertMessageOK(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.MessageOK.Displayed);
            StringAssert.Contains(text, page.MessageOK.Text);

        }

    }
}
