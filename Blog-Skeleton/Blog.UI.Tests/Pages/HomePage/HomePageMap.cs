using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace Blog.UI.Tests.Pages.HomePage
{
    public partial class HomePage
    {
        public IWebElement blogTitle
        {
            get
            {
                return this.Driver.FindElement(By.TagName("title"));
            }
        }

        public IWebElement blogLogo
        {
            get
            {
                return this.Driver.FindElement(By.ClassName("navbar-brand"));
            }
        }

        //lko
        public IWebElement FirstPost
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.XPath("//h2/a")));
            }
        }

        public IWebElement loginLink
        {
            get
            {
                return this.Driver.FindElement(By.Id("loginLink"));
            }
        }

        public IWebElement createLink
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li[1]/a"));
            }
        }

        public IWebElement blogPostsTitle
        {
            get
            {
                return this.Driver.FindElement(By.PartialLinkText("DummyTitle"));
            }
        }

        public IWebElement blogPostsTitleNew
        {
            get
            {
                return this.Driver.FindElement(By.PartialLinkText("NewPostTitle"));
            }
        }

        public IWebElement blogPostsTitleDelete
        {
            get
            {
                return this.Driver.FindElement(By.PartialLinkText("DummyTitleDelete"));
            }
        }

        public IWebElement blogPostsTitleOther
        {
            get
            {
                return this.Driver.FindElement(By.PartialLinkText("Hello World"));
            }
        }
    }
}