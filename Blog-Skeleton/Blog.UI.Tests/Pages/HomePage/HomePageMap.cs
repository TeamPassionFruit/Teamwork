using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Blog.UI.Tests.Pages.HomePage
{
    public partial class HomePage
    {
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
    }
}