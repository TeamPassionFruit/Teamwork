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
            var loginPage = new LoginPage(driver);
            var loginUser = new LoginUser("Dimitar@abv.bg", "123456");

            if (IsElementPresent(By.PartialLinkText("Log in")))
            {
                this.Click(this.loginLink);
                this.loginLink.Click();
                loginPage.FillLogInForm(loginUser);
            }
            else if (!IsElementPresent(By.PartialLinkText("Dimitar@abv.bg!")))
            {
                this.logoutLink.Click();
                this.loginLink.Click();
                loginPage.FillLogInForm(loginUser);
            }

                //if (IsElementPresent(By.Id("loginLink")))
                //{
                //    this.Click(this.loginLink);
                //    var loginPage = new LoginPage(driver);
                //    var loginUser = new LoginUser("Dimitar@abv.bg", "123456");
                //    loginPage.FillLogInForm(loginUser);
                //}
            }
    }
}