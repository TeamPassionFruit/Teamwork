using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Blog.UI.Tests.Pages.ArticleDetailsPage
{
    public partial class ArticleDetailsPage
    {
        public IWebElement editBtn
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/article/footer/a[1]"));
            }
        }

        public IWebElement deleteBtn
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/article/footer/a[2]"));
            }
        }
    }
}