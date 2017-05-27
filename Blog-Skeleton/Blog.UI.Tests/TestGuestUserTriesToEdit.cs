using Blog.UI.Tests.Pages.DetailsPage;
using Blog.UI.Tests.Pages.HomePage;
using Blog.UI.Tests.Pages.Login;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests
{
    [TestFixture]
    public class TestGuestUserTriesToEdit
    {
        IWebDriver driver;

        [SetUp]
        public void Init()
        {
            this.driver = BrowserHost.Instance.Application.Browser;
            this.driver.Manage().Window.Maximize();
        }


        [Test]
        [Property("Priority", 1)]
        [Author("IP")]
        public void GuestUserCantEditPost()
        {
            var homePage = new HomePage(this.driver);
            homePage.NavigateTo();
            homePage.LogoffIfLoggedAtStartup(this.driver);
            homePage.FirstPost.Click();

            var detailsPage = new DetailsPage(this.driver);
            detailsPage.EditButton.Click();

            var loginPage = new LoginPage(this.driver);
            loginPage.AssertLoginPageLoaded();
        }

        [Test]
        [Property("Priority", 1)]
        [Author("IP")]
        public void GuestUserCantDeletePost()
        {
            var homePage = new HomePage(this.driver);
            homePage.NavigateTo();
            homePage.LogoffIfLoggedAtStartup(this.driver);
            homePage.FirstPost.Click();

            var detailsPage = new DetailsPage(this.driver);
            detailsPage.DeleteButton.Click();

            var loginPage = new LoginPage(this.driver);
            loginPage.AssertLoginPageLoaded();
        }
    }
}
