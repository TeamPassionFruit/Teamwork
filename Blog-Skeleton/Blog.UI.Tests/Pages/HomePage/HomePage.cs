using Blog.UI.Tests.Models;
using Blog.UI.Tests.Pages.Login;
using OpenQA.Selenium;

namespace Blog.UI.Tests.Pages.HomePage
{
    public partial class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {

        }

        public string URL
        {
            get
            {
                return BrowserHost.RootUrl;
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        public void LoginUser(IWebDriver driver, LoginUser user)
        {
            var loginPage = new LoginPage(driver);

            if (IsElementPresent(By.PartialLinkText("Log in")))
            {
                this.Click(this.loginLink);
                this.loginLink.Click();
                loginPage.FillLogInForm(user);
            }
            else if (!IsElementPresent(By.PartialLinkText(user.EmailAddress)))
            {
                this.logoutLink.Click();
                this.loginLink.Click();
                loginPage.FillLogInForm(user);
            }
        }

        public void LogoffIfLoggedAtStartup(IWebDriver driver)
        {
            if (IsElementPresent(By.PartialLinkText("Log off")))
            {
                this.logoutLink.Click();
            }
        }
    }
}