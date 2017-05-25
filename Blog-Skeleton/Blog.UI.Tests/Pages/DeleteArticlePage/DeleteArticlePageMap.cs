using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Blog.UI.Tests.Pages.DeleteArticlePage
{
    public partial class DeleteArticlePage
    {
        public IWebElement deleteBtn
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[3]/div/input"));
            }
        }
    }
}