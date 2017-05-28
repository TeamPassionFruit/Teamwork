using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;

namespace Blog.UI.Tests.Pages.HomePage
{
    public static class HomePageAsserter
    {
        public static void AssertBlogLogoText(this HomePage page)
        {
            Assert.AreEqual("SOFTUNI BLOG", page.blogLogo.Text);
        }

        public static void AssertBlogPostTitle(this HomePage page, string title)
        {
            Assert.AreEqual(title, page.blogPostsTitle.Text);
           // page.blogPostsTitles.ForEach(item => Assert.Contains("Dummy post", item.ToList());
        }

        public static void AssertBlogPostTitleNew(this HomePage page, string title)
        {
            Assert.AreEqual(title, page.blogPostsTitleNew.Text);
        }

        public static void AssertBlogPostTitleDelete(this HomePage page, string title)
        {
            Assert.AreEqual(false, page.IsElementPresent(By.PartialLinkText(title)));
        }

        public static void AssertGuestUserEnterTheBlog(this HomePage page)
        {
            Assert.IsTrue(page.loginLink.Displayed);
            Assert.IsTrue(page.LinkRegistration.Displayed);
        }

    }
}