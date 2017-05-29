using Blog.UI.Tests.Models;
using Blog.UI.Tests.Pages.Login;
using Blog.UITests.Models;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests
{
    [TestFixture]
    public class TestLogin
    {
        public IWebDriver driver;

        [SetUp]
        public void Init()
        {
            this.driver = BrowserHost.Instance.Application.Browser;
            this.driver.Manage().Window.Maximize();


        }

        [TearDown]
        public void CleanUp()
        {



            // From DD
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                string pathToProject = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
                string filename = pathToProject + ConfigurationManager.AppSettings["RelativeLogs"]
                                    + "\\" + TestContext.CurrentContext.Test.Name;
                string filenameTxt = filename + ".txt";
                if (File.Exists(filenameTxt))
                {
                    File.Delete(filenameTxt);
                }
                File.WriteAllText(filenameTxt, TestContext.CurrentContext.Test.FullName + Environment.NewLine
                                            + TestContext.CurrentContext.Result.Message + Environment.NewLine);

                string filenameJpg = filename + ".jpg";
                if (File.Exists(filenameJpg))
                {
                    File.Delete(filenameJpg);
                }
                var screenshot = ((ITakesScreenshot)this.driver).GetScreenshot();
                screenshot.SaveAsFile(filenameJpg, ScreenshotImageFormat.Jpeg);
            }
        }

        [Test, Property("Priority", 1)]
        [Author("TSV")]
        public void ValidLogIn()
        {
            // IWebDriver driver = BrowserHost.Instance.Application.Browser;

            var loginPage = new LoginPage(this.driver);
            LoginUser user = new LoginUser("Tsvetelina@abv.bg", "123456");
            //var logIn = AccessExcelData.GetTestData("ValidLogin");
            loginPage.NavigatetoBlogLogIn();
            loginPage.FillLogInFormHardCode(user);

            loginPage.AssertValidLogIn1(("Hello"));
            loginPage.AssertValidLogIn2("Log off");
            loginPage.LogOff.Click();
        }

        [Test, Property("Priority", 1)]
        [Author("TSV")]
        public void TryToLogInNoEmailAddress()
        {
            var loginPage = new LoginPage(this.driver);
            var logIn = AccessExcelData.GetTestData("No Email Address");
            loginPage.NavigatetoBlogLogIn();
            loginPage.FillLogInForm(logIn);

            loginPage.AssertNoEmailAddressDetected("The Email field is required");
        }


        [Test, Property("Priority", 1)]
        [Author("Anonymous")]
        public void TryToLogInIncorrectEmailAddress()
        {
            var loginPage = new LoginPage(this.driver);
            var logIn = AccessExcelData.GetTestData("Incorrect Email Address");
            loginPage.NavigatetoBlogLogIn();
            loginPage.FillLogInForm(logIn);

            loginPage.AssertInvalidLogInAttemptEmailAndOrPassword("Invalid login attempt");
        }

        [Test, Property("Priority", 1)]
        [Author("TSV")]
        public void TryToLogInInvalidEmailAddressFormat()
        {
            var loginPage = new LoginPage(this.driver);
            var logIn = AccessExcelData.GetTestData("Invalid Email Address Format");
            loginPage.NavigatetoBlogLogIn();
            loginPage.FillLogInForm(logIn);

            loginPage.AssertInvalidEmailAddressFormat("The Email field is not a valid e-mail address");
        }

        [Test, Property("Priority", 1)]
        [Author("TSV")]
        public void TryToLogInIncorrectPassword()
        {
            var loginPage = new LoginPage(this.driver);
            var logIn = AccessExcelData.GetTestData("Incorrect Password");
            loginPage.NavigatetoBlogLogIn();
            loginPage.FillLogInForm(logIn);

            loginPage.AssertInvalidLogInAttemptEmailAndOrPassword("Invalid login attempt");
        }

        [Test, Property("Priority", 1)]
        [Author("TSV")]
        public void TryToLogInNoPassword()
        {
            var loginPage = new LoginPage(this.driver);
            var logIn = AccessExcelData.GetTestData("No Password");
            loginPage.NavigatetoBlogLogIn();
            loginPage.FillLogInForm(logIn);

            loginPage.AssertNoPassword("The Password field is required");
        }

        [Test, Property("Priority", 1)]
        [Author("TSV")]
        public void TryToLogInNoEmailAdressAndNoPassword()
        {
            var loginPage = new LoginPage(this.driver);
            var logIn = AccessExcelData.GetTestData("No email address and no password");
            loginPage.NavigatetoBlogLogIn();
            loginPage.FillLogInForm(logIn);

            loginPage.AssertNoEmailAddressDetected("The Email field is required");
            loginPage.AssertNoPassword("The Password field is required");
        }

        [Test, Property("Priority", 1)]
        [Author("TSV")]
        public void TryToLogInInvalidEmailAdressFormatAndNoPassword()
        {
            var loginPage = new LoginPage(this.driver);
            var logIn = AccessExcelData.GetTestData("Invalid email address format and no password");
            loginPage.NavigatetoBlogLogIn();
            loginPage.FillLogInForm(logIn);

            loginPage.AssertInvalidEmailAddressFormat("The Email field is not a valid e-mail address");
            loginPage.AssertNoPassword("The Password field is required");
        }



    }
}

