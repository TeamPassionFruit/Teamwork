using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests.Pages.Login
{
    public static class LoginPageAsserter
    {
        public static void AssertLogInPageIsOpen(this LoginPage page, string text)
        {
            Assert.AreEqual(text, page.Header.Text);
        }

        public static void AssertValidLogIn1(this LoginPage page, string text)
        {
            Assert.IsTrue(page.Hello.Displayed);
            StringAssert.Contains(text, page.Hello.Text);
        }

        public static void AssertValidLogIn2(this LoginPage page, string text)
        {
            Assert.IsTrue(page.LogOff.Displayed);
            StringAssert.Contains(text, page.LogOff.Text);
        }

        public static void AssertNoEmailAddressDetected(this LoginPage page, string text)
        {
            Assert.IsTrue(page.NoEmailAddressOrInvalidEmailAddressFormat.Displayed);
            StringAssert.Contains(text, page.NoEmailAddressOrInvalidEmailAddressFormat.Text);
        }

        public static void AssertInvalidEmailAddressFormat(this LoginPage page, string text)
        {
            Assert.IsTrue(page.NoEmailAddressOrInvalidEmailAddressFormat.Displayed);
            StringAssert.Contains(text, page.NoEmailAddressOrInvalidEmailAddressFormat.Text);
        }

        public static void AssertInvalidLogInAttemptEmailAndOrPassword(this LoginPage page, string text)
        {
            Assert.IsTrue(page.InvalidLogInAttempt.Displayed);
            StringAssert.Contains(text, page.InvalidLogInAttempt.Text);
        }

        public static void AssertNoPassword(this LoginPage page, string text)
        {
            Assert.IsTrue(page.PasswordFieldRequired.Displayed);
            StringAssert.Contains(text, page.PasswordFieldRequired.Text);
        }

        //Ilko
        public static void AssertLoginPageLoaded(this LoginPage page)
        {
            Assert.IsTrue(page.LoginHeading.Displayed);
            Assert.AreEqual("Log in", page.LoginHeading.Text);
        }

    }
}
