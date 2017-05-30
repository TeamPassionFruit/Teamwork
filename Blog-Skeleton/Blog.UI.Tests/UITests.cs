﻿using NUnit.Framework;
using OpenQA.Selenium;
using Blog.UI.Tests.Models;
using Blog.UI.Tests.Pages.RegistrationPage;
using System;
using System.Threading;
using Blog.UI.Tests.Pages.HomePage;
using System.IO;
using System.Configuration;
using NUnit.Framework.Interfaces;
using Blog.UI.Tests.Pages.Login;
using Blog.UITests.Models;

namespace Blog.UI.Tests
{
    [TestFixture]
    public class UITests
    {
        IWebDriver driver;


        [SetUp]
        public void Init()
        {

            this.driver = BrowserHost.Instance.Application.Browser;
            this.driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CleanUp()
        {
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

        #region TestCases from 1 to 4
        [Test]
        //1 негативен тест - Валерия
        public void RegistrateWithOutValidEmail()
        {
            //var regPage = new RegistrationPage(this.driver); //работи
            var homePage = new HomePage(this.driver);
            homePage.NavigateTo();
            if (homePage.IsElementPresent(By.PartialLinkText("Log off")))
                homePage.logoutLink.Click();
            homePage.LinkRegistration.Click();
            var regPage = new RegistrationPage(this.driver);

            RegistrationUser user = new RegistrationUser("а",
                                                         "Ivan Ivanov",
                                                         "1234",
                                                         "1234");

            /*regPage.NavigateTo();
            regPage.LinkRegistration.Click();*/ //работи

            regPage.FillRegistrationForm(user);
            regPage.AssertEmailErrorMessage("The Email field is not a valid e-mail address.");


        }

        [Test]
        //2 негативен тест - Валерия
        public void RegistrateWithOutValidConfPass()
        {
            //var regPage = new RegistrationPage(this.driver); //работи
            var homePage = new HomePage(this.driver);
            if (homePage.IsElementPresent(By.PartialLinkText("Log off")))
                homePage.logoutLink.Click();
            homePage.NavigateTo();
            homePage.LinkRegistration.Click();
            var regPage = new RegistrationPage(this.driver);


            RegistrationUser user = new RegistrationUser("lera1@abv.bg",
                                                         "Ivan Ivanov",
                                                         "1234",
                                                         "12345");

            /* regPage.NavigateTo();
             regPage.LinkRegistration.Click();*/ //работи

            regPage.FillRegistrationForm(user);
            regPage.AssertConfPassErrorMessage("The password and confirmation password do not match");

        }

        [Test]
        //3 негативен тест - Валерия
        public void RegistrateWithOutFullName()
        {
            // var regPage = new RegistrationPage(this.driver); //работи

            var homePage = new HomePage(this.driver);
            homePage.NavigateTo();
            if (homePage.IsElementPresent(By.PartialLinkText("Log off")))
                homePage.logoutLink.Click();
            homePage.LinkRegistration.Click();
            var regPage = new RegistrationPage(this.driver);


            RegistrationUser user = new RegistrationUser("lera1@abv.bg",
                                                         "",
                                                         "1234",
                                                         "1234");

            /* regPage.NavigateTo();
             regPage.LinkRegistration.Click();*/
            regPage.FillRegistrationForm(user);
            regPage.AssertFullNameErrorMessage("The Full Name field is required");


        }

        [Test]
        //4 позитивен - Валерия
        public void RegistrateSuccess()
        {
            //IWebDriver driver = BrowserHost.Instance.Application.Browser;
            var regPage = new RegistrationPage(this.driver);

            Random rnd = new Random();
            string strRnd = rnd.Next(1, 9999).ToString();

            RegistrationUser user = new RegistrationUser("lera" + strRnd + "@abv.bg",
                                                         "Ivan Ivanov",
                                                         "1234",
                                                         "1234");
            var homePage = new HomePage(this.driver);
            homePage.NavigateTo();
            if (homePage.IsElementPresent(By.PartialLinkText("Log off")))
                homePage.logoutLink.Click();
            homePage.LinkRegistration.Click();

            //  regPage.NavigateTo();
            //  regPage.LinkRegistration.Click();
            regPage.FillRegistrationForm(user);

            Thread.Sleep(2000);
            regPage.AssertMessageOK("Hello lera" + strRnd + "@abv.bg!");
            regPage.LogOff.Click();
            Thread.Sleep(2000);


        }

        #endregion

        #region TestCases from 14 to 16

        [Test, Property("TestCase", 14)]
        [Author("GS")]
        public void GuestUserGoToBlog_NoUserLogedIn()
        {
            HomePage homePage = new HomePage(this.driver);
            homePage.NavigateTo();
            homePage.LogoffIfLoggedAtStartup(this.driver);

            homePage.AssertGuestUserEnterTheBlog();
        }

        [Test, Property("TestCase", 15)]
        [Author("GS")]
        public void GuestUserGoToBlog_UserLogedIn()
        {
            HomePage homePage = new HomePage(this.driver);
            LoginPage loginPage = new LoginPage(this.driver);

            homePage.NavigateTo();
            var loginUser = new LoginUser("Gergana@abv.bg", "123456");
            homePage.LoginUser(this.driver, loginUser);
            homePage.NavigateTo();

            loginPage.AssertValidLogIn1("Hello");
            loginPage.AssertValidLogIn2("Log off");
            homePage.logoutLink.Click();
        }

        [Test, Property("TestCase", 16)]
        [Author("GS")]
        public void LoggedUserLogOffTheBlog()
        {
            HomePage homePage = new HomePage(this.driver);
            LoginPage loginPage = new LoginPage(this.driver);

            homePage.NavigateTo();
            var loginUser = new LoginUser("Gergana@abv.bg", "123456");
            homePage.LoginUser(this.driver, loginUser);
            homePage.logoutLink.Click();

            homePage.AssertGuestUserEnterTheBlog();
        }

        #endregion

        [Test, Property("Priority", 1)]
        [Author("TSV")]
        public void ValidLogIn()
        {
            var loginPage = new LoginPage(this.driver);
            LoginUser user = new LoginUser("Tsvetelina@abv.bg", "123456");
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
            var homePage = new HomePage(this.driver);
            homePage.LogoffIfLoggedAtStartup(this.driver);
            var loginPage = new LoginPage(this.driver);
            var logIn = AccessExcelData.GetTestData("No Email Address");
            loginPage.NavigatetoBlogLogIn();
            loginPage.FillLogInForm(logIn);

            loginPage.AssertNoEmailAddressDetected("The Email field is required");
        }


        [Test, Property("Priority", 1)]
        [Author("TSV")]
        public void TryToLogInIncorrectEmailAddress()
        {
            var homePage = new HomePage(this.driver);
            homePage.LogoffIfLoggedAtStartup(this.driver);
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
            var homePage = new HomePage(this.driver);
            homePage.LogoffIfLoggedAtStartup(this.driver);
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
            var homePage = new HomePage(this.driver);
            homePage.LogoffIfLoggedAtStartup(this.driver);
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
            var homePage = new HomePage(this.driver);
            homePage.LogoffIfLoggedAtStartup(this.driver);
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
            var homePage = new HomePage(this.driver);
            homePage.LogoffIfLoggedAtStartup(this.driver);
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
            var homePage = new HomePage(this.driver);
            homePage.LogoffIfLoggedAtStartup(this.driver);
            var loginPage = new LoginPage(this.driver);
            var logIn = AccessExcelData.GetTestData("Invalid email address format and no password");
            loginPage.NavigatetoBlogLogIn();
            loginPage.FillLogInForm(logIn);

            loginPage.AssertInvalidEmailAddressFormat("The Email field is not a valid e-mail address");
            loginPage.AssertNoPassword("The Password field is required");
        }

    }
}
