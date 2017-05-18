﻿using Blog.UI.Tests.Pages.HomePage;
using NUnit.Framework;
using OpenQA.Selenium;


namespace Blog.UI.Tests
{
    [TestFixture]
    public class TestHomePage
    {
        IWebDriver driver;

        [SetUp]
        public void Init()
        {
            this.driver = BrowserHost.Instance.Application.Browser;
        }

        [Test]
        public void CheckLogoPOM()
        {
            var homePage = new HomePage(this.driver);
            homePage.NavigateTo();

            homePage.AssertBlogLogoText();
        }
    }
}
