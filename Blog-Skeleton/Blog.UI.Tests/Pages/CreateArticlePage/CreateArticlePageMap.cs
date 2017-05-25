using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Blog.UI.Tests.Pages.CreateArticlePage
{
    public partial class CreateArticlePage
    {
        public IWebElement titleField
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id='Title']"));
            }
        }

        public IWebElement contentField
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id='Content']"));
            }
        }

        public IWebElement createBtn
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/input"));
            }
                
        }
    }
}