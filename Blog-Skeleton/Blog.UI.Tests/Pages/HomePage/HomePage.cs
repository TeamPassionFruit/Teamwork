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

        public void CheckForLogin(IWebDriver driver)
        {
            if (IsElementPresent(By.Id("loginLink")))
            {
                this.loginLink.Click();
                var loginPage = new LoginPage(driver);
                var loginUser = new LoginUser("Dimitar@abv.bg", "123456");
                loginPage.FillLogInForm(loginUser);
            }
            else if(!IsElementPresent(By.PartialLinkText("Dimitar@abv.bg!")))
            {
                this.logoffLink.Click();
                this.loginLink.Click();
                var loginPage = new LoginPage(driver);
                var loginUser = new LoginUser("Dimitar@abv.bg", "123456");
                loginPage.FillLogInForm(loginUser);
            }
        }


    }
}