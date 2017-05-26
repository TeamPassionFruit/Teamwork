using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Blog.UI.Tests.Models;
using Blog.UI.Tests.Pages.RegistrationPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Blog.UI.Tests.Pages.HomePage;

namespace Blog.UI.Tests
{
    [TestFixture]
    public class UITests
    {
        public IWebDriver driver;


        [SetUp]
        public void Init()
        {
            this.driver = BrowserHost.Instance.Application.Browser;
            //this.driver = new ChromeDriver();
        }

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


    }
}
