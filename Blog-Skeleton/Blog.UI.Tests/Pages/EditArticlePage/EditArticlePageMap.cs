using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Blog.UI.Tests.Pages.EditArticlePage
{
    public partial class EditArticlePage
    {
        public IWebElement pageTitle
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/h2"));
            }
        }

        public IWebElement postTitle
        {
            get
            {
                return this.Driver.FindElement(By.Id("Title"));
            }
        }

        public IWebElement postContent
        {
            get
            {
                return this.Driver.FindElement(By.Id("Content"));
            }
        }

        public IWebElement editBtn
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/input"));
            }
         }
    }
}